using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SalesApp.Domain.Entities;
using SalesApp.Infraestructure.Context;
using SalesApp.Infraestructure.Core;
using SalesApp.Infraestructure.Exceptions;
using SalesApp.Infraestructure.Interfaces;

namespace SalesApp.Infraestructure.Dao
{
    public class NegocioDb : DaoBase<Negocio>, INegocioDb
    {
        private readonly SaleContext _saleContext;
        private readonly ILogger<NegocioDb> _logger;
        private readonly IConfiguration _configuration;
        public NegocioDb(SaleContext saleContext, ILogger<NegocioDb> logger, IConfiguration configuration) : base(saleContext)
        {
            this._saleContext = saleContext;
            this._logger = logger;
            this._configuration = configuration;
        }

        public override List<Negocio> GetAll()
        {
            return base.GetEntitiesWithFilters(e => !e.Eliminado);
        }

        public override DataResult Save(Negocio entity)
        {
            DataResult result = new DataResult();
            try
            {
                if (this.Exists(e => e.Id == entity.Id))
                    throw new CustomException("La Negocio se encuentra registrado.");

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

        public override DataResult Update(Negocio entity)
        {
            DataResult result = new DataResult();
            try
            {
                Negocio NegocioToUpdate = base.GetById(entity.Id);

                NegocioToUpdate.UrlLogo = entity.UrlLogo;
                NegocioToUpdate.NombreLogo = entity.NombreLogo;
                NegocioToUpdate.NumeroDocumento = entity.NumeroDocumento;
                NegocioToUpdate.Nombre = entity.Nombre;
                NegocioToUpdate.Correo = entity.Correo;
                NegocioToUpdate.Direccion = entity.Direccion;
                NegocioToUpdate.Telefono = entity.Telefono;
                NegocioToUpdate.PorcentajeImpuesto = entity.PorcentajeImpuesto;
                NegocioToUpdate.SimboloMoneda = entity.SimboloMoneda;
                NegocioToUpdate.IdUsuarioMod = entity.IdUsuarioMod;
                NegocioToUpdate.EsActivo = entity.EsActivo;
                NegocioToUpdate.FechaMod = entity.FechaMod;

                base.Update(NegocioToUpdate);
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
