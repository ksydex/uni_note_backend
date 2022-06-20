using UniNote.Core.Common.AbstractClasses;
using UniNote.Core.Enums;

namespace UniNote.Core.Common.Interfaces;

public interface IEntity : IWithId<int>
{
    List<DomainEventBase> Events { get; set; }
    public ActionTypes? ActionType { get; set; }
}