using UniNote.Core.Common.Interfaces;
using UniNote.Domain.Common;
using UniNote.Domain.Common.AbstractClasses;

namespace UniNote.Domain.Entities;

public class User : EntityProduction, IWithName
{
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public string PasswordHashed { get; set; } = "";
    
    public List<Group>? Groups { get; set; }
    public List<Note>? Notes { get; set; }
}
