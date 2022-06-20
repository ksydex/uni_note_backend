using System.ComponentModel.DataAnnotations.Schema;
using UniNote.Core.Common.AbstractClasses;
using UniNote.Core.Localization.Interfaces;

namespace UniNote.Core.Localization.AbstractClasses;

// todo: rm T param
public abstract class LocalizedEntityBase<TR> : EntityBase, ILocalizedEntity<TR>
    where TR : Translation, new()
{
    [ForeignKey("BaseEntityId")]
    public virtual TranslationCollection<TR> Translations { get; set; } = new();
    public virtual TR? Content { get; set; }
        
    public virtual void Localize(ICulture culture)
    {
        Content = Translations[culture];
    }
    
}