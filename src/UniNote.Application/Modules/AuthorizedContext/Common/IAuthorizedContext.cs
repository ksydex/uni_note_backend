using UniNote.Core.Common.Interfaces;

namespace UniNote.Application.Modules.AuthorizedContext.Common;

public interface IAuthorizedContext : IServicePerLifeTimeScope
{
    int UserId { get; }
}