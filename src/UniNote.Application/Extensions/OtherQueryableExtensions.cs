using Microsoft.EntityFrameworkCore;
using UniNote.Core.Common.Interfaces;
using UniNote.Core.Extensions;

namespace UniNote.Application.Extensions;

public static class OtherQueryableExtensions
{
    public static IQueryable<T> WhereName<T>(this IQueryable<T> q, string v) where T : IWithName
            => q.Where(x => EF.Functions.ILike(x.Name, v.ToPattern()));
}