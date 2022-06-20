using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UniNote.Application.Common.Interfaces;
using UniNote.Application.Modules.AuthorizedContext.Common;
using UniNote.Core.Common.AbstractClasses;
using UniNote.Core.Common.Interfaces;
using UniNote.Core.Exceptions;
using UniNote.Core.Extensions;
using UniNote.Data.Common;

namespace UniNote.Application.Common.AbstractClasses;

public abstract class DtoServiceBase<T, TDto, TFilter> : IDtoService<TDto, TFilter>
    where T : class, IEntity, new()
    where TFilter: class
{
    protected readonly IAuthorizedContext AuthorizedContext;  
    protected readonly IRepository Repository;
    protected readonly IMapper Mapper;

    public DtoServiceBase(IRepository repository, IMapper mapper, IAuthorizedContext authorizedContext)
    {
        Repository = repository;
        Mapper = mapper;
        AuthorizedContext = authorizedContext;
    }

    public abstract void Map(T dao, TDto dto);
    public virtual IQueryable<T> Queryable(IQueryable<T> q, TFilter? f) => q;

    public async Task<TDto> AddAsync(TDto dto)
    {
        var dao = new T();
        Map(dao, dto);
        await Repository.AddAndSaveChangesAsync(dao);
        return Mapper.Map<TDto>(dao);
    }

    public async Task<List<TDto>> GetAll(TFilter filter)
    {
        var q = Queryable(Repository.Queryable<T>(), filter);
        return Mapper.Map<List<TDto>>(await q.AsNoTracking().ToListAsync());
    }

    public async Task<TDto> GetById(int id)
    {
        var q = Queryable(Repository.Queryable<T>(), null);
        var e = await q.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);

        return Mapper.Map<TDto>(e) ?? throw new NotFoundException();
    }


    public async Task RemoveAsync(int id)
    {
        var e = await Repository.Queryable<T>().SingleOrDefaultAsync(x => x.Id == id);
        if (e == null) throw new NotFoundException();
        
        await Repository.RemoveAndSaveChangesAsync(e);
    }
    
    protected static void Merge<T2, TDto2>(List<T2> daoList, List<TDto2> dtoList, Action<T2, TDto2> updateStrategy,
        Func<TDto2, T2> addStrategy, Func<T2, TDto2, bool> equalsFunc, Func<TDto2, bool> isDtoNewFunc,
        bool toRemove = true)
        where T2 : IWithId<int>
        => daoList.Merge(dtoList, updateStrategy, addStrategy, equalsFunc, isDtoNewFunc, toRemove);
}