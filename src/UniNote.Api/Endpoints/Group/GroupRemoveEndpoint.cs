using FastEndpoints;
using UniNote.Api.Models;
using UniNote.Application.Dtos;
using UniNote.Application.Modules.DtoServices.GroupDtoService.Misc;
using UniNote.Application.Modules.DtoServices.NoteDtoService.Misc;

namespace UniNote.Api.Endpoints.Group;

public class GroupRemoveEndpoint : EndpointWithoutRequest
{
    private readonly IGroupDtoService _service;

    public GroupRemoveEndpoint(IGroupDtoService service)
    {
        _service = service;
    }

    public override void Configure()
    {
        Verbs(Http.DELETE);
        Routes("/group/{Id}");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await _service.RemoveAsync(int.Parse(HttpContext.GetRouteValue("Id")!.ToString()!));
        await SendAsync(new {});
    }
}
