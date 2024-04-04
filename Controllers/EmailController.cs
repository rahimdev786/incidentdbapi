using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace incidentdbapi;

[ApiController]
[Route("[controller]")]
public class EmailController : ControllerBase
{

    private readonly IMailService mailService;
    public EmailController(IMailService mailService)
    {
        this.mailService = mailService;
    }

    [HttpPost("reset")]
    public async Task<IActionResult> CreatePassword(MailRequest request)
    {
        try
        {
            await mailService.SendEmailAsync(request);
            return Ok();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
