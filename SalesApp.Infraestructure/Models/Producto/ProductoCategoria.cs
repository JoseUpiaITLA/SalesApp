
namespace SalesApp.Infraestructure.Models.Producto
{
    public class ProductoCategoria : BaseModel
    {
        public string? codigoBarra { get; set; }
        public string? marca { get; set; }
        public int? stock { get; set; }
        public string? nombreCategoria { get; set; }
        public string? descripcionProducto { get; set; }
        public decimal? precio { get; set; }
    }
}
