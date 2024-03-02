using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SalesApp.Domain.Entities;
using SalesApp.Infraestructure.Context;
using SalesApp.Infraestructure.Core;
using SalesApp.Infraestructure.Exceptions;
using SalesApp.Infraestructure.Interfaces;

namespace SalesApp.Infraestructure.Dao
{
    public class DetalleVentaDb : DaoBase<DetalleVenta>, IDetalleVentaDb
    {
        private readonly SaleContext _saleContext;
        private readonly ILogger<DetalleVentaDb> _logger;
        private readonly IConfiguration _configuration;
        public DetalleVentaDb(SaleContext saleContext, ILogger<DetalleVentaDb> logger, IConfiguration configuration) : base(saleContext)
        {
            this._saleContext = saleContext;
            this._logger = logger;
            this._configuration = configuration;
        }

        public override DataResult Save(DetalleVenta entity)
        {
            DataResult result = new DataResult();
            try
            {
                if (this.Exists(e => e.Id == entity.Id))
                    throw new CustomException("El detalle de venta se encuentra registrado.");

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

        public override DataResult Update(DetalleVenta entity)
        {
            DataResult result = new DataResult();
            try
            {
                DetalleVenta DetalleVentaToUpdate = base.GetById(entity.Id);

                DetalleVentaToUpdate.IdProducto = entity.IdProducto;
                DetalleVentaToUpdate.MarcaProducto = entity.MarcaProducto;
                DetalleVentaToUpdate.DescripcionProducto = entity.DescripcionProducto;
                DetalleVentaToUpdate.CategoriaProducto = entity.CategoriaProducto;
                DetalleVentaToUpdate.Cantidad = entity.Cantidad;
                DetalleVentaToUpdate.Precio = entity.Precio;
                DetalleVentaToUpdate.Total = entity.Total;

                base.Update(DetalleVentaToUpdate);
                base.Commit();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrio el siguiente error: {ex.Message}";
                this._logger.LogError(result.Message, ex.ToString());
            }
            return base.Update(entity);
        }
    }
}
