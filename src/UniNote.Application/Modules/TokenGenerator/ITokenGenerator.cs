using UniNote.Core.Common.Interfaces;
using UniNote.Domain.Entities;

namespace UniNote.Application.Modules.TokenGenerator;

public interface ITokenGenerator : IServicePerLifeTimeScope
{
    string GenerateAccessToken(User identity);
        
    Task<RefreshToken> CreateRefreshTokenAsync(User identity);
}