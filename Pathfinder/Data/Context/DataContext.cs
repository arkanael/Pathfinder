using Microsoft.EntityFrameworkCore;
using Pathfinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pathfinder.Data.Context
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"connectionstring");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration();
        }

        public DbSet<Product> products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
