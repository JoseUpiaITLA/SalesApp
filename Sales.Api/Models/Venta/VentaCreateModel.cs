namespace Sales.Api.Models.Venta
{
    public class VentaCreateModel : VentaBaseModel
    {
        public DateTime FechaRegistro { get; set; }
        public int IdUsuarioCreacion { get; set; }
    }
}
