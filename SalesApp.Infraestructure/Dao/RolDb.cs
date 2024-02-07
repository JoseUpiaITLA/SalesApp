using SalesApp.Domain.Entities;
using SalesApp.Infraestructure.Core;
using SalesApp.Infraestructure.Exceptions;
using SalesApp.Infraestructure.Interfaces;

namespace SalesApp.Infraestructure.Dao
{
    public class RolDb : IRolDb
    {
        public bool Exists(string name)
        {
            throw new NotImplementedException();
        }

        public List<Rol> GetAll()
        {
            throw new NotImplementedException();
        }

        public Rol GetById(int deptoId)
        {
            throw new NotImplementedException();
        }

        public DataResult Save(Rol entity)
        {
            DataResult result = new DataResult();
            try
            {
                if (this.Exists(entity.Descripcion))
                    throw new CustomException("La Rol se encuentra registrado.");
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
