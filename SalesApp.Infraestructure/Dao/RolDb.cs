using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SalesApp.Domain.Entities;
using SalesApp.Infraestructure.Context;
using SalesApp.Infraestructure.Core;
using SalesApp.Infraestructure.Exceptions;
using SalesApp.Infraestructure.Interfaces;

namespace SalesApp.Infraestructure.Dao
{
    public class RolDb : DaoBase<Rol, int>, IRolDb
    {
        private readonly SaleContext _saleContext;
        private readonly ILogger<RolDb> _logger;
        private readonly IConfiguration _configuration;
        public RolDb(SaleContext saleContext, ILogger<RolDb> logger, IConfiguration configuration) : base(saleContext)
        {
            this._saleContext = saleContext;
            this._logger = logger;
            this._configuration = configuration;
        }

        public override List<Rol> GetAll()
        {
            return base.GetEntitiesWithFilters(e => !e.Eliminado);
        }

        public override DataResult Save(Rol entity)
        {
            DataResult result = new DataResult();
            try
            {
                if (this.Exists(e => e.Descripcion == entity.Descripcion))
                    throw new CustomException("La Rol se encuentra registrado.");

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

        public override DataResult Update(Rol entity)
        {
            DataResult result = new DataResult();
            try
            {
                Rol RolToUpdate = base.GetById(entity.Id);

                RolToUpdate.Descripcion = entity.Descripcion;
                RolToUpdate.IdUsuarioMod = entity.IdUsuarioMod;
                RolToUpdate.EsActivo = entity.EsActivo;
                RolToUpdate.FechaMod = entity.FechaMod;

                base.Update(RolToUpdate);
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
