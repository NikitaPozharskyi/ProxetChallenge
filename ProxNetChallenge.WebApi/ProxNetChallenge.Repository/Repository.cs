using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProxNetChallenge.Repository.Interfaces;

namespace ProxNetChallenge.Repository
{
    public class Repository<TContext, TEntity, TKey> : IRepository<TEntity, TKey>
    where TEntity : class
    where TContext : Context
    {

        protected readonly DbSet<TEntity> DbSet;
        protected TContext DbContext { get; }

        protected Repository(TContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<TEntity>();
        }

        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            var entity = await DbSet.FindAsync(id);
            return entity;
        }

        public async Task AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            DbSet.Update(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            DbSet.Remove(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = await DbSet.FirstOrDefaultAsync(predicate);
            return entity;
        }

        public async Task<List<TEntity>> FindAll(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = await DbSet.Where(predicate).ToListAsync();
            return entities;
        }

    }
}
