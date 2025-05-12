namespace SemaforosInteligentes.Dtos
{
    public class HechoTraficoDto
    {
        public int DimTiempoId { get; set; }
        public int DimCarrilId { get; set; }
        public int DimInterseccionId { get; set; }
        public int DimSemaforoId { get; set; }
        public int CantidadVehiculos { get; set; }
        public int TiempoEsperaSeg { get; set; }
        public float VelocidadPromKmh { get; set; }
        public string LuzSemaforo { get; set; }
    }
}

