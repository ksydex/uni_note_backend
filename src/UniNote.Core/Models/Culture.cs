using UniNote.Core.Localization.AbstractClasses;

namespace UniNote.Core.Models;

public class Culture : BaseCulture
{
    public static readonly Culture En = new() { Key = Keys.En, Name = "English" };
    public static readonly Culture Ru = new() { Key = Keys.Ru, Name = "Русский" };
    public static readonly Culture Ua = new() { Key = Keys.Ua, Name = "Український" };

    public static readonly List<Culture> All = new() { En, Ru, Ua };
        
    public static Culture Fallback => En;

    public static class Keys
    {
        public const string Ru = "ru";
        public const string En = "en";
        public const string Ua = "ua";
    }
}