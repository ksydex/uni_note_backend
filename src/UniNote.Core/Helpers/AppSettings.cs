namespace UniNote.Core.Helpers;

public class AppSettings
{
    public const string Key = "AppSettings";

    public string GithubToken { get; set; } = "";
    public string GithubWebRepoBranch { get; set; } = "test";

    public string SelfHostUrl { get; set; } = "";
    public string WebAppUrl { get; set; } = "";
    public string SecretKey { get; set; } = "";
    public string CannySecretKey { get; set; } = "";
    public string HangfireUserName { get; set; } = "";
    public string HangfirePassword { get; set; } = "";
    public string EmailSenderSmtp { get; set; } = "";
    public string EmailSenderLogin { get; set; } = "";
    public string EmailSenderPassword { get; set; } = "";
    public string EmailSenderName { get; set; } = "";

    public string Environment { get; set; } = "";

    public string OnlinePbxSecret { get; set; } = "";
    public string OnlinePbxDomain { get; set; } = "";

    public bool IsDebugMode { get; set; } = true;

    public static AppSettings Singleton = null!;
}