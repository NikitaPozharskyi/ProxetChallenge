
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProxNetChallenge.Repository.Interfaces
{
    public interface IRepository<TEntity, in TKey>
        where TEntity : class
    {
        Task<TEntity> GetByIdAsync(TKey id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<TEntity> Find([NotNull] Expression<Func<TEntity, bool>> predicate);

        Task<List<TEntity>> Find([NotNull] Expression<Func<TEntity, bool>> predicate, int take, int skip = 0);
        Task<List<TEntity>> FindAll([NotNull] Expression<Func<TEntity, bool>> predicate);
    }

}
