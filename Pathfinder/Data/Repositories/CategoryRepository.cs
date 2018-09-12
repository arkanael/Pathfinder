using Microsoft.EntityFrameworkCore;
using Pathfinder.Data.Context;
using Pathfinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pathfinder.Data.Repositories
{
    public class CategoryRepository : BaseRepository<Category>
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context):base(context)
        {
            _context = context;
        }

        public List<Product> FindProduct(int id)
        {
            return _context.Set<Product>().Include("Product").Where(x => x.CategoryId == id).AsNoTracking().ToList();
        }
    }
}