using UniNote.Core.Common.Classes;

namespace UniNote.Core.Common.Interfaces;

public interface IRepositorySpec<T>
    where T : IEntity
{
    public IQueryable<T> GetQueryable(IQueryable<T> q);

    public void Reset();
}

public abstract class RepositorySpecification<T> : IRepositorySpec<T>
    where T : class, IEntity
{
    protected QueryBuilder<T> Query = new();

    public IQueryable<T> GetQueryable(IQueryable<T> q)
        => Query.GetQuery(q);

    public void Reset()
        => Query.Reset();
}