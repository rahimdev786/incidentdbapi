using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace incidentdbapi.Controllers;

public class AuthController : ControllerBase
{
    private readonly ApplicationDBContext _dbContext;
    private readonly JwtSetting _jwtSetting;

    public AuthController(ApplicationDBContext dbContext, IOptions<JwtSetting> options)
    {
        this._dbContext = dbContext;
        this._jwtSetting = options.Value;
    }

    [HttpPost("authenticate")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Authenticate([FromBody] RegistrationModel models)
    {
        var user = await this._dbContext.RegisterDBSet.FirstOrDefaultAsync(
            item => item.UserName == models.UserName
            && item.UserPassword == models.UserPassword);

        if (user == null)
        {
            return Unauthorized(new { message = "user crendital not match", code = 401 });
        }

        //generate token
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(this._jwtSetting.securitykey);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[] { new(ClaimTypes.Name, user.UserName!), new(ClaimTypes.Role, user.UserRole!) }),
            Expires = DateTime.Now.AddSeconds(30),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        // convert ito string
        var finalToken = tokenHandler.WriteToken(token);
        return Ok(new { message = "sucessful login", token = finalToken, code = 200 });
    }
}