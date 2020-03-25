using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Lab.Management.Engine.Reporsitory.Generic
{

    public abstract class GenericRepository<C, T>
  where T : class where C : DbContext, new()
    {
        public C Context
        {
            get => Entities;
            set => Entities = value;
        }

        public C Entities { get; set; } = new C();

        public virtual IQueryable<T> GetAll()
        {
            IQueryable<T> query = Entities.Set<T>();
            return query;
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = Entities.Set<T>().Where(predicate);
            return query;
        }

        public virtual void Add(T entity)
        {
            Entities.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            Entities.Set<T>().Remove(entity);
            Entities.SaveChanges();
        }

        public virtual void Edit(T entity)
        {
            Entities.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            Entities.SaveChanges();
        }
    }
}
