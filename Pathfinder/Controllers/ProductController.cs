using Microsoft.AspNetCore.Mvc;
using Pathfinder.Data.Repositories;
using Pathfinder.Entities;
using Pathfinder.Models.Products;
using Pathfinder.Models.Validations;
using System;
using System.Collections.Generic;

namespace Pathfinder.Controllers
{
    [Produces("application/json")]
    [Route("v1")]
    public class ProductController : Controller
    {
        private readonly ProductRepository repository;

        public ProductController(ProductRepository repository)
        {
            this.repository = repository;
        }

        //[Route("v1/products/")]
        [HttpGet("products")]
        public IEnumerable<ProductFindViewModel> Get()
        {

            List<ProductFindViewModel> lista = new List<ProductFindViewModel>();

            foreach (Product product in repository.FindAll())
            {
                ProductFindViewModel model = new ProductFindViewModel();
                model.Id = product.Id;
                model.Title = product.Title;
                model.Price = product.Price;
                model.Category = product.Category.Title;
                model.CategoryId = product.CategoryId;
                lista.Add(model);
            }

            return lista;

            //return repository.FindAll().Include(p => p.Category).Select(p => new ProductFindViewModel
            //{
            //    Id = p.Id,
            //    Title = p.Title,
            //    Price = p.Price,
            //    Category = p.Category.Title,
            //    CategoryId = p.CategoryId

            //}).AsNoTracking().ToList();
        }

        //[Route("v1/products/{id}")]
        [HttpGet("products/{id}")]
        public Product Get(int id)
        {
            return repository.Find(id);
        }

        //[Route("v1/products")]
        [HttpPost("products")]
        public ResultViewModel Post([FromBody]ProductCreateViewModel model)
        {
            model.Validate();
            if (model.Invalid)
            {
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possivel cadastrar o produto",
                    Data = model.Notifications

                };
            }

            var product = new Product();
            product.Title = model.Title;
            product.CategoryId = model.CategoryId;
            product.CreateDate = DateTime.Now;
            product.Description = model.Description;
            product.Image = model.Image;
            product.LastUpdateDate = DateTime.Now;
            product.Price = model.Price;
            product.Quantity = model.Quantity;

           repository.Insert(product);

            return new ResultViewModel
            {
                Success = true,
                Message = "Produto cadastrado com sucesso",
                Data = product
            };
        }

        //[Route("v1/products")]
        [HttpPut("products")]
        public ResultViewModel Put([FromBody]ProductUpdateViewModel model)
        {
            model.Validate();
            if (model.Invalid)
            {
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possivel cadastrar o produto",
                    Data = model.Notifications

                };
            }

            Product product = repository.Find(model.Id);

            product.Title = model.Title;
            product.CategoryId = model.CategoryId;
            product.Description = model.Description;
            product.Image = model.Image;
            product.LastUpdateDate = DateTime.Now;
            product.Price = model.Price;
            product.Quantity = model.Quantity;

            repository.Update(product);

            return new ResultViewModel
            {
                Success = true,
                Message = "Produto alterado com sucesso",
                Data = product
            };
        }
    }
}