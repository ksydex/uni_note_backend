using UniNote.Core.Common.Interfaces;

namespace UniNote.Application.Common.Interfaces;

public interface IDtoService<TDto, TFilter> : IServicePerLifeTimeScope
{
    Task<TDto> AddAsync(TDto dto);
    Task<TDto> UpdateAsync(TDto dto);
    Task<List<TDto>> GetAllAsync(TFilter f);
    Task<TDto> GetByIdAsync(int id);
    Task RemoveAsync(int id);
}