using UniNote.Core.Common.Interfaces;

namespace UniNote.Core.Common.AbstractClasses;

public class EntityBaseWithDateCreated : EntityBase, IWithDateCreated
{
    public DateTime DateCreated { get; set; }
}