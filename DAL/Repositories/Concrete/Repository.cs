using DAL.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Concrete
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext _dbContext;
        private DbSet<TEntity> _dbSet;
        public Repository(DbContext dbContext) {
            _dbContext = dbContext;
            _dbSet=_dbContext.Set<TEntity>();
        }

        public void Add(TEntity entities)
        {
            _dbSet.Add(entities);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Remove(int id)
        {
             _dbSet.Remove(GetById(id));
        }

        public void Update(TEntity entities)
        {
            _dbSet.Update(entities);
        }
    }
}
