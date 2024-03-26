using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SalesApp.Domain.Entities;
using SalesApp.Infraestructure.Context;
using SalesApp.Infraestructure.Core;
using SalesApp.Infraestructure.Exceptions;
using SalesApp.Infraestructure.Interfaces;
using SalesApp.Infraestructure.Models;

namespace SalesApp.Infraestructure.Dao
{
    public class VentaDb : DaoBase<Venta, int>, IVentaDb
    {
        private readonly SaleContext _saleContext;
        private readonly ILogger<VentaDb> _logger;
        private readonly IConfiguration _configuration;
        public VentaDb(SaleContext saleContext, ILogger<VentaDb> logger, IConfiguration configuration) : base(saleContext)
        {
            this._saleContext = saleContext;
            this._logger = logger;
            this._configuration = configuration;
        }

        public async Task<List<VentaUsuario>> GetVentaUsuarios(int usuarioId)
        {
            List<VentaUsuario> ventaUsuarios = await (from u in _saleContext.Usuario
                                                      join v in _saleContext.Venta on u.Id equals v.IdUsuario into uv
                                                      from subV in uv.DefaultIfEmpty()
                                                      where !u.Eliminado && u.Id == usuarioId
                                                      group subV by u.Nombre into g
                                                      select new VentaUsuario
                                                      {
                                                          Vendedor = g.Key,
                                                          VentasRealizadas = g.Count(v => v != null)
                                                      }).ToListAsync();

            return ventaUsuarios;
        }

        public override DataResult Save(Venta entity)
        {
            DataResult result = new DataResult();
            try
            {
                if (this.Exists(e => e.Id == entity.Id))
                    throw new CustomException("La Venta se encuentra registrado.");

                base.Save(entity);
                base.Commit();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió el siguiente error: {ex.Message}";
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public override DataResult Update(Venta entity)
        {
            DataResult result = new DataResult();
            try
            {
                Venta VentaToUpdate = base.GetById(entity.Id);

                VentaToUpdate.NumeroVenta = entity.NumeroVenta;
                VentaToUpdate.IdTipoDocumentoVenta = entity.IdTipoDocumentoVenta;
                VentaToUpdate.IdUsuario = entity.IdUsuario;
                VentaToUpdate.CocumentoCliente = entity.CocumentoCliente;
                VentaToUpdate.NombreCliente = entity.NombreCliente;
                VentaToUpdate.SubTotal = entity.SubTotal;
                VentaToUpdate.ImpuestoTotal = entity.ImpuestoTotal;
                VentaToUpdate.Total = entity.Total;
                VentaToUpdate.FechaRegistro = entity.FechaRegistro;

                base.Update(VentaToUpdate);
                base.Commit();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrio el siguiente error: {ex.Message}";
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
