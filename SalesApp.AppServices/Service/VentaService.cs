using Microsoft.Extensions.Logging;
using SalesApp.AppServices.Contracts;
using SalesApp.AppServices.Core;
using SalesApp.Infraestructure.Interfaces;

namespace SalesApp.AppServices.Service
{
    public class VentaService : IVentaService
    {
        private readonly IVentaDb _ventaDb;
        private readonly ILogger<VentaService> _logger;

        public VentaService(IVentaDb ventaDb, ILogger<VentaService> logger)
        {
            this._ventaDb = ventaDb;
            this._logger = logger;
        }

        public async Task<ServiceResult> GetVentasByUsuario(int usuarioId)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Data = await this._ventaDb.GetVentaUsuarios(usuarioId);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener las ventas por usuario";
                this._logger.LogError(ex, result.Message);
            }
            return result;
        }
    }
}
