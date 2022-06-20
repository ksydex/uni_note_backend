namespace UniNote.Core.Helpers;

public class AppSettings
{
    public const string Key = "AppSettings";

    public string SelfHostUrl { get; set; } = "";
    public string WebAppUrl { get; set; } = "";
    public string SecretKey { get; set; } = "";
    public string Environment { get; set; } = "";

    public bool IsDebugMode { get; set; } = true;

    public static AppSettings Singleton = null!;
}