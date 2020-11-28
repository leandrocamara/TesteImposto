using System.Collections.Generic;

namespace Imposto.Infrastructure.Repository.Repositories.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        IList<TEntity> GetAll();
        TEntity GetById(object id);
        void Save(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}