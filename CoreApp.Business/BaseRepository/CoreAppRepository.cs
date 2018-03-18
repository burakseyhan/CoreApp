using CoreApp.Context;
using CoreApp.Model.Entity;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CoreApp.Business.BaseRepository
{
    public abstract class CoreAppRepository<T> : ICoreAppRepository<T>
        where T : BaseEntity
    {
        protected CoreAppDbContext _entities;
        protected readonly DbSet<T> _dbSet;

        public CoreAppRepository(CoreAppDbContext context)
        {
            _entities = context;
            _dbSet = context.Set<T>();
        }

        public T Add(T entity)
        {
            return _dbSet.Add(entity).Entity;
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Edit(T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> query = _dbSet.Where(predicate).AsEnumerable();

            return query;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.AsEnumerable<T>();
        }

        public void Save()
        {
            _entities.SaveChanges();
        }

        public T Where(Expression<Func<T, bool>> expression)
        {
            T query = _dbSet.Where(expression).FirstOrDefault();

            return query;
        }
    }
}
