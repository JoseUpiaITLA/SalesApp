using SalesApp.Domain.Entities;
using SalesApp.Infraestructure.Core;
using SalesApp.Infraestructure.Models.Response;
using SalesApp.Infraestructure.Models.Venta;

namespace SalesApp.Infraestructure.Interfaces
{
    public interface IVentaDb : IDaoBase<Venta, int>
    {
        Task<VentaUsuario> GetVentaUsuarios(int usuarioId);
        ApiResponse<Venta> SaveVenta(Venta venta);
    }
}
