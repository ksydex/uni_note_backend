using FastEndpoints;
using UniNote.Application.Dtos;
using UniNote.Application.Modules.DtoServices.NoteDtoService.Misc;

namespace UniNote.Api.Endpoints.Note;

public class NoteGetByIdEndpoint : EndpointWithoutRequest<NoteDto>
{
    private readonly INoteDtoService _service;

    public NoteGetByIdEndpoint(INoteDtoService service)
    {
        _service = service;
    }

    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("/note/{Id}");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var r = await _service.GetByIdAsync(int.Parse(HttpContext.GetRouteValue("Id")!.ToString()!));
        await SendAsync(r);
    }
}