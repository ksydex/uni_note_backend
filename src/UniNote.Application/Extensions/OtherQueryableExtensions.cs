using System.Linq;
using UniNote.Core.Common.Interfaces;

namespace UniNote.Core.Extensions;

public class OtherQueryableExtensions
{
    public static IQueryable<T> WhereName<T>(this IQueryable<T> q, string v) where T : IWithName
            => q.Where(x => EF.Functions.ILike(x.Name, v.ToPattern()));
}