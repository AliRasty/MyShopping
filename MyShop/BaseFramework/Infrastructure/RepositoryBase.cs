

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BaseFramework.Domin;
using Microsoft.EntityFrameworkCore;

namespace BaseFramework.Infrastructure
{
    public class RepositoryBase<TKey ,T> : IRepository<TKey,T> where T : class
    {


        private readonly  DbContext _dbContext;

        public RepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public T Get(TKey id)
        {
            return _dbContext.Find<T>(id);
        }

        public List<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public void Create(T entity)
        {
            _dbContext.Add<T>(entity);
        }

        public bool Exists(Expression<Func<T, bool>> expression)
        {
            return _dbContext.Set<T>().Any(expression);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
