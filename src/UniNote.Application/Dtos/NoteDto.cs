namespace UniNote.Application.Dtos;

public record NoteDto
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Body { get; set; } = "";

    public bool IsFavorite { get; set; }
    
    public int? GroupId { get; set; }
    
    public List<Note2TagDto>? Tags { get; set; }
}