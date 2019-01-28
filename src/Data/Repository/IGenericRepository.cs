using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CqrsSample.Data.Entities;

namespace CqrsSample.Data.Repository
{
    public interface IGenericRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(Expression<Func<TEntity, bool>> where);
        TEntity Find(object id);
        TEntity Get(Expression<Func<TEntity, bool>> where);
        IEnumerable<TEntity> GetAll();
        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> where);
        Task<TEntity> GetByIdAsync(int id, string[] includePaths = null);
        IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> where);
        List<TEntity> PageAll(int skip, int take);
        Task<List<TEntity>> PageAllAsync(int skip, int take);
        int Count();
        Task<int> CountAsync();
        int Count(Expression<Func<TEntity, bool>> where);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> where);
        StudentContext Context { get; }

    }
}
