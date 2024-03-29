using SalesApp.Infraestructure.Models.Response;
using SalesApp.Infraestructure.Models.TipoDocumentoVenta;

namespace Sales.UI.Web.Contract
{
    public interface ITipoDocumentoVentaService
    {
        Task<ApiResponse<List<TipoDocumentoVentaBaseModel>>> GetTipoDocumentoVentas();
    }
}
