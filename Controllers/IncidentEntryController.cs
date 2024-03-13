using incidentdbapi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace incidentdbapi;

[Authorize]
[ApiController]
[Route("[controller]")]
[EnableCors("AllowAll")]
public class IncidentEntryController : ControllerBase
{
    private readonly ApplicationDBContext _context;
    public IncidentEntryController(ApplicationDBContext context)
    {
        this._context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<IncidentModel>> Get()
    {
        return await _context.IncidentsDBSet.ToListAsync();
    }


    [HttpGet("{id}")]
    [ProducesResponseType(typeof(IncidentModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetById(int id)
    {
        var value = await _context.IncidentsDBSet.FindAsync(id);
        return value == null ? NotFound() : Ok(value);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(IncidentModel model)
    {
        await _context.IncidentsDBSet.AddAsync(model);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = model.Incidentid }, model);
    }

    [HttpPut("{id}")]
    [ProducesResponseType((StatusCodes.Status204NoContent))]
    [ProducesResponseType((StatusCodes.Status400BadRequest))]
    public async Task<IActionResult> Update(int id, IncidentModel models)
    {
        if (id != models.Incidentid) return BadRequest();
        _context.Entry(models).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var delete = await _context.IncidentsDBSet.FindAsync(id);
        if (delete == null) return NotFound();
        _context.IncidentsDBSet.Remove(delete);
        await _context.SaveChangesAsync();
        return NoContent();
    }

}