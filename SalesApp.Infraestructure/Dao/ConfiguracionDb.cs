using SalesApp.Domain.Entities;
using SalesApp.Infraestructure.Core;
using SalesApp.Infraestructure.Exceptions;
using SalesApp.Infraestructure.Interfaces;

namespace SalesApp.Infraestructure.Dao
{
    public class ConfiguracionDb : IConfiguracionDb
    {
        public bool Exists(string name)
        {
            throw new NotImplementedException();
        }

        public List<Configuracion> GetAll()
        {
            throw new NotImplementedException();
        }

        public Configuracion GetById(int deptoId)
        {
            throw new NotImplementedException();
        }

        public DataResult Save(Configuracion entity)
        {
            DataResult result = new DataResult();
            try
            {
                if (this.Exists(entity.Recurso))
                    throw new CustomException("La Configuracion se encuentra registrado.");
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
