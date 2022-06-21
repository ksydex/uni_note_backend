using UniNote.Core.Common.Interfaces;
using UniNote.Domain.Common;
using UniNote.Domain.Common.AbstractClasses;

namespace UniNote.Domain.Entities;

public class Note : EntityProductionWithUser, IWithName
{
    public string Name { get; set; } = "";
    public string Body { get; set; } = "";

    public bool IsFavorite { get; set; }
    
    public bool IsArchived { get; set; }
    
    public Group? Group { get; set; }
    public int? GroupId { get; set; }
    
    public List<Note2Tag>? Tags { get; set; }
}