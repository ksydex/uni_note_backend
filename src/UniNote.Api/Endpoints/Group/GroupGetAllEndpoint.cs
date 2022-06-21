using FastEndpoints;
using UniNote.Application.Dtos;
using UniNote.Application.Modules.DtoServices.GroupDtoService.Misc;

namespace UniNote.Api.Endpoints.Group;

public class GroupGetAllEndpoint : EndpointWithoutRequest<List<GroupDto>>
{
    private readonly IGroupDtoService _service;

    public GroupGetAllEndpoint(IGroupDtoService service)
    {
        _service = service;
    }

    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("/Group");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var req = new GroupFilter
        {
            GroupId = int.TryParse(HttpContext.Request.Query["GroupId"], out var v) ? v : null,
            IsGroupIdFilterStrict = bool.TryParse(HttpContext.Request.Query["IsGroupIdFilterStrict"], out var vv) && vv,
        };
        await SendAsync(await _service.GetAllAsync(req));
    }
}