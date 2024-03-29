namespace SalesApp.Infraestructure.Models.Venta
{
    public class VentaCreateModel : VentaBaseModel
    {
        public DateTime fechaRegistro { get; set; }
        public int idUsuarioCreacion { get; set; }
    }
}
