
namespace SemaforosInteligentes.Models
{
    public class DimTiempo
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public TimeOnly Hora { get; set; }  // <-- CAMBIADO de TimeSpan a TimeOnly
        public string DiaSemana { get; set; }
        public int Mes { get; set; }
        public int Anio { get; set; }
    }
}