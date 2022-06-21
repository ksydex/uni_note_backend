using FastEndpoints;
using UniNote.Api.Models;
using UniNote.Application.Modules.DtoServices.GroupDtoService.Misc;

namespace UniNote.Api.Endpoints.Group;

public class GroupRemoveEndpoint : Endpoint<RemoveEndpointModel>
{
    private readonly IGroupDtoService _service;

    public GroupRemoveEndpoint(IGroupDtoService service)
    {
        _service = service;
    }

    public override void Configure()
    {
        Verbs(Http.DELETE);
        Routes(@"/group/{Id})");
    }

    public override async Task HandleAsync(RemoveEndpointModel m, CancellationToken ct)
    {
        await _service.RemoveAsync(m.Id);
        await SendAsync(new {});
    }
}