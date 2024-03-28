
namespace SalesApp.Infraestructure.Models.Producto
{
    public class ProductoCategoria : BaseModel
    {
        public string? CodigoBarra { get; set; }
        public string? Marca { get; set; }
        public int? Stock { get; set; }
        public string? NombreCategoria { get; set; }
    }
}
