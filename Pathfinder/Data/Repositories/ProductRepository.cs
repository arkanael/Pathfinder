using Microsoft.EntityFrameworkCore;
using Pathfinder.Data.Context;
using Pathfinder.Entities;
using Pathfinder.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pathfinder.Data.Repositories
{
    public class ProductRepository:BaseRepository<Product>
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context):base(context)
        {
            _context = context;
        }

        public override List<Product> FindAll()
        {
            return _context.Set<Product>().Include("Category").AsNoTracking().ToList();

        }
    }
}

