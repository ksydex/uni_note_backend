namespace UniNote.Core.Common.Interfaces;

public interface ITokenServiceBase<in TIdentity, TRefreshToken> : IServicePerLifeTimeScope
{
    string GenerateAccessToken(TIdentity identity);
        
    Task<TRefreshToken> CreateRefreshTokenAsync(TIdentity identity);
}