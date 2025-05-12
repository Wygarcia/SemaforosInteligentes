using Microsoft.AspNetCore.Mvc;
using SemaforosInteligentes.Dtos;
using SemaforosInteligentes.Models;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class DimCarrilController : ControllerBase
{
    private readonly SemaforosDbContext _context;

    public DimCarrilController(SemaforosDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DimCarril>>> GetAll() =>
        Ok(await _context.DimCarriles.ToListAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<DimCarril>> Get(int id)
    {
        var item = await _context.DimCarriles.FindAsync(id);
        return item == null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<DimCarril>> Create(DimCarrilDto dto)
    {
        var entity = new DimCarril
        {
            NombreCarril = dto.NombreCarril,
            Sentido = dto.Sentido,
            TipoVehiculoPermitido = dto.TipoVehiculoPermitido
        };
        _context.DimCarriles.Add(entity);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = entity.Id }, entity);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var entity = await _context.DimCarriles.FindAsync(id);
        if (entity == null) return NotFound();

        _context.DimCarriles.Remove(entity);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}