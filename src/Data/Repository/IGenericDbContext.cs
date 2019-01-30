using System;
using System.Threading.Tasks;
using CqrsSample.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CqrsSample.Data.Repository
{
    public interface IGenericDbContext : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
        void SetAsAdded<TEntity>(TEntity entity) where TEntity : BaseEntity;
        void SetAsModified<TEntity>(TEntity entity) where TEntity : BaseEntity;
        void SetAsDeleted<TEntity>(TEntity entity) where TEntity : BaseEntity;
        int Commit();
        Task<int> CommitAsync();
    }
}
