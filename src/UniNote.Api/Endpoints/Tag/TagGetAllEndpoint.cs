using FastEndpoints;
using UniNote.Application.Dtos;
using UniNote.Application.Modules.DtoServices.TagDtoService.Misc;

namespace UniNote.Api.Endpoints.Tag;

public class TagGetAllEndpoint : EndpointWithoutRequest<List<TagDto>>
{
    private readonly ITagDtoService _service;

    public TagGetAllEndpoint(ITagDtoService service)
    {
        _service = service;
    }

    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("/tag");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var req = new TagFilter
        {
            Name = HttpContext.Request.Query["Name"].FirstOrDefault(),
        };
        await SendAsync(await _service.GetAllAsync(req));
    }
}