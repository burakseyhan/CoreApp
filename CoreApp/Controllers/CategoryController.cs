using System;
using System.Collections.Generic;
using System.Linq;

using CoreApp.Business.CoreAppCategory;
using CoreApp.Context;
using CoreApp.Model.Entity;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreApp.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private CoreAppDbContext context;
        private readonly CategoryRepository categoryRepository;
        private IMemoryCache cache;

        public CategoryController(CoreAppDbContext context, IMemoryCache cache)
        {
            this.cache = cache;
            this.context = context;
            categoryRepository = new CategoryRepository(this.context);
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<CategoryEntity> Get()
        {
            return this.categoryRepository.GetCategories().Where(x => x.DeleteTime == null);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            CategoryEntity entity = this.categoryRepository.Where(x => x.Id == id);

            if (entity == null)
            {
                return NotFound();
            }

            return new ObjectResult(entity);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]CategoryEntity item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            CategoryEntity entity = new CategoryEntity();

            entity.Name = item.Name;
            entity.InsertTime = DateTime.Now;

            this.categoryRepository.Add(entity);
            this.categoryRepository.Save();

            return new NoContentResult();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]CategoryEntity item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            CategoryEntity entity = this.categoryRepository.Where(x => x.Id == id);

            if (entity == null)
            {
                return NotFound();
            }

            entity.Name = item.Name;
            entity.UpdateTime = DateTime.Now;

            this.categoryRepository.Edit(entity);
            this.categoryRepository.Save();

            return new NoContentResult();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            CategoryEntity item = this.categoryRepository.Where(x => x.Id == id);

            if (item == null)
            {
                return BadRequest();
            }

            this.categoryRepository.Edit(item);

            this.categoryRepository.Save();

            return new NoContentResult();
        }
    }
}
