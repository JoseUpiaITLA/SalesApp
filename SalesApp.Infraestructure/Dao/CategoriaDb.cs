using SalesApp.Domain.Entities;
using SalesApp.Infraestructure.Core;
using SalesApp.Infraestructure.Exceptions;
using SalesApp.Infraestructure.Interfaces;

namespace SalesApp.Infraestructure.Dao
{
    public class CategoriaDb : ICategoriaDb
    {
        public bool Exists(string name)
        {
            throw new NotImplementedException();
        }

        public List<Categoria> GetAll()
        {
            throw new NotImplementedException();
        }

        public Categoria GetById(int deptoId)
        {
            throw new NotImplementedException();
        }

        public DataResult Save(Categoria entity)
        {
            DataResult result = new DataResult();
            try
            {
                if (this.Exists(entity.Descripcion))
                    throw new CustomException("La categoria se encuentra registrado.");
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
