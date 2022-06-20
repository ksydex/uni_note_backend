using UniNote.Core.Localization.Interfaces;
using UniNote.Core.Models;

namespace UniNote.Core.Localization.Extensions;

public static class LocalizationExtension
{
    public static List<T> SelectLocalize<T>(this List<T> collection, ICulture culture)
        where T : ILocalizable
    {
        collection.Localize(culture);
        return collection;
    }

    public static void Localize<T>(this List<T> collection, ICulture culture)
        where T : ILocalizable
        => collection.ForEach(x => x.Localize(culture));
        
    public static T SelectLocalize<T>(this T e, ICulture culture)
        where T : ILocalizable
    {
        e.Localize(culture);
        return e;
    }
        
    public static T SelectLocalize<T>(this T e, string key)
        where T : ILocalizable
    {
        var culture = Culture.All.FirstOrDefault(x => x.Key == key);
        if (culture == null) return e;
        e.Localize(culture);
        return e;
    }
}