namespace SemaforosInteligentes.Dtos
{
    public class DimTiempoDto
    {
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public string DiaSemana { get; set; }
        public int Mes { get; set; }
        public int Anio { get; set; }
    }
}

