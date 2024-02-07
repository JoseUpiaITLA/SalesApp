using SalesApp.Domain.Entities;
using SalesApp.Infraestructure.Core;
using SalesApp.Infraestructure.Exceptions;
using SalesApp.Infraestructure.Interfaces;

namespace SalesApp.Infraestructure.Dao
{
    public class NegocioDb : INegocioDb
    {
        public bool Exists(string name)
        {
            throw new NotImplementedException();
        }

        public List<Negocio> GetAll()
        {
            throw new NotImplementedException();
        }

        public Negocio GetById(int deptoId)
        {
            throw new NotImplementedException();
        }

        public DataResult Save(Negocio entity)
        {
            DataResult result = new DataResult();
            try
            {
                if (this.Exists(entity.Nombre))
                    throw new CustomException("La Negocio se encuentra registrado.");
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
