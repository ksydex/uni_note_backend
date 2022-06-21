using FastEndpoints;
using UniNote.Application.Dtos;
using UniNote.Application.Modules.DtoServices.TagDtoService.Misc;

namespace UniNote.Api.Endpoints.Tag;

public class TagAddEndpoint : Endpoint<TagDto, TagDto>
{
    private readonly ITagDtoService _service;

    public TagAddEndpoint(ITagDtoService service)
    {
        _service = service;
    }

    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("/tag");
    }
    
    public override async Task HandleAsync(TagDto req, CancellationToken ct)
    {
        await SendAsync(await _service.AddAsync(req));
    }
}