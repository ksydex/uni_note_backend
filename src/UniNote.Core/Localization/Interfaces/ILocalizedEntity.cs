using UniNote.Core.Common.Interfaces;
using UniNote.Core.Localization.AbstractClasses;

namespace UniNote.Core.Localization.Interfaces;

public interface ILocalizedEntity<TR> : ILocalizable, IWithId<int>
    where TR : Translation, new()
{
    TranslationCollection<TR> Translations { get; set; }
    TR? Content { get; set; }
}