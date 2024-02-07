
namespace SalesApp.Infraestructure.Core
{
    public interface IDaoBase<TEntity> where TEntity : class
    {
        DataResult Save(TEntity entity);
        List<TEntity> GetAll();
        TEntity GetById(int id);
        bool Exists(string name);
    }
}
