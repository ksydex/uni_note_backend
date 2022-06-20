using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniNote.Core.Common.Interfaces;
using UniNote.Core.Enums;

namespace UniNote.Core.Common.AbstractClasses;

public abstract class EntityBase : IEntity
{
    [Key] public int Id { get; set; }

    [NotMapped] public List<DomainEventBase> Events { get; set; } = new();
    [NotMapped] public ActionTypes? ActionType { get; set; }
}