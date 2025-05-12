using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SemaforosInteligentes.Dtos;
using SemaforosInteligentes.Models;

[ApiController]
[Route("api/[controller]")]
public class DimSemaforoController : ControllerBase
{
    private readonly SemaforosDbContext _context;

    public DimSemaforoController(SemaforosDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DimSemaforo>>> GetAll() =>
        Ok(await _context.DimSemaforos.ToListAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<DimSemaforo>> Get(int id)
    {
        var item = await _context.DimSemaforos.FindAsync(id);
        return item == null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<DimSemaforo>> Create(DimSemaforoDto dto)
    {
        var entity = new DimSemaforo
        {
            Modelo = dto.Modelo,
            Fabricante = dto.Fabricante,
            AñoInstalacion = dto.AñoInstalacion
        };
        _context.DimSemaforos.Add(entity);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = entity.Id }, entity);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var entity = await _context.DimSemaforos.FindAsync(id);
        if (entity == null) return NotFound();

        _context.DimSemaforos.Remove(entity);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
