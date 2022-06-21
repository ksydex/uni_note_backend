namespace UniNote.Application.Modules.DtoServices.GroupDtoService.Misc;

public class GroupFilter
{
    public string? Name { get; set; }
    public int? GroupId { get; set; }
    public bool IsGroupIdFilterStrict { get; set; }
}