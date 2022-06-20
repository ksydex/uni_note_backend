namespace UniNote.Core.Extensions;

public static class ClassExtensions
{
    public static T Let<T>(this T s, Action<T> body, Func<T, bool>? exp = null)
        where T : class
    {
        if (exp != null && !exp(s)) return s;
        
        body(s);
        return s;
    }
    
    public static TR Apply<T, TR>(this T s, Func<T, TR> body)
        where T : class
        => body(s);

    public static T Apply<T>(this T s, Func<T, T> body, bool exp = true)
        where T : class
        => !exp ? s : body(s);

    public static bool Implements(this Type t, Type impl)
        => t.GetInterfaces().Any(x => x == impl);
}