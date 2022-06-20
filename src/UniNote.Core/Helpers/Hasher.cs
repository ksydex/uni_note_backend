using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace UniNote.Core.Helpers;

public static class Hasher
{
    private const int SaltSize = 16; // 128 bit 
    private const int KeySize = 32; // 256 bit

    private const int Iterations = 10000;

    public static string RemoveSpecialCharacters(string str) =>
        Regex.Replace(str, "[^a-zA-Z0-9]+", "", RegexOptions.Compiled);

    public static string RandomToken(int length = 64, bool removeSpecialCharacters = false)
    {
        var randomNumber = new byte[length];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        var hash = Convert.ToBase64String(randomNumber);
            
        if (removeSpecialCharacters)
            hash = RemoveSpecialCharacters(hash);
            
        return hash.Substring(0, length);
    }

    public static string Hash(string value)
    {
        using var algorithm = new Rfc2898DeriveBytes(
            value,
            SaltSize,
            Iterations,
            HashAlgorithmName.SHA512);
        var key = Convert.ToBase64String(algorithm.GetBytes(KeySize));
        var salt = Convert.ToBase64String(algorithm.Salt);

        return $"{Iterations}.{salt}.{key}";
    }

    public static bool Verify(string hash, string providedValue)
    {
        var parts = hash.Split('.', 3);

        if (parts.Length != 3) return false;


        var iterations = Convert.ToInt32(parts[0]);
        var salt = Convert.FromBase64String(parts[1]);
        var key = Convert.FromBase64String(parts[2]);

        using var algorithm = new Rfc2898DeriveBytes(
            providedValue,
            salt,
            iterations,
            HashAlgorithmName.SHA512);
        var keyToCheck = algorithm.GetBytes(KeySize);

        return keyToCheck.SequenceEqual(key);
    }
}