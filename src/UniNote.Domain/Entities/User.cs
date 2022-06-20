using UniNote.Domain.Common;

namespace UniNote.Domain.Entities;

public class User : EntityProduction
{
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public string PasswordHashed { get; set; } = "";
    
    public List<Group>? Groups { get; set; }
    public List<Note>? Notes { get; set; }
}