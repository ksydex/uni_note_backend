using FastEndpoints;
using UniNote.Application.Dtos;

namespace UniNote.Api.Endpoints.Note;

public class NoteCreateEndpoint : Endpoint<NoteDto, NoteDto>
{
    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("/note");
    }
    
    public override async Task HandleAsync(NoteDto req, CancellationToken ct)
    {
        await SendAsync(new NoteDto());
    }
}