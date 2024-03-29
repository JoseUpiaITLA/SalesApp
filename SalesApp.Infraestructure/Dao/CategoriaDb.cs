using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SalesApp.Domain.Entities;
using SalesApp.Infraestructure.Context;
using SalesApp.Infraestructure.Core;
using SalesApp.Infraestructure.Exceptions;
using SalesApp.Infraestructure.Interfaces;

namespace SalesApp.Infraestructure.Dao
{
    public class CategoriaDb : DaoBase<Categoria, int>, ICategoriaDb
    {
        private readonly SaleContext _saleContext;
        private readonly ILogger<CategoriaDb> _logger;
        private readonly IConfiguration _configuration;
        public CategoriaDb(SaleContext saleContext, ILogger<CategoriaDb> logger, IConfiguration configuration) : base(saleContext)
        {
            this._saleContext = saleContext;
            this._logger = logger;
            this._configuration = configuration;
        }

        public override List<Categoria> GetAll()
        {
            return base.GetEntitiesWithFilters(e => !e.Eliminado && e.EsActivo);
        }

        public override DataResult Save(Categoria entity)
        {
            DataResult result = new DataResult();
            try
            {
                if (this.Exists(e => e.Descripcion == entity.Descripcion))
                    throw new CustomException("La categoria se encuentra registrado.");

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

        public override DataResult Update(Categoria entity)
        {
            DataResult result = new DataResult();
            try
            {
                Categoria categoriaToUpdate = base.GetById(entity.Id);

                categoriaToUpdate.Descripcion = entity.Descripcion;
                categoriaToUpdate.IdUsuarioMod = entity.IdUsuarioMod;
                categoriaToUpdate.EsActivo = entity.EsActivo;
                categoriaToUpdate.FechaMod = entity.FechaMod;

                base.Update(categoriaToUpdate);
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
