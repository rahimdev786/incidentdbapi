using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using incidentdbapi.Controllers;

namespace incidentdbapi.Controllers;

[ApiController]
[Route("[controller]")]
public class ResgisterController : ControllerBase
{
    private readonly ApplicationDBContext _context;
    public ResgisterController(ApplicationDBContext context)
    {
        this._context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<RegistrationModel>> Get()
    {
        return await _context.RegisterDBSet.ToListAsync();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(RegistrationModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetById(int id)
    {
        var value = await _context.RegisterDBSet.FindAsync(id);
        return value == null ? NotFound() : Ok(value);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(RegistrationModel model)
    {
        await _context.RegisterDBSet.AddAsync(model);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = model.UserId }, model);
    }

    [HttpPut("{id}")]
    [ProducesResponseType((StatusCodes.Status204NoContent))]
    [ProducesResponseType((StatusCodes.Status400BadRequest))]
    public async Task<IActionResult> Update(int id, RegistrationModel models)
    {
        if (id != models.UserId) return BadRequest();
        _context.Entry(models).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var delete = await _context.RegisterDBSet.FindAsync(id);
        if (delete == null) return NotFound();
        _context.RegisterDBSet.Remove(delete);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}