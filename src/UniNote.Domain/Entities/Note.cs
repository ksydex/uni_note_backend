using UniNote.Domain.Common;
using UniNote.Domain.Common.AbstractClasses;

namespace UniNote.Domain.Entities;

public class Note : EntityProductionWithUser
{
    public string Name => "Should be parsed from body";
    public string Body { get; set; } = "";

    public bool IsFavorite { get; set; }
    
    public Group? Group { get; set; }
    public int? GroupId { get; set; }
    
    public List<Note2Tag>? Tags { get; set; }
}