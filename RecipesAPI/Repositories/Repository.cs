using Microsoft.EntityFrameworkCore;
using RecipesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;



namespace RecipesAPI.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseModel, new()
    {
        private readonly DbContext context;
        private DbSet<TEntity> _entities;

        public Repository(DbContext context)
        {
            this.context = context;
        }

        private DbSet<TEntity> Entities
        {
            get { return _entities ?? (_entities = context.Set<TEntity>()); }
        }

        public async Task DeleteAsync(string id)
        {
            TEntity entity = new TEntity { Id = id };
            Entities.Attach(entity);
            await DeleteAsync(entity);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            Entities.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<TEntity> GetAsync(string id)
        {
            return await Entities.FindAsync(id);
        }

        public async Task<TEntity> GetAsyncWithInclude(string id, Expression<Func<TEntity, object>>[] includes)
        {
            includes.ToList().ForEach(x => Entities.Include(x).Load());
            return await Entities.FindAsync(id);
        }

        public IList<TEntity> GetAll()
        {
            return Entities.ToList();
        }

        public IList<TEntity> GetAllWithInclude(params Expression<Func<TEntity, object>>[] includes)
        {
            includes.ToList().ForEach(x => Entities.Include(x).Load());
            return Entities.ToList();
        }

        public async Task<string> InsertAsync(TEntity entity)
        {
            Entities.Add(entity);
            await context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<string> UpdateAsync(TEntity entity)
        {
            Entities.Update(entity);
            await context.SaveChangesAsync();
            return entity.Id;
        }

        public IList<TEntity> Search(Expression<Func<TEntity, bool>> where)
        {
            return Entities.Where(where).ToList();
        }

        public IList<TEntity> SearchWithInclude(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes)
        {
            includes.ToList().ForEach(x => Entities.Include(x).Load());
            return Entities.Where(where).ToList();
        }
    }

}
