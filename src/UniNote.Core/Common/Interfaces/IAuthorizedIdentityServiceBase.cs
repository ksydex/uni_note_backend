namespace UniNote.Core.Common.Interfaces;

public interface IAuthorizedIdentityServiceBase
{
    bool IsAuthenticated { get; }
}