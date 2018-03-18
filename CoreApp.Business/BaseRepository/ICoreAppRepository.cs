using CoreApp.Model.Entity;

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CoreApp.Business.BaseRepository
{
    public interface ICoreAppRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();

        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);

        T Where(Expression<Func<T, bool>> expression);

        T Add(T entity);

        void Edit(T entity);

        void Delete(T entity);

        void Save();
    }
}
