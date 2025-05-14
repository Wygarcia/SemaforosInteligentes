using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SemaforosInteligentes.Dtos;
using SemaforosInteligentes.Models;

[ApiController]
[Route("api/[controller]")]
public class DimTiempoController : ControllerBase
{
    private readonly SemaforosDbContext _context;

    public DimTiempoController(SemaforosDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DimTiempo>>> GetAll() =>
        Ok(await _context.DimTiempos.ToListAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<DimTiempo>> Get(int id)
    {
        var item = await _context.DimTiempos.FindAsync(id);
        return item == null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<DimTiempo>> Create(DimTiempo model)
    {
        _context.DimTiempos.Add(model);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = model.Id }, model);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var entity = await _context.DimTiempos.FindAsync(id);
        if (entity == null) return NotFound();

        _context.DimTiempos.Remove(entity);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
