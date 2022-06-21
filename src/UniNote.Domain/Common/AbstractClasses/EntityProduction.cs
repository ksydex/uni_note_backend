using UniNote.Core.Common.Interfaces;

namespace UniNote.Domain.Common.AbstractClasses;

public abstract class EntityProduction : EntityBase, IDeletable
{
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }
    
    public bool IsDeleted { get; set; }
}