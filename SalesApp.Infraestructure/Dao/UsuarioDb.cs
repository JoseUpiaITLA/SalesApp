using SalesApp.Domain.Entities;
using SalesApp.Infraestructure.Core;
using SalesApp.Infraestructure.Exceptions;
using SalesApp.Infraestructure.Interfaces;

namespace SalesApp.Infraestructure.Dao
{
    public class UsuarioDb : IUsuarioDb
    {
        public bool Exists(string name)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> GetAll()
        {
            throw new NotImplementedException();
        }

        public Usuario GetById(int deptoId)
        {
            throw new NotImplementedException();
        }

        public DataResult Save(Usuario entity)
        {
            DataResult result = new DataResult();
            try
            {
                if (this.Exists(entity.Nombre))
                    throw new CustomException("La Usuario se encuentra registrado.");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió el siguiente error: {ex.Message}";
            }
            return result;
        }
    }
}
