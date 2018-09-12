using Microsoft.EntityFrameworkCore;
using Pathfinder.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pathfinder.Data.Repositories
{
    public abstract class BaseRepository<TEntity> where TEntity : class
    {
        private readonly DataContext _context;

        protected BaseRepository(DataContext context)
        {
            _context = context;
        }

        public void Insert(TEntity entity)
        {            
            _context.Entry(entity).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public virtual List<TEntity> FindAll()
        {
            return _context.Set<TEntity>().AsNoTracking().ToList();
        }

        public TEntity Find(int id)
        {
            return _context.Set<TEntity>().Find(id);
            //return _context.Set<TEntity>.AsNoTracking().Where(c => c.Id == id).FirstOrDefault();
        }
    }
}
