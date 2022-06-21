using FastEndpoints;
using UniNote.Application.Dtos;
using UniNote.Application.Modules.DtoServices.NoteDtoService.Misc;

namespace UniNote.Api.Endpoints.Note;


public class NoteUpdateEndpoint : Endpoint<NoteDto, NoteDto>
{
    private readonly INoteDtoService _service;

    public NoteUpdateEndpoint(INoteDtoService service)
    {
        _service = service;
    }

    public override void Configure()
    {
        Verbs(Http.PUT);
        Routes("/note");
    }
    
    public override async Task HandleAsync(NoteDto req, CancellationToken ct)
    {
        await SendAsync(await _service.UpdateAsync(req));
    }
}