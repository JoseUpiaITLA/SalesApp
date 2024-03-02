
namespace SalesApp.Infraestructure.Core
{
    public interface IDaoBase<TEntity> where TEntity : class
    {
        DataResult Save(TEntity entity);
        DataResult Update(TEntity entity);
        List<TEntity> GetAll();
        List<TEntity> GetEntitiesWithFilters(Func<TEntity, bool> filtter);
        TEntity GetById(int id);
        bool Exists(Func<TEntity, bool> filter);
        int Commit();
    }
}
