using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using UniNote.Core.Common.Interfaces;

namespace UniNote.Data.Common;

public interface IRepository : IServicePerLifeTimeScope
{
    IQueryable<T> Queryable<T>(IRepositorySpec<T>? spec = null) where T : class, IEntity;
    Task<T> AddAsync<T>(T e) where T : notnull;
    Task<T> AddAndSaveChangesAsync<T>(T e) where T : notnull;
    Task AddRangeAndSaveChangesAsync<T>(IEnumerable<T> entities) where T : class;
    Task RemoveAndSaveChangesAsync<T>(T e) where T : notnull;
    EntityEntry<T> Entry<T>(T e) where T : class;

    Task RemoveRangeAndSaveChangesAsync<T>(IEnumerable<T> e) where T : notnull;
    Task SaveChangesAsync();

    Task<IDbContextTransaction> BeginTransactionAsync();
    IDbContextTransaction? CurrentTransaction { get; }
}