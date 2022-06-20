using UniNote.Core.Common.AbstractClasses;

namespace UniNote.Domain.Entities;

public class Note2Tag : EntityBase
{
    public int NoteId { get; set; }
    public Note? Note { get; set; }
    
    public int TagId { get; set; }
    public Tag? Tag { get; set; }
}