using App.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Repositories
{
    public class BaseRepo<TEntity> where TEntity : class
    {
        private readonly Protein4allContext DbContext;

        protected DbSet<TEntity> DbSet;
        public BaseRepo(Protein4allContext protein4AllContext)
        {
            DbContext = protein4AllContext;
            DbSet = DbContext.Set<TEntity>();
        }
        public IQueryable<TEntity> GetAll()
        {
            IQueryable<TEntity> entities = DbSet;
            return entities;
        }
        public virtual TEntity GetOne(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return GetMany(where, includeProperties).FirstOrDefault();
        }
        public virtual IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>> where = null,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = where == null
                ? DbSet
                : DbSet.Where(where);
            var entities = includeProperties.Aggregate(query, (current, includeProperty) =>
                current.Include(includeProperty));
            

            return entities;
        }
        public TEntity Get<TKey>(TKey id)
        {
            return DbSet.Find(id);
        }
        public void Add(TEntity entity)
        {
            DbContext.Set<TEntity>().Add(entity);

            Save();
        }
        public void Delete(TEntity entity)
        {
            DbContext.Set<TEntity>().Remove(entity);

            Save();
        }
        public void Save()
        {
            DbContext.SaveChanges();
        }
    }
}
