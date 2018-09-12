using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pathfinder.Data.Context;
using Pathfinder.Data.Repositories;
using Pathfinder.Entities;
using Pathfinder.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pathfinder.Controllers
{
    [Produces("application/json")]
    [Route("v1")]
    public class CategoryController : Controller
    {
        private readonly CategoryRepository repository;

        public CategoryController(CategoryRepository repository)
        {
            this.repository = repository;
        }


        [HttpGet("categories")]
        [ResponseCache(Location = ResponseCacheLocation.Client, Duration = 5)]
        public IEnumerable<Category> Get()
        {
            return repository.FindAll();
        }

        [HttpGet("categories/{id}")]
        public Category Get(int id)
        {
            return repository.Find(id);
        }

        [HttpGet("v1/categories/{id}/produtcs")]
        public IEnumerable<Product> GetProducts(int id)
        {
            return repository.FindProduct(id);
        }

        [HttpPost("categories")]
        public IActionResult Post([FromBody] CategoryCreateViewModel model)
        {
            var category = new Category();

            category.Title = model.Title;

            repository.Insert(category);          
            
            return new ObjectResult(HttpStatusCode.OK + " categoria cadastrado com sucesso");
        }

        [HttpPut("categories")]
        public IActionResult Put([FromBody] CategoryUpdateViewModel model)
        {
            var category = new Category();

            category.Id = model.Id;
            category.Title = model.Title;

            repository.Update(category);

            return new ObjectResult($"Status: {HttpStatusCode.OK} - categoria atualizada com sucesso");
        }

        [HttpDelete("categories")]
        public IActionResult Delete([FromBody] CategoryFindViewModel model)
        {
            var category = repository.Find(model.Id);

            repository.Delete(category);

            return new ObjectResult($"Status: {HttpStatusCode.OK} - categoria deletada com sucesso");

        }
    }
}
