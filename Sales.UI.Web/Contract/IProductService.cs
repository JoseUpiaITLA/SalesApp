using SalesApp.Infraestructure.Models.Producto;
using SalesApp.Infraestructure.Models.Response;

namespace Sales.UI.Web.Contract
{
    public interface IProductService
    {
        Task<ApiResponse<List<ProductoCategoria>>> GetProductByCategory(int categoriaId);
    }
}
