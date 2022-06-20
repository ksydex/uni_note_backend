namespace UniNote.Domain.Common.AbstractClasses;

public abstract class EntityProduction : EntityBase
{
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }
    
    public bool IsDeleted { get; set; }
}