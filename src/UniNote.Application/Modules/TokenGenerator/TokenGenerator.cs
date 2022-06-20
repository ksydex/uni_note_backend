using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using UniNote.Core.Common.Interfaces;
using UniNote.Core.Helpers;
using UniNote.Data.Common;
using UniNote.Domain.Common;
using UniNote.Domain.Entities;

namespace UniNote.Application.Modules.TokenGenerator;

public class TokenGenerator : ITokenGenerator
{
    private readonly AppSettings _appSettings;
    private readonly IRepository _repository;

    public TokenGenerator(IRepository repository, IOptions<AppSettings> appSettings)
    {
        _repository = repository;
        _appSettings = appSettings.Value;
    }

    public string GenerateAccessToken(User identity)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = GenerateTokenDescriptor(identity);
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public async Task<RefreshToken> CreateRefreshTokenAsync(User identity)
    {
        var nonHashedRefreshToken = Hasher.RandomToken();
        var utcNow = DateTime.UtcNow;
        var refreshToken = new RefreshToken(Hasher.Hash(nonHashedRefreshToken))
        {
            UserId = identity.Id,
            DateCreated = utcNow,
            DateExpiration = utcNow.AddDays(15),
        };
        
        await _repository.AddAndSaveChangesAsync(refreshToken);
        return new RefreshToken(nonHashedRefreshToken)
        {
            Id = refreshToken.Id,
            DateCreated = refreshToken.DateCreated,
            DateExpiration = refreshToken.DateExpiration,
            UserId = refreshToken.UserId
        };
    }

    private SecurityTokenDescriptor GenerateTokenDescriptor(IEntity identity)
    {
        var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = GenerateClaimsIdentity(identity),
            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        return tokenDescriptor;
    }

    private static ClaimsIdentity GenerateClaimsIdentity(IEntity identity)
    {
        
        var claims = new ClaimsIdentity(new Claim[]
        {
            new(ClaimTypes.Name, identity.Id.ToString()),
        }, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        
        return claims;
    }
}