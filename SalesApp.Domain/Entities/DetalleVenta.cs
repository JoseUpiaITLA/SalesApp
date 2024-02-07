
namespace SalesApp.Domain.Entities
{
    public class DetalleVenta : Core.BaseEntity
    {
        public int? IdVenta { get; set; } // FK
        public Venta? Venta { get; set; }
        public int? IdProducto { get; set; }
        public string? MarcaProducto { get; set; }
        public string? DescripcionProducto { get; set; }
        public string? CategoriaProducto { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Precio { get; set; }
        public decimal? Total { get; set; }
    }
}
