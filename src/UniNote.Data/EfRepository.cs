using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using SoftDeleteServices.Concrete;
using UniNote.Core.Common.Interfaces;
using UniNote.Data.Common;

namespace UniNote.Data;

public class EfRepository : IRepository
{
    private readonly SingleSoftDeleteServiceAsync<IDeletable> _softDeleteService;
    protected readonly DbContext DbContext;

    public EfRepository(DbContext dbContext, SingleSoftDeleteServiceAsync<IDeletable> softDeleteService)
    {
        DbContext = dbContext;
        _softDeleteService = softDeleteService;
    }

    public IQueryable<T> Queryable<T>(IRepositorySpec<T>? spec = null) where T : class, IEntity
        => spec == null ? DbContext.Set<T>() : spec.GetQueryable(DbContext.Set<T>());

    public async Task<T> AddAsync<T>(T e) where T : notnull
    {
        await DbContext.AddAsync(e);
        return e;
    }

    public async Task<T> AddAndSaveChangesAsync<T>(T e) where T : notnull
    {
        await AddAsync(e);
        await SaveChangesAsync();
        return e;
    }

    public async Task AddRangeAndSaveChangesAsync<T>(IEnumerable<T> entities)
        where T : class
    {
        await DbContext.Set<T>().AddRangeAsync(entities);
        await SaveChangesAsync();
    }

    public async Task RemoveAndSaveChangesAsync<T>(T e) where T : notnull
    {
        await RemoveWithoutSaveChangesAsync(e);
        await SaveChangesAsync();
    }

    public EntityEntry<T> Entry<T>(T e) where T : class
        => DbContext.Entry(e);

    public async Task RemoveRangeAndSaveChangesAsync<T>(IEnumerable<T> e) where T : notnull
    {
        await RemoveRangeWithoutSaveChangesAsync(e);
        await SaveChangesAsync();
    }

    public Task SaveChangesAsync()
        => DbContext.SaveChangesAsync();

    public Task<IDbContextTransaction> BeginTransactionAsync()
        => DbContext.Database.BeginTransactionAsync();

    public IDbContextTransaction? CurrentTransaction => DbContext.Database.CurrentTransaction;


    #region [ Helpers ]

    public async Task RemoveWithoutSaveChangesAsync<TT>(TT e)
        where TT : notnull
    {
        if (e is IDeletable v) await _softDeleteService.SetSoftDeleteAsync(v);
        else DbContext.Remove(e);
    }

    public async Task RemoveRangeWithoutSaveChangesAsync<TT>(IEnumerable<TT> items)
        where TT : notnull
    {
        foreach (var e in items)
            await RemoveWithoutSaveChangesAsync(e);
    }

    #endregion
}