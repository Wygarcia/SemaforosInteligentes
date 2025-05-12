using Microsoft.EntityFrameworkCore;
using SemaforosInteligentes.Models;

public class SemaforosDbContext : DbContext
{
    public SemaforosDbContext(DbContextOptions<SemaforosDbContext> options)
        : base(options)
    {
    }

    public DbSet<DimTiempo> DimTiempos { get; set; }
    public DbSet<DimCarril> DimCarriles { get; set; }
    public DbSet<DimInterseccion> DimIntersecciones { get; set; }
    public DbSet<DimSemaforo> DimSemaforos { get; set; }
    public DbSet<HechoTrafico> HechosTrafico { get; set; }
}

