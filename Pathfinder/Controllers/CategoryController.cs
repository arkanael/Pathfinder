using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pathfinder.Data.Context;
using Pathfinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pathfinder.Controllers
{
    public class CategoryController : Controller
    {
        private readonly DataContext _dataContext;

        public CategoryController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [Route("v1/categories")]
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _dataContext.Categories.AsNoTracking().ToList();
        }

        [Route("v1/categories/{id}")]
        [HttpGet]
        public Category Get(int id)
        {
            return _dataContext.Categories.AsNoTracking().Where(c => c.Id == id).FirstOrDefault();
        }

        [Route("v1/categories/{id}/produtcs")]
        [HttpGet]
        public IEnumerable<Product> GetProducts(int id)
        {
            return _dataContext.Products.AsNoTracking().Where(c => c.CategoryId == id).ToList();
        }

        [Route("v1/categories")]
        [HttpPost]
        public Category Post([FromBody] Category category)
        {
            _dataContext.Categories.Add(category);
            _dataContext.SaveChanges();

            return category;
        }

        [Route("v1/categories")]
        [HttpPost]
        public Category Put([FromBody] Category category)
        {
            _dataContext.Entry<Category>(category).State = EntityState.Modified;
            _dataContext.SaveChanges();

            return category;
        }

        [Route("v1/categories")]
        [HttpPost]
        public Category Delete([FromBody] Category category)
        {
            _dataContext.Categories.Remove(category);
            _dataContext.SaveChanges();

            return category;
        }
    }
}
