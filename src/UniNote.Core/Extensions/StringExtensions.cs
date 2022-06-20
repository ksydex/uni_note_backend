using System.Text.RegularExpressions;

namespace UniNote.Core.Extensions;

public static class StringExtensions
{
    public static bool IsOneOf(this string v, IEnumerable<string> list, bool ignoreCase = false)
        => list.Contains(v, ignoreCase ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal);

    public static string FirstCharToUpper(this string input) =>
        input switch
        {
            null => throw new ArgumentNullException(nameof(input)),
            "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
            _ => input.First().ToString().ToUpper() + input[1..]
        };

    public static string ToPattern(this string? str)
        => $"%{str}%";

    public static string ToPatternNoSpaces(this string str)
        => $"%{Regex.Replace(str, @"\s+", "")}%";
}