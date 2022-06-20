using UniNote.Domain.Common;

namespace UniNote.Domain.Entities;

public class Note : EntityProduction
{
    public string Name { get; set; } = "";
    public string Body { get; set; } = "";
    
    public User? User { get; set; }
    public int UserId { get; set; }
    
    public bool IsFavorite { get; set; }
    
    public Group? Group { get; set; }
    public int? GroupId { get; set; }
}