using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SemaforosInteligentes.Dtos;
using SemaforosInteligentes.Models;

[ApiController]
[Route("api/[controller]")]
public class DimInterseccionController : ControllerBase
{
    private readonly SemaforosDbContext _context;

    public DimInterseccionController(SemaforosDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DimInterseccion>>> GetAll() =>
        Ok(await _context.DimIntersecciones.ToListAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<DimInterseccion>> Get(int id)
    {
        var item = await _context.DimIntersecciones.FindAsync(id);
        return item == null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<DimInterseccion>> Create(DimInterseccionDto dto)
    {
        var entity = new DimInterseccion
        {
            NombreInterseccion = dto.NombreInterseccion,
            UbicacionGeografica = dto.UbicacionGeografica
        };
        _context.DimIntersecciones.Add(entity);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = entity.Id }, entity);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var entity = await _context.DimIntersecciones.FindAsync(id);
        if (entity == null) return NotFound();

        _context.DimIntersecciones.Remove(entity);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}