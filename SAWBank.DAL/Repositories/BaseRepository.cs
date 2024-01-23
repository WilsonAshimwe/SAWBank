using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAWBank.DAL.Repositories
{
    public abstract class BaseRepository<T> where T : class
    {
        private readonly DbContext _context;
        protected DbSet<T> _table;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _table= context.Set<T>();
        }
        // FindAll
        public virtual List<T> FindAll()
        {
            return _context.Set<T>().ToList();
        }

        //Find by id
        public virtual T? Find(params object[] id)
        {
            return _context.Set<T>().Find(id);
        }

        // Add
        public virtual T Add(T entity)
        {
            T inserted = _context.Set<T>().Add(entity).Entity;
            _context.SaveChanges();
            return inserted;
        }

        // void Remove()
        public virtual void Remove(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }
        // Update

        public virtual void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
