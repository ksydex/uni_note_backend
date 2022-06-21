using FastEndpoints;

namespace UniNote.Application.Modules.DtoServices.NoteDtoService.Misc;

public class NoteFilter
{
    
    public int? GroupId { get; set; }
    public bool IsGroupIdFilterStrict { get; set; }
}