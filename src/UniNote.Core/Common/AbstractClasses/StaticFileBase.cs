using UniNote.Core.Common.Classes;

namespace UniNote.Core.Common.AbstractClasses;

public class StaticFileBase : EntityBase
{
    public const string Folder = "static";

    public int CdnServerId { get; set; }
    public CdnServer? CdnServer { get; set; }

    
    public string Url => (CdnServer?.Domain ?? throw new Exception("CdnServer should be attached")) + Path;
    
    public string Path { get; set; } = "";

    public string FileName { get; set; } = "";
    
    public long Length { get; set; }
}