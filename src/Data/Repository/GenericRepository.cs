using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CqrsSample.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CqrsSample.Data.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private bool _disposed;

        public GenericRepository(StudentContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        public StudentContext Context { get; }

        public DbSet<TEntity> DbSet { get; }

        public void Add(TEntity entity)
        {
            Context.SetAsAdded(entity);
        }

        public void Update(TEntity entity)
        {
            Context.SetAsModified(entity);
        }

        public void Delete(TEntity entity)
        {
            Context.SetAsDeleted(entity);
        }

        public void Delete(Expression<Func<TEntity, bool>> where)
        {
            var itemsToDelete = DbSet.Where(where);
            DbSet.RemoveRange(itemsToDelete);
        }

        public TEntity Find(object id)
        {
            return DbSet.Find(id);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> where)
        {
            return DbSet.Where(where).AsNoTracking().FirstOrDefault();
        }

        public async Task<List<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> where)
        {
            return await DbSet.Where(where).AsNoTracking().ToListAsync();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DbSet.AsNoTracking().ToList();
        }
        public async Task<List<TEntity>> GetAllAsync()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id, string[] includePaths = null)
        {
            var result = DbSet.AsQueryable();
            if (includePaths == null)
            {
                return await result.FirstOrDefaultAsync(c => c.Id == id);
            }
            result = includePaths.Aggregate(result, (current, includePath) => current.Include(includePath));
            return await result.FirstOrDefaultAsync(c => c.Id == id);
        }

        public TEntity GetById(int id, string[] includePaths = null)
        {
            var result = DbSet.AsQueryable();
            if (includePaths == null)
            {
                return result.FirstOrDefault(c => c.Id == id);
            }
            result = includePaths.Aggregate(result, (current, includePath) => current.Include(includePath));
            return result.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> where)
        {
            return DbSet.Where(where).AsNoTracking().ToList();
        }
        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> where = null)
        {
            return where == null ? DbSet.AsNoTracking().AsQueryable() : DbSet.Where(where).AsNoTracking().AsQueryable();
        }

        public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] properties)
        {
            if (properties == null)
                throw new ArgumentNullException(nameof(properties));

            var query = DbSet as IQueryable<TEntity>;

            query = properties
                       .Aggregate(query, (current, property) => current.Include(property));

            return query.Where(where).AsNoTracking().ToList();

        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] properties)
        {
            if (properties == null)
                throw new ArgumentNullException(nameof(properties));

            var query = DbSet as IQueryable<TEntity>;

            query = properties
                       .Aggregate(query, (current, property) => current.Include(property));

            if (where != null)
            {
                query = query.Where(where);
            }
            return query.AsNoTracking();
        }

        public List<TEntity> PageAll(int skip, int take)
        {
            return DbSet.Skip(skip).Take(take).AsNoTracking().ToList();
        }

        public async Task<List<TEntity>> PageAllAsync(int skip, int take)
        {
            return await DbSet.Skip(skip).Take(take).AsNoTracking().ToListAsync();
        }

        public int Count()
        {
            return DbSet.Count();
        }

        public Task<int> CountAsync()
        {
            return DbSet.CountAsync();

        }

        public int Count(Expression<Func<TEntity, bool>> where)
        {
            return DbSet.Count(where);
        }

        public Task<int> CountAsync(Expression<Func<TEntity, bool>> where)
        {
            return DbSet.CountAsync(where);
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                Context.Dispose();
            }
            _disposed = true;
        }
    }
}
