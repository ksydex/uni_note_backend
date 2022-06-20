using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Metadata;
using UniNote.Core.Common.Interfaces;

namespace UniNote.Data.Extensions;

public static class SoftDeleteQueryExtension
{
    public static void AddSingleSoftDeleteQueryFilter(
        this IMutableEntityType entityData)
    {
        var methodToCall = typeof(SoftDeleteQueryExtension)
            .GetMethod(nameof(GetSoftDeleteFilter),
                BindingFlags.NonPublic | BindingFlags.Static)!
            .MakeGenericMethod(entityData.ClrType);
        var filter = methodToCall.Invoke(null, new object[] { });
        entityData.SetQueryFilter((LambdaExpression)filter!);
        entityData.AddIndex(entityData.FindProperty(nameof(IDeletable.IsDeleted))!);
    }

    private static LambdaExpression GetSoftDeleteFilter<TEntity>()
        where TEntity : class, IDeletable
    {
        Expression<Func<TEntity, bool>> filter = x => !x.IsDeleted;
        return filter;
    }
}