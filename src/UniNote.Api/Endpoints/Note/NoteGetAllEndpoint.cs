using FastEndpoints;
using UniNote.Application.Dtos;
using UniNote.Application.Modules.DtoServices.NoteDtoService.Misc;

namespace UniNote.Api.Endpoints.Note;

public class NoteGetAllEndpoint : Endpoint<NoteFilter, List<NoteDto>>
{
    private readonly INoteDtoService _service;

    public NoteGetAllEndpoint(INoteDtoService service)
    {
        _service = service;
    }

    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("/note");
    }
    
    public override async Task HandleAsync(NoteFilter req, CancellationToken ct)
    {
        await SendAsync(await _service.GetAllAsync(req));
    }
}