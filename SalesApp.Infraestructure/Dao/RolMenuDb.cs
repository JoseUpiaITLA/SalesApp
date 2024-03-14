using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SalesApp.Domain.Entities;
using SalesApp.Infraestructure.Context;
using SalesApp.Infraestructure.Core;
using SalesApp.Infraestructure.Exceptions;
using SalesApp.Infraestructure.Interfaces;

namespace SalesApp.Infraestructure.Dao
{
    public class RolMenuDb : DaoBase<RolMenu, int>, IRolMenuDb
    {
        private readonly SaleContext _saleContext;
        private readonly ILogger<RolMenuDb> _logger;
        private readonly IConfiguration _configuration;
        public RolMenuDb(SaleContext saleContext, ILogger<RolMenuDb> logger, IConfiguration configuration) : base(saleContext)
        {
            this._saleContext = saleContext;
            this._logger = logger;
            this._configuration = configuration;
        }

        public override List<RolMenu> GetAll()
        {
            return base.GetEntitiesWithFilters(e => !e.Eliminado);
        }

        public override DataResult Save(RolMenu entity)
        {
            DataResult result = new DataResult();
            try
            {
                if (this.Exists(e => e.Id == entity.Id))
                    throw new CustomException("La Rol Menu se encuentra registrado.");

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

        public override DataResult Update(RolMenu entity)
        {
            DataResult result = new DataResult();
            try
            {
                RolMenu RolMenuToUpdate = base.GetById(entity.Id);

                RolMenuToUpdate.IdRol = entity.IdRol;
                RolMenuToUpdate.IdMenu = entity.IdMenu;
                RolMenuToUpdate.IdUsuarioMod = entity.IdUsuarioMod;
                RolMenuToUpdate.EsActivo = entity.EsActivo;
                RolMenuToUpdate.FechaMod = entity.FechaMod;

                base.Update(RolMenuToUpdate);
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
