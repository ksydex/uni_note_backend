using FastEndpoints;
using UniNote.Application.Dtos;
using UniNote.Application.Modules.DtoServices.NoteDtoService.Misc;

namespace UniNote.Api.Endpoints.Note;

public class NoteGetAllEndpoint : EndpointWithoutRequest<List<NoteDto>>
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

    public override async Task HandleAsync(CancellationToken ct)
    {
        var req = new NoteFilter
        {
            GroupId = int.TryParse(HttpContext.Request.Query["GroupId"], out var v) ? v : null,
            IsGroupIdFilterStrict = bool.TryParse(HttpContext.Request.Query["IsGroupIdFilterStrict"], out var vv) && vv,
            Name = HttpContext.Request.Query["Name"].FirstOrDefault(),
        };
        await SendAsync(await _service.GetAllAsync(req));
    }
}