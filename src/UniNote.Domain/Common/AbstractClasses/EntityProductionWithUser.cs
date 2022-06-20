using UniNote.Domain.Common.Interfaces;
using UniNote.Domain.Entities;

namespace UniNote.Domain.Common.AbstractClasses;

public class EntityProductionWithUser : EntityProduction, IWithCreatedByUser
{
    public int? CreatedByUserId { get; set; }
    public User? CreatedByUser { get; set; }
    
    public int? DeletedByUserId { get; set; }
    public User? DeletedByUser { get; set; }
}