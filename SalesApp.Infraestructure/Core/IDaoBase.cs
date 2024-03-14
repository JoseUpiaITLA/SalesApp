
namespace SalesApp.Infraestructure.Core
{
    public interface IDaoBase<TEntity, T> where TEntity : class
    {
        DataResult Save(TEntity entity);
        DataResult Update(TEntity entity);
        List<TEntity> GetAll();
        List<TEntity> GetEntitiesWithFilters(Func<TEntity, bool> filtter);
        TEntity GetById(T id);
        bool Exists(Func<TEntity, bool> filter);
        int Commit();
    }
}
