using SalesApp.Infraestructure.Models.Categoria;
using SalesApp.Infraestructure.Models.Response;

namespace Sales.UI.Web.Contract
{
    public interface ICategoriaService
    {
        Task<ApiResponse<List<CategoriaBaseModal>>> GetCategorias();
    }
}
