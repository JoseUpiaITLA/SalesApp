using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SalesApp.Domain.Entities;
using SalesApp.Infraestructure.Context;
using SalesApp.Infraestructure.Core;
using SalesApp.Infraestructure.Exceptions;
using SalesApp.Infraestructure.Interfaces;

namespace SalesApp.Infraestructure.Dao
{
    public class NumeroCorrelativoDb : DaoBase<NumeroCorrelativo>, INumeroCorrelativoDb
    {
        private readonly SaleContext _saleContext;
        private readonly ILogger<NumeroCorrelativoDb> _logger;
        private readonly IConfiguration _configuration;
        public NumeroCorrelativoDb(SaleContext saleContext, ILogger<NumeroCorrelativoDb> logger, IConfiguration configuration) : base(saleContext)
        {
            this._saleContext = saleContext;
            this._logger = logger;
            this._configuration = configuration;
        }

        public override List<NumeroCorrelativo> GetAll()
        {
            return base.GetEntitiesWithFilters(e => !e.Eliminado);
        }

        public override DataResult Save(NumeroCorrelativo entity)
        {
            DataResult result = new DataResult();
            try
            {
                if (this.Exists(e => e.Id == entity.Id))
                    throw new CustomException("La Numero Correlativo se encuentra registrado.");

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

        public override DataResult Update(NumeroCorrelativo entity)
        {
            DataResult result = new DataResult();
            try
            {
                NumeroCorrelativo NumeroCorrelativoToUpdate = base.GetById(entity.Id);

                NumeroCorrelativoToUpdate.UltimoNumero = entity.UltimoNumero;
                NumeroCorrelativoToUpdate.CantidadDigitos = entity.CantidadDigitos;
                NumeroCorrelativoToUpdate.Gestion = entity.Gestion;
                NumeroCorrelativoToUpdate.FechaActualizacion = entity.FechaActualizacion;
                NumeroCorrelativoToUpdate.IdUsuarioMod = entity.IdUsuarioMod;
                NumeroCorrelativoToUpdate.EsActivo = entity.EsActivo;
                NumeroCorrelativoToUpdate.FechaMod = entity.FechaMod;

                base.Update(NumeroCorrelativoToUpdate);
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
