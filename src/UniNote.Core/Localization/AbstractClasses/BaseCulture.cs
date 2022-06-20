using UniNote.Core.Localization.Interfaces;

namespace UniNote.Core.Localization.AbstractClasses;

public class BaseCulture : ICulture
{
    public string Key { get; set; } = "";
    public string Name { get; set; } = "";
}