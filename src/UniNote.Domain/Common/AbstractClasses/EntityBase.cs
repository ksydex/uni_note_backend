using System.ComponentModel.DataAnnotations;
using UniNote.Core.Common.AbstractClasses;
using UniNote.Core.Common.Interfaces;
using UniNote.Core.Enums;

namespace UniNote.Domain.Common.AbstractClasses;

public abstract class EntityBase : IEntity
{
    [Key] public int Id { get; set; }
    
    public List<DomainEventBase> Events { get; set; } = new();
    public ActionTypes? ActionType { get; set; }
}