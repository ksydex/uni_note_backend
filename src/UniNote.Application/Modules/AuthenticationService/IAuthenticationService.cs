using UniNote.Application.Modules.AuthenticationService.Models;
using UniNote.Core.Common.Interfaces;

namespace UniNote.Application.Modules.AuthenticationService;

public interface IAuthenticationService : IServicePerLifeTimeScope
{
    Task<InitialData> AuthenticateWithCredentials(string email, string password);
    Task<InitialData> AuthenticateWithRefreshToken(string refreshToken);
    Task SignUpAsync(string email, string password, string name);
}