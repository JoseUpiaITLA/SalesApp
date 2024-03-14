using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SalesApp.Domain.Entities;
using SalesApp.Infraestructure.Context;
using SalesApp.Infraestructure.Core;
using SalesApp.Infraestructure.Exceptions;
using SalesApp.Infraestructure.Interfaces;

namespace SalesApp.Infraestructure.Dao
{
    public class TipoDocumentoVentaDb : DaoBase<TipoDocumentoVenta, int>, ITipoDocumentoVentaDb
    {
        private readonly SaleContext _saleContext;
        private readonly ILogger<TipoDocumentoVentaDb> _logger;
        private readonly IConfiguration _configuration;
        public TipoDocumentoVentaDb(SaleContext saleContext, ILogger<TipoDocumentoVentaDb> logger, IConfiguration configuration) : base(saleContext)
        {
            this._saleContext = saleContext;
            this._logger = logger;
            this._configuration = configuration;
        }

        public override List<TipoDocumentoVenta> GetAll()
        {
            return base.GetEntitiesWithFilters(e => !e.Eliminado);
        }

        public override DataResult Save(TipoDocumentoVenta entity)
        {
            DataResult result = new DataResult();
            try
            {
                if (this.Exists(e => e.Descripcion == entity.Descripcion))
                    throw new CustomException("La TipoDocumentoVenta se encuentra registrado.");

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

        public override DataResult Update(TipoDocumentoVenta entity)
        {
            DataResult result = new DataResult();
            try
            {
                TipoDocumentoVenta TipoDocumentoVentaToUpdate = base.GetById(entity.Id);

                TipoDocumentoVentaToUpdate.Descripcion = entity.Descripcion;
                TipoDocumentoVentaToUpdate.IdUsuarioMod = entity.IdUsuarioMod;
                TipoDocumentoVentaToUpdate.EsActivo = entity.EsActivo;
                TipoDocumentoVentaToUpdate.FechaMod = entity.FechaMod;

                base.Update(TipoDocumentoVentaToUpdate);
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
