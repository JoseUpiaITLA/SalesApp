using SalesApp.Infraestructure.Models.Categoria;
using SalesApp.Infraestructure.Models.DetalleVenta;
using SalesApp.Infraestructure.Models.Producto;
using SalesApp.Infraestructure.Models.TipoDocumentoVenta;
using SalesApp.Infraestructure.Models.Venta;

namespace Sales.UI.Web.Models
{
    public class CreateVentaModel
    {
        public List<TipoDocumentoVentaBaseModel>? TipoDocumentoVenta { get; set; }
        public List<CategoriaBaseModal>? Categoria { get; set; }
        public List<ProductoBaseModel>? Producto { get; set; }
        public VentaCreateModel? Venta { get; set; }
        public DetalleVentaBaseModal? DetalleVenta { get; set; }
    }
}
