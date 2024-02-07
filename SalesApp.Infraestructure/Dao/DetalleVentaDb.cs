using SalesApp.Domain.Entities;
using SalesApp.Infraestructure.Core;
using SalesApp.Infraestructure.Exceptions;
using SalesApp.Infraestructure.Interfaces;

namespace SalesApp.Infraestructure.Dao
{
    public class DetalleVentaDb : IDetalleVentaDb
    {
        public bool Exists(string name)
        {
            throw new NotImplementedException();
        }

        public List<DetalleVenta> GetAll()
        {
            throw new NotImplementedException();
        }

        public DetalleVenta GetById(int deptoId)
        {
            throw new NotImplementedException();
        }

        public DataResult Save(DetalleVenta entity)
        {
            DataResult result = new DataResult();
            try
            {
                if (this.Exists(entity.DescripcionProducto))
                    throw new CustomException("La DetalleVenta se encuentra registrado.");
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
