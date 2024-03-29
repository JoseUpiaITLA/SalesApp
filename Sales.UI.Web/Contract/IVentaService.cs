using SalesApp.Infraestructure.Models.DetalleVenta;
using SalesApp.Infraestructure.Models.Response;
using SalesApp.Infraestructure.Models.Venta;

namespace Sales.UI.Web.Contract
{
    public interface IVentaService
    {
        Task<ApiResponse<List<VentaBaseModel>>> GetVentas();
        Task<ApiResponse<VentaBaseModel>> GetVentaById(int id);
        Task<ApiResponse<VentaUsuario>> GetVentasByUsuarioId(int usuarioId);
        Task<ApiResponse<VentaCreateModel>> PostVenta(VentaCreateModel ventaCreateModal);
    }
}
