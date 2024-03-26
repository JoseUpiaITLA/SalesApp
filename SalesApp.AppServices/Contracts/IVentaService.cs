using SalesApp.AppServices.Core;

namespace SalesApp.AppServices.Contracts
{
    public interface IVentaService
    {
        public Task<ServiceResult> GetVentasByUsuario(int usuarioId);
    }
}
