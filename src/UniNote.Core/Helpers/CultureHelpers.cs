using System.Globalization;

namespace UniNote.Core.Helpers;

public static class CultureHelpers
{
    public static void SetCurrentCulture(string cultureKey)
    {
        var cultureInfo = new CultureInfo(cultureKey);
        CultureInfo.CurrentCulture = cultureInfo;
        CultureInfo.CurrentUICulture = cultureInfo;
    }
}