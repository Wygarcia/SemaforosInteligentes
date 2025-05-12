namespace SemaforosInteligentes.Models { 
public class HechoTrafico
{
    public int Id { get; set; }

    public int DimTiempoId { get; set; }
    public DimTiempo DimTiempo { get; set; }

    public int DimCarrilId { get; set; }
    public DimCarril DimCarril { get; set; }

    public int DimInterseccionId { get; set; }
    public DimInterseccion DimInterseccion { get; set; }

    public int DimSemaforoId { get; set; }
    public DimSemaforo DimSemaforo { get; set; }

    public int CantidadVehiculos { get; set; }
    public float TiempoEsperaSeg { get; set; }
    public float VelocidadPromKmh { get; set; }
    public string LuzSemaforo { get; set; }
}
}