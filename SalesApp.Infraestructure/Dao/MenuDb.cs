using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SalesApp.Domain.Entities;
using SalesApp.Infraestructure.Context;
using SalesApp.Infraestructure.Core;
using SalesApp.Infraestructure.Exceptions;
using SalesApp.Infraestructure.Interfaces;

namespace SalesApp.Infraestructure.Dao
{
    public class MenuDb : DaoBase<Menu, int>, IMenuDb
    {
        private readonly SaleContext _saleContext;
        private readonly ILogger<MenuDb> _logger;
        private readonly IConfiguration _configuration;
        public MenuDb(SaleContext saleContext, ILogger<MenuDb> logger, IConfiguration configuration) : base(saleContext)
        {
            this._saleContext = saleContext;
            this._logger = logger;
            this._configuration = configuration;
        }

        public override List<Menu> GetAll()
        {
            return base.GetEntitiesWithFilters(e => !e.Eliminado);
        }

        public override DataResult Save(Menu entity)
        {
            DataResult result = new DataResult();
            try
            {
                if (this.Exists(e => e.Descripcion == entity.Descripcion))
                    throw new CustomException("La Menu se encuentra registrado.");

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

        public override DataResult Update(Menu entity)
        {
            DataResult result = new DataResult();
            try
            {
                Menu MenuToUpdate = base.GetById(entity.Id);

                MenuToUpdate.Descripcion = entity.Descripcion;
                MenuToUpdate.IdMenuPadre = entity.IdMenuPadre;
                MenuToUpdate.Icono = entity.Icono;
                MenuToUpdate.Controlador = entity.Controlador;
                MenuToUpdate.PaginaAccion = entity.PaginaAccion;

                base.Update(MenuToUpdate);
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
