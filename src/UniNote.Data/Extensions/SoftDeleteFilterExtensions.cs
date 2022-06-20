using Microsoft.EntityFrameworkCore;
using UniNote.Core.Common.Interfaces;

namespace UniNote.Data.Extensions;

public static class SoftDeleteFilterExtensions
{
    public static ModelBuilder UseSoftDeleteFilters(this ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(IDeletable).IsAssignableFrom(entityType.ClrType))
            {
                entityType.AddSingleSoftDeleteQueryFilter();
            }
        }

        return modelBuilder;
    }
}