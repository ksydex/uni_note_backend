namespace UniNote.Application.Dtos;

public record Note2TagDto
{
    public int Id { get; set; }
    
    public int TagId { get; set; }
    public TagDto? Tag { get; set; }
}