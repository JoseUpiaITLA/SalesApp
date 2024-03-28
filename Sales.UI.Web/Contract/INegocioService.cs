using SalesApp.Infraestructure.Models.Negocio;
using SalesApp.Infraestructure.Models.Response;

namespace Sales.UI.Web.Contract
{
    public interface INegocioService
    {
        Task<ApiResponse<List<NegocioBaseModal>>> GetNegocios();
        Task<ApiResponse<NegocioBaseModal>> GetNegocioById(int id);
        Task<ApiResponse<NegocioUpdateModal>> PutNegocio(NegocioUpdateModal negocioUpdateModal);
        Task<ApiResponse<NegocioCreateModal>> PostNegocio(NegocioCreateModal negocioCreateModal);
    }
}
