using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Imposto.Infrastructure.Repository.Repositories.Interfaces;

namespace Imposto.Infrastructure.Repository.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        protected readonly DbSet<TEntity> EntitySet;

        protected RepositoryBase(DbContext context)
        {
            Context = context;
            EntitySet = context.Set<TEntity>();
        }

        public IList<TEntity> GetAll() => EntitySet.ToList();

        public TEntity GetById(object id) => EntitySet.Find(id);

        public void Save(TEntity entity) => EntitySet.Add(entity);

        public void Update(TEntity entity)
        {
            if (!IsAttached(entity))
                EntitySet.Add(entity);
            Context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            EntitySet.Remove(entity);
            Context.SaveChanges();
        }

        protected virtual bool IsAttached(TEntity entity) => (uint) Context.Entry(entity).State > 0U;
    }
}