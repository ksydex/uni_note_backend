namespace UniNote.Core.Extensions;

public static class IntExtensions
{
    public static string GetBits(this int v)
        => Convert.ToString(v, 2);

    public static bool IsBitSet(string v, int i)
        => v.Length > i && v[i] == '1';
}