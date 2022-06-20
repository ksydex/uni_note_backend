using System.Linq.Expressions;
using UniNote.Core.Common.Classes;
using UniNote.Core.Common.Interfaces;

namespace UniNote.Core.Extensions;

public static class PageExtensions
{
    public static IQueryable<TSource> Page<TSource>(this IQueryable<TSource> source, int page, int pageSize)
        => source.Skip((page - 1) * pageSize).Take(pageSize);
    
    public static IEnumerable<TSource> Page<TSource>(this IEnumerable<TSource> source, int page, int pageSize)
        => source.Skip((page - 1) * pageSize).Take(pageSize);

    public static IQueryable<TSource> Page<TSource>(this IQueryable<TSource> source, int? page, int? pageSize,
        string? orderByDate)
        where TSource : IWithId<int> => source.Page(new PagingOptions
    {
        Page = page ?? 1, PageSize = pageSize ?? 10
    });

    public static IQueryable<TSource> Page<TSource>(this IQueryable<TSource> source, PagingOptions config,
        Expression<Func<TSource, object>>? orderByExpression = null)
        where TSource : IWithId<int>
    {
        orderByExpression ??= config.OrderBy switch
        {
            PagingOptions.OrderByTypes.Name when typeof(TSource).Implements(typeof(IWithNameNullable))
                => x => ((IWithNameNullable)x).Name!,
            PagingOptions.OrderByTypes.Name when typeof(TSource).Implements(typeof(IWithName))
                => x => ((IWithName)x).Name,
            _ => x => x.Id
        };

        source = config.Order switch
        {
            PagingOptions.OrderTypes.Asc => source.OrderBy(orderByExpression),
            _ => source.OrderByDescending(orderByExpression)
        };

        return config.Page == default ? source : source.Page(config.Page, config.PageSize);
    }
}