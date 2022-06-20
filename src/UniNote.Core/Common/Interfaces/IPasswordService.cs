namespace UniNote.Core.Common.Interfaces;

public interface IPasswordService<in TIdentity>
{
    public string HashPassword(TIdentity identity, string password);

    public bool VerifyHashedPassword(TIdentity identity, string hashedPassword,
        string providedPassword);
}