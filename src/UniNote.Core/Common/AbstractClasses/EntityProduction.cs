using UniNote.Core.Common.Interfaces;

namespace UniNote.Core.Common.AbstractClasses;

public abstract class EntityProduction : EntityBaseWithDateCreated, IDeletable, IWithDateUpdated
{
    public DateTime? DateUpdated { get; set; }
    public bool IsDeleted { get; set; }
    
    public DateTime? DateDeletedAt { get; set; }
}