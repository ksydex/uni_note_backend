using Microsoft.AspNetCore.Http;
using UniNote.Core.Common.Interfaces;
using UniNote.Core.Localization.Interfaces;
using UniNote.Data.Common;
using UniNote.Domain.Entities;

namespace UniNote.Application.Modules.AuthorizedContext.Common;

public interface IAuthorizedContext : IServicePerLifeTimeScope
{
    int UserId { get; }
}