namespace Sales.Api.Models.NumeroCorrelativo
{
    public class NumeroCorrelativoBaseModel : BaseModel
    {
        public int? UltimoNumero { get; set; }
        public int? CantidadDigitos { get; set; }
        public string? Gestion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
    }
}
