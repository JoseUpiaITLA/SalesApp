using SalesApp.Domain.Entities;
using SalesApp.Infraestructure.Core;
using SalesApp.Infraestructure.Exceptions;
using SalesApp.Infraestructure.Interfaces;

namespace SalesApp.Infraestructure.Dao
{
    public class VentaDb : IVentaDb
    {
        public bool Exists(string name)
        {
            throw new NotImplementedException();
        }

        public List<Venta> GetAll()
        {
            throw new NotImplementedException();
        }

        public Venta GetById(int deptoId)
        {
            throw new NotImplementedException();
        }

        public DataResult Save(Venta entity)
        {
            DataResult result = new DataResult();
            try
            {
                if (this.Exists(entity.NombreCliente))
                    throw new CustomException("La Venta se encuentra registrado.");
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
