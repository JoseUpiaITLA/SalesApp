using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SalesApp.Domain.Entities;
using SalesApp.Infraestructure.Context;
using SalesApp.Infraestructure.Core;
using SalesApp.Infraestructure.Exceptions;
using SalesApp.Infraestructure.Interfaces;

namespace SalesApp.Infraestructure.Dao
{
    public class ConfiguracionDb : DaoBase<Configuracion>, IConfiguracionDb
    {
        private readonly SaleContext _saleContext;
        private readonly ILogger<ConfiguracionDb> _logger;
        private readonly IConfiguration _configuration;
        public ConfiguracionDb(SaleContext saleContext, ILogger<ConfiguracionDb> logger, IConfiguration configuration) : base(saleContext)
        {
            this._saleContext = saleContext;
            this._logger = logger;
            this._configuration = configuration;
        }

        public override DataResult Save(Configuracion entity)
        {
            DataResult result = new DataResult();
            try
            {
                if (this.Exists(e => e.Id == entity.Id))
                    throw new CustomException("La Configuracion se encuentra registrado.");

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

        public override DataResult Update(Configuracion entity)
        {
            DataResult result = new DataResult();
            try
            {
                Configuracion ConfiguracionToUpdate = base.GetById(entity.Id);

                ConfiguracionToUpdate.Recurso = entity.Recurso;
                ConfiguracionToUpdate.Propiedad = entity.Propiedad;
                ConfiguracionToUpdate.Valor = entity.Valor;

                base.Update(ConfiguracionToUpdate);
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
