namespace UniNote.Core.Extensions;

public static class IEnumerableExtensions
{
    public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> source)
        => source.Select((item, index) => (item, index));

    public static async Task<List<TSource>> ToListAsync<TSource>(this IAsyncEnumerable<TSource> source)
    {
        var list = new List<TSource>();

        await foreach (var item in source)
        {
            list.Add(item);
        }

        return list;
    }

    public static IEnumerable<T> Without<T>(this IEnumerable<T> source, params T[] without)
        where T : IComparable
        => source.Where(x => !without.Contains(x));

    public static IEnumerable<T> AppendIfNotNull<T>(this IEnumerable<T> source, T? v)
        => v == null ? source : source.Append(v);
}