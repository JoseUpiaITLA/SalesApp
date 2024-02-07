using SalesApp.Domain.Entities;
using SalesApp.Infraestructure.Core;
using SalesApp.Infraestructure.Exceptions;
using SalesApp.Infraestructure.Interfaces;

namespace SalesApp.Infraestructure.Dao
{
    public class MenuDb : IMenuDb
    {
        public bool Exists(string name)
        {
            throw new NotImplementedException();
        }

        public List<Menu> GetAll()
        {
            throw new NotImplementedException();
        }

        public Menu GetById(int deptoId)
        {
            throw new NotImplementedException();
        }

        public DataResult Save(Menu entity)
        {
            DataResult result = new DataResult();
            try
            {
                if (this.Exists(entity.Descripcion))
                    throw new CustomException("El Menu se encuentra registrado.");
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
