using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SalesApp.Domain.Entities;
using SalesApp.Infraestructure.Context;
using SalesApp.Infraestructure.Core;
using SalesApp.Infraestructure.Exceptions;
using SalesApp.Infraestructure.Interfaces;

namespace SalesApp.Infraestructure.Dao
{
    public class UsuarioDb : DaoBase<Usuario>, IUsuarioDb
    {
        private readonly SaleContext _saleContext;
        private readonly ILogger<UsuarioDb> _logger;
        private readonly IConfiguration _configuration;
        public UsuarioDb(SaleContext saleContext, ILogger<UsuarioDb> logger, IConfiguration configuration) : base(saleContext)
        {
            this._saleContext = saleContext;
            this._logger = logger;
            this._configuration = configuration;
        }

        public override List<Usuario> GetAll()
        {
            return base.GetEntitiesWithFilters(e => !e.Eliminado);
        }

        public override DataResult Save(Usuario entity)
        {
            DataResult result = new DataResult();
            try
            {
                if (this.Exists(e => e.Id == entity.Id))
                    throw new CustomException("La Usuario se encuentra registrado.");

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

        public override DataResult Update(Usuario entity)
        {
            DataResult result = new DataResult();
            try
            {
                Usuario UsuarioToUpdate = base.GetById(entity.Id);

                UsuarioToUpdate.Nombre = entity.Nombre;
                UsuarioToUpdate.Correo = entity.Correo;
                UsuarioToUpdate.Telefono = entity.Telefono;
                UsuarioToUpdate.IdRol = entity.IdRol;
                UsuarioToUpdate.UrlFoto = entity.UrlFoto;
                UsuarioToUpdate.NombreFoto = entity.NombreFoto;
                UsuarioToUpdate.Clave = entity.Clave;
                UsuarioToUpdate.IdUsuarioMod = entity.IdUsuarioMod;
                UsuarioToUpdate.EsActivo = entity.EsActivo;
                UsuarioToUpdate.FechaMod = entity.FechaMod;

                base.Update(UsuarioToUpdate);
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
