using UniNote.Domain.Common;

namespace UniNote.Domain.Entities;

public class Group : EntityProduction
{
    public string Name { get; set; } = "";
    public User? User { get; set; }
    public int UserId { get; set; }
}
