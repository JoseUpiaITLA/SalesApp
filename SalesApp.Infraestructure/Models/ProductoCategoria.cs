
using SalesApp.Domain.Core;

namespace SalesApp.Infraestructure.Models
{
    public class ProductoCategoria : BaseEntity<int>
    {
        public string? CodigoBarra { get; set; }
        public string? Marca { get; set; }
        public int? Stock { get; set; }
        public string? NombreCategoria { get; set; }
    }
}
