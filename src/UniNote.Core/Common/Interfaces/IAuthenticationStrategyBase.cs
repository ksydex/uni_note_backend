namespace UniNote.Core.Common.Interfaces;

public interface IAuthenticationStrategyBase<TIdentity, in TModel>
{
    Task<TIdentity?> VerifyIdentityAsync(TModel model);
}