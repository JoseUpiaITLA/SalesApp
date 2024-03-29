using SalesApp.Infraestructure.Models.DetalleVenta;
using SalesApp.Infraestructure.Models.Response;

namespace Sales.UI.Web.Contract
{
    public interface IDetalleVentaService
    {
        Task<ApiResponse<DetalleVentaBaseModal>> PostDetalleVenta(DetalleVentaBaseModal detalleVentaModal);

    }
}
