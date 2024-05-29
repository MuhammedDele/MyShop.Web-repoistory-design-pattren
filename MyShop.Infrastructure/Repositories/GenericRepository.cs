using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Infrastructure.Repositories
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        protected ShoppingContext _context;
        protected DbSet<T> _table=null;
        protected GenericRepository(ShoppingContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }
        public virtual T Add(T entity)
        {
            return _table.Add(entity).Entity;
        }

        public virtual IEnumerable<T> All()
        {
            return _table.ToList();
        }

        public virtual T Get(int id)
        {
            return _context.Find<T>(id);
        }

        //public void SaveChanges()
        //{
        //     _context.SaveChanges();
        //}

        public virtual T Update(T entity)
        {
            return _context.Update(entity).Entity;
        }
        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> filter)
        {
            return _table.Where(filter).ToList();
        }
    }
}
