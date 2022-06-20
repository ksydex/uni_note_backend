using System.ComponentModel.DataAnnotations;

namespace UniNote.Domain.Common;

public abstract class EntityBase
{
    [Key] public int Id { get; set; }
}

public abstract class EntityProduction : EntityBase
{
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }
    
    public bool IsDeleted { get; set; }
}