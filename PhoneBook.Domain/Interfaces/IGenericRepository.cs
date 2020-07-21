using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PhoneBook.Domain.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "");

        TEntity GetByID(Object id);

        void Insert(TEntity entity);

        void Delete(object id);

        void Delete(TEntity entityToDelete);

        void Update(TEntity entityToUpdate);
        void Save();
    }
}
