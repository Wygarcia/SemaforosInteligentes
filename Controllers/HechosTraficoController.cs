using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SemaforosInteligentes.Dtos;
using SemaforosInteligentes.Models;

[ApiController]
[Route("api/[controller]")]
public class HechoTraficoController : ControllerBase
{
    private readonly SemaforosDbContext _context;

    public HechoTraficoController(SemaforosDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<HechoTrafico>>> GetAll() =>
        Ok(await _context.HechosTrafico
            .Include(h => h.DimTiempo)
            .Include(h => h.DimCarril)
            .Include(h => h.DimInterseccion)
            .Include(h => h.DimSemaforo)
            .ToListAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<HechoTrafico>> Get(int id)
    {
        var item = await _context.HechosTrafico
            .Include(h => h.DimTiempo)
            .Include(h => h.DimCarril)
            .Include(h => h.DimInterseccion)
            .Include(h => h.DimSemaforo)
            .FirstOrDefaultAsync(h => h.Id == id);
        return item == null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<HechoTrafico>> Create(HechoTraficoDto dto)
    {
        var entity = new HechoTrafico
        {
            DimTiempoId = dto.DimTiempoId,
            DimCarrilId = dto.DimCarrilId,
            DimInterseccionId = dto.DimInterseccionId,
            DimSemaforoId = dto.DimSemaforoId,
            CantidadVehiculos = dto.CantidadVehiculos,
            TiempoEsperaSeg = dto.TiempoEsperaSeg,
            VelocidadPromKmh = dto.VelocidadPromKmh,
            LuzSemaforo = dto.LuzSemaforo
        };
        _context.HechosTrafico.Add(entity);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = entity.Id }, entity);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var entity = await _context.HechosTrafico.FindAsync(id);
        if (entity == null) return NotFound();

        _context.HechosTrafico.Remove(entity);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
