using App.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}
