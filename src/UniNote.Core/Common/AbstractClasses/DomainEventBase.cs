using MediatR;

namespace UniNote.Core.Common.AbstractClasses;

public abstract class DomainEventBase : INotification
{
    public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
}