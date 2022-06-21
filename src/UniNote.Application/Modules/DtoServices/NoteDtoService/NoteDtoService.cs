using System.Text.Json;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UniNote.Application.Common.AbstractClasses;
using UniNote.Application.Dtos;
using UniNote.Application.Extensions;
using UniNote.Application.Modules.AuthorizedContext.Common;
using UniNote.Application.Modules.DtoServices.NoteDtoService.Misc;
using UniNote.Core.Extensions;
using UniNote.Data.Common;
using UniNote.Domain.Entities;

namespace UniNote.Application.Modules.DtoServices.NoteDtoService;

public record QuillNode
{
    public string insert { get; set; } = "";
}

public class NoteDtoService : DtoServiceBase<Note, NoteDto, NoteFilter>, INoteDtoService
{
    public NoteDtoService(IRepository repository, IMapper mapper, IAuthorizedContext authorizedContext) : base(
        repository, mapper, authorizedContext)
    {
    }

    public override int IdFromDto(NoteDto dto)
        => dto.Id;

    public override void Map(Note dao, NoteDto dto)
    {
        var bodyParsed = JsonSerializer.Deserialize<List<QuillNode>>(dto.Body);

        dao.Name = bodyParsed?.FirstOrDefault(x => x.insert != "")?.insert ?? "Документ";
        dao.Body = dto.Body; 
        dao.GroupId = dto.GroupId;
        dao.IsFavorite = dto.IsFavorite;
        dao.IsArchived = dto.IsArchived;

        if (dto.Tags != null)
        {
            dao.Tags ??= new List<Note2Tag>();

            Merge(dao.Tags, dto.Tags, (_, _) => { }, x => new Note2Tag
            {
                TagId = x.TagId
            }, (x, y) => x.Id == y.Id, x => x.Id == 0);
        }
    }

    public override IQueryable<Note> Queryable(IQueryable<Note> q, NoteFilter? f)
    {
        if (f != null)
            q = q.WhereNext(f.GroupId, f.IsGroupIdFilterStrict ? x => x.GroupId == f.GroupId!.Value : x => true)
                .WhereNext(f.Name, qq => qq.WhereName(f.Name!))
                .WhereNext(f.IsFavorite, x => x.IsFavorite == f.IsFavorite)
                .WhereNext(f.IsArchived, x => x.IsArchived == f.IsArchived);

        return q.Where(x => x.CreatedByUserId == AuthorizedContext.UserId)
            .Include(x => x.Tags!).ThenInclude(x => x.Tag).AsSplitQuery();
    }
}