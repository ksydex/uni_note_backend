using FastEndpoints;
using UniNote.Application.Dtos;
using UniNote.Application.Modules.DtoServices.GroupDtoService.Misc;

namespace UniNote.Api.Endpoints.Group;

public class GroupAddEndpoint : Endpoint<GroupDto, GroupDto>
{
    private readonly IGroupDtoService _service;

    public GroupAddEndpoint(IGroupDtoService service)
    {
        _service = service;
    }

    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("/group");
    }
    
    public override async Task HandleAsync(GroupDto req, CancellationToken ct)
    {
        await SendAsync(await _service.AddAsync(req));
    }
}