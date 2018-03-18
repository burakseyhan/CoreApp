using CoreApp.Business.BaseRepository;
using CoreApp.Context;
using CoreApp.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CoreApp.Business.CoreAppCategory
{
    internal interface ICategoryRepository : ICoreAppRepository<CategoryEntity>
    {
        List<CategoryEntity> GetCategories();
    }

    public class CategoryRepository : CoreAppRepository<CategoryEntity>, ICategoryRepository
    {
        public CategoryRepository(CoreAppDbContext context) : base(context)
        {

        }

        public List<CategoryEntity> GetCategories()
        {
            return _entities.Set<CategoryEntity>().ToList();
        }
    }
}
