namespace SalesApp.Infraestructure.Models.TipoDocumentoVenta
{
    public class TipoDocumentoVentaUpdateModel : TipoDocumentoVentaBaseModel
    {
        public DateTime? fechaMod { get; set; }
        public int? idUsuarioMod { get; set; }
    }
}
