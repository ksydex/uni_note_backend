using UniNote.Core.Common.Interfaces;

namespace UniNote.Application.Common.Interfaces;

public interface IDtoService<TDto, TFilter> : IServicePerLifeTimeScope
{
    Task<TDto> AddAsync(TDto dto);
    Task<List<TDto>> GetAll(TFilter f);
    Task<TDto> GetById(int id);
    Task RemoveAsync(int id);
}