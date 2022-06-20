namespace UniNote.Core.Constants;

public static class StaticFileTypes
{
    public const string File = "file"; // файл
    public const string Image = "image"; // картинка

    public static List<string> All => new()
    {
        File,
        Image
    };
}