using SalesApp.Domain.Entities;
using SalesApp.Infraestructure.Core;
using SalesApp.Infraestructure.Exceptions;
using SalesApp.Infraestructure.Interfaces;

namespace SalesApp.Infraestructure.Dao
{
    public class TipoDocumentoVentaDb : ITipoDocumentoVentaDb
    {
        public bool Exists(string name)
        {
            throw new NotImplementedException();
        }

        public List<TipoDocumentoVenta> GetAll()
        {
            throw new NotImplementedException();
        }

        public TipoDocumentoVenta GetById(int deptoId)
        {
            throw new NotImplementedException();
        }

        public DataResult Save(TipoDocumentoVenta entity)
        {
            DataResult result = new DataResult();
            try
            {
                if (this.Exists(entity.Descripcion))
                    throw new CustomException("La TipoDocumentoVenta se encuentra registrado.");
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
