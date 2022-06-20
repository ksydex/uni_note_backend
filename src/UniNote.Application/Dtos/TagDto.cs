namespace UniNote.Application.Dtos;

public record TagDto
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string ColorHex { get; set; } = "";
}
