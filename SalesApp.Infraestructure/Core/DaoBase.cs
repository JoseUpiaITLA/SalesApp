using Microsoft.EntityFrameworkCore;
using SalesApp.Domain.Core;
using SalesApp.Infraestructure.Context;

namespace SalesApp.Infraestructure.Core
{
    public abstract class DaoBase<Entity, T> : IDaoBase<Entity, T> where Entity : BaseEntity<T>, new()
    {
        private readonly SaleContext _saleContext;
        private DbSet<Entity> entities;
        public DaoBase(SaleContext saleContext)
        {
            this._saleContext = saleContext;
            this.entities = saleContext.Set<Entity>();
        }

        public virtual DataResult Save(Entity entity)
        {
            DataResult result = new DataResult();

            this.entities.Add(entity);

            result.Success = true;

            return result;
        }

        public virtual DataResult Update(Entity entity)
        {
            DataResult result = new DataResult();

            this.entities.Update(entity);

            result.Success = true;

            return result;
        }

        public virtual List<Entity> GetAll()
        {
            return this.entities.ToList();
        }

        public virtual List<Entity> GetEntitiesWithFilters(Func<Entity, bool> filtter)
        {
            return this.entities.Where(filtter).ToList();
        }

        public virtual Entity GetById(T id)
        {
            return this.entities.First(e => e.Id.Equals(id));
        }

        public virtual bool Exists(Func<Entity, bool> filter)
        {
            return this.entities.Any(filter);
        }

        public virtual int Commit()
        {
            return this._saleContext.SaveChanges();
        }
    }
}
