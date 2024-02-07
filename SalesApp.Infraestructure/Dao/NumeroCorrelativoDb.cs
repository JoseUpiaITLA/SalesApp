using SalesApp.Domain.Entities;
using SalesApp.Infraestructure.Core;
using SalesApp.Infraestructure.Exceptions;
using SalesApp.Infraestructure.Interfaces;

namespace SalesApp.Infraestructure.Dao
{
    public class NumeroCorrelativoDb : INumeroCorrelativoDb
    {
        public bool Exists(string name)
        {
            throw new NotImplementedException();
        }

        public List<NumeroCorrelativo> GetAll()
        {
            throw new NotImplementedException();
        }

        public NumeroCorrelativo GetById(int deptoId)
        {
            throw new NotImplementedException();
        }

        public DataResult Save(NumeroCorrelativo entity)
        {
            DataResult result = new DataResult();
            try
            {
                if (this.Exists(entity.Gestion))
                    throw new CustomException("La NumeroCorrelativo se encuentra registrado.");
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
