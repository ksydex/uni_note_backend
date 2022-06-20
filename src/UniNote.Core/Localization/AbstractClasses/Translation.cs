using UniNote.Core.Common.AbstractClasses;
using UniNote.Core.Localization.Interfaces;
using UniNote.Core.Models;

namespace UniNote.Core.Localization.AbstractClasses;



public abstract class Translation : EntityBase, IWithCultureKey
{
    public int BaseEntityId { get; set; }
    public string CultureKey { get; set; } = "";


    public static TranslationCollection<T> From<T>(T ru, T en, T ua)
        where T : IWithCultureKey, new()
    {
        ru.CultureKey = Culture.Ru.Key;
        en.CultureKey = Culture.En.Key;
        ua.CultureKey = Culture.Ua.Key;
            
        return new TranslationCollection<T>
        {
            ru, en, ua
        };
    }
}