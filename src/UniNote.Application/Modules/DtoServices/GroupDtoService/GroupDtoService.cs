using AutoMapper;
using UniNote.Application.Common.AbstractClasses;
using UniNote.Application.Dtos;
using UniNote.Application.Extensions;
using UniNote.Application.Modules.AuthorizedContext.Common;
using UniNote.Application.Modules.DtoServices.GroupDtoService.Misc;
using UniNote.Core.Extensions;
using UniNote.Data.Common;
using UniNote.Domain.Entities;

namespace UniNote.Application.Modules.DtoServices.GroupDtoService;

public class GroupDtoService : DtoServiceBase<Group, GroupDto, GroupFilter>, IGroupDtoService
{
    public GroupDtoService(IRepository repository, IMapper mapper, IAuthorizedContext authorizedContext) : base(
        repository, mapper, authorizedContext)
    {
    }

    public override void Map(Group dao, GroupDto dto)
    {
        dao.Name = dto.Name;
        dao.GroupId = dto.GroupId;
    }

    public override IQueryable<Group> Queryable(IQueryable<Group> q, GroupFilter? f)
    {
        if (f != null)
            q = q.WhereNext(f.GroupId, f.IsGroupIdFilterStrict ? x => x.GroupId == f.GroupId!.Value : x => true)
                .WhereNext(f.Name, qq => qq.WhereName(f.Name!));;

        return q.Where(x => x.CreatedByUserId == AuthorizedContext.UserId);
    }
}