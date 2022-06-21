using System.Collections.Specialized;
using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UniNote.Core.Common.AbstractClasses;
using UniNote.Core.Common.Interfaces;
using UniNote.Data.Extensions;
using UniNote.Domain.Entities;

namespace UniNote.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Group> Groups  => Set<Group>();
    
    public DbSet<RefreshToken> RefreshTokens  => Set<RefreshToken>();
    public DbSet<Tag> Tags => Set<Tag>();
    
    public DbSet<Note> Notes  => Set<Note>();
    public DbSet<Note2Tag> Note2Tags  => Set<Note2Tag>();
    


    private readonly IMediator _mediator;

    public AppDbContext(DbContextOptions<AppDbContext> options, IMediator mediator)
        : base(options)
    {
        _mediator = mediator;
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.UseSoftDeleteFilters();
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(AppDbContext))!);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateDates();
        var result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        await HandleDomainEventsAsync(cancellationToken);
        return result;
    }

    public override int SaveChanges()
        => SaveChangesAsync().GetAwaiter().GetResult();

    #region [ Helper methods ]

    private async Task HandleDomainEventsAsync(CancellationToken cancellationToken)
    {
        // dispatch events only if save was successful
        var entitiesWithEvents = ChangeTracker.Entries<EntityBase>()
            .Select(e => e.Entity)
            .Where(e => e.Events.Any())
            .ToArray();

        foreach (var entity in entitiesWithEvents)
        {
            var events = entity.Events.ToArray();
            entity.Events.Clear();
            foreach (var domainEvent in events)
                await _mediator.Publish(domainEvent, cancellationToken).ConfigureAwait(false);
        }
    }

    private void UpdateDates()
    {
        var utcNow = DateTime.UtcNow;

        foreach (var entry in ChangeTracker.Entries<IWithDateCreated>().Where(e => e.State == EntityState.Added && e.Entity.DateCreated == DateTime.MinValue))
            entry.Entity.DateCreated = utcNow;

        foreach (var entry in ChangeTracker.Entries<IWithDateUpdated>().Where(e => e.State == EntityState.Modified))
            entry.Entity.DateUpdated = utcNow;
        
        foreach (var entry in ChangeTracker.Entries<IWithDateUpdated>().Where(e => e.State == EntityState.Modified))
            entry.Entity.DateUpdated = utcNow;
    }

    #endregion
}