
namespace SemaforosInteligentes.Models { 
public class DimTiempo
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public TimeSpan Hora { get; set; }
    public string DiaSemana { get; set; }
    public int Mes { get; set; }
    public int Anio { get; set; }
}
}