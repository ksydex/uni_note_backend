using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UniNote.Application.Common.AbstractClasses;
using UniNote.Application.Dtos;
using UniNote.Application.Extensions;
using UniNote.Application.Modules.AuthorizedContext.Common;
using UniNote.Application.Modules.DtoServices.TagDtoService.Misc;
using UniNote.Core.Extensions;
using UniNote.Data.Common;
using UniNote.Domain.Entities;

namespace UniNote.Application.Modules.DtoServices.TagDtoService;

public class TagDtoService : DtoServiceBase<Tag, TagDto, TagFilter>, ITagDtoService
{
    public TagDtoService(IRepository repository, IMapper mapper, IAuthorizedContext authorizedContext) : base(
        repository, mapper, authorizedContext)
    {
    }

    public override void Map(Tag dao, TagDto dto)
    {
        dao.Name = dto.Name;
        dto.ColorHex = dto.ColorHex;
    }

    public override IQueryable<Tag> Queryable(IQueryable<Tag> q, TagFilter? f)
    {
        if (f != null)
            q = q.WhereNext(f.Name, qq => qq.WhereName(f.Name!));

        return q.Where(x => x.CreatedByUserId == AuthorizedContext.UserId);
    }
}