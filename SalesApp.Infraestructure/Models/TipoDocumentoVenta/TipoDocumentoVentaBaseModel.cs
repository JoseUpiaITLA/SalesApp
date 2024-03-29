namespace SalesApp.Infraestructure.Models.TipoDocumentoVenta
{
    public class TipoDocumentoVentaBaseModel : BaseModel
    {
        public string? descripcion { get; set; }
        public bool esActivo { get; set; }
    }
}
