using SalesApp.Domain.Entities;
using SalesApp.Infraestructure.Core;
using SalesApp.Infraestructure.Exceptions;
using SalesApp.Infraestructure.Interfaces;

namespace SalesApp.Infraestructure.Dao
{
    public class RolMenuDb : IRolMenuDb
    {
        public bool Exists(string name)
        {
            throw new NotImplementedException();
        }

        public List<RolMenu> GetAll()
        {
            throw new NotImplementedException();
        }

        public RolMenu GetById(int deptoId)
        {
            throw new NotImplementedException();
        }

        public DataResult Save(RolMenu entity)
        {
            DataResult result = new DataResult();
            try
            {
                if (this.Exists(""))
                    throw new CustomException("La RolMenu se encuentra registrado.");
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
