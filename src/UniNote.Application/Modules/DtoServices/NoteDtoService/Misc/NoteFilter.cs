namespace UniNote.Application.Modules.DtoServices.NoteDtoService.Misc;

public class NoteFilter
{
    public string? Name { get; set; }
    public int? GroupId { get; set; }
    public bool IsGroupIdFilterStrict { get; set; }
    public bool? IsArchived { get; set; }
    public bool? IsFavorite { get; set; }
}