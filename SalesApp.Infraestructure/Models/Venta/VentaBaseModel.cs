using SalesApp.Infraestructure.Models.TipoDocumentoVenta;

namespace SalesApp.Infraestructure.Models.Venta
{
    public class VentaBaseModel : BaseModel
    {
        public string? numeroVenta { get; set; }
        public int? idTipoDocumentoVenta { get; set; }
        public TipoDocumentoVentaBaseModel? tipoDocumentoVenta { get; set; }
        public int? idUsuario { get; set; }
        public string? cocumentoCliente { get; set; }
        public string? nombreCliente { get; set; }
        public decimal? subTotal { get; set; }
        public decimal? impuestoTotal { get; set; }
        public decimal? total { get; set; }
    }
}
