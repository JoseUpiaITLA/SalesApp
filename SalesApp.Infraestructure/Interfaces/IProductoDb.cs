using SalesApp.Domain.Entities;
using SalesApp.Infraestructure.Core;
using SalesApp.Infraestructure.Models;

namespace SalesApp.Infraestructure.Interfaces
{
    public interface IProductoDb : IDaoBase<Producto, int>
    {
        public Task<List<ProductoCategoria>> GetProductByCategory(int categoriaId);
    }
}
