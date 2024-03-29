namespace SalesApp.Infraestructure.Models.TipoDocumentoVenta
{
    public class TipoDocumentoVentaCreateModel : TipoDocumentoVentaBaseModel
    {
        public DateTime fechaRegistro { get; set; }
        public int idUsuarioCreacion { get; set; }
    }
}
