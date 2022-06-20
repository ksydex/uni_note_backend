using System.Collections.ObjectModel;
using UniNote.Core.Extensions;
using UniNote.Core.Localization.Interfaces;

namespace UniNote.Core.Localization.AbstractClasses;

public class TranslationCollection<TR> : Collection<TR>
    where TR : IWithCultureKey, new()
{
    public TR? this[ICulture culture]
    {
        get => this.FirstOrDefault(x => x.CultureKey == culture.Key)
               ?? this.FirstOrDefault();
        set
        {
            var translation = this.FirstOrDefault(x => x.CultureKey == culture.Key);
            if (translation != null)
                Remove(translation);

            if (value == null) return;

            value.CultureKey = culture.Key;
            Add(value);
        }
    }

    public static TranslationCollection<TR> From(List<TR> list)
        => new TranslationCollection<TR>()
            .Let(x => list.ForEach(x.Add));
}