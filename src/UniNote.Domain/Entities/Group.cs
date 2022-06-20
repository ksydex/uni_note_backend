using UniNote.Core.Common.Interfaces;
using UniNote.Domain.Common;
using UniNote.Domain.Common.AbstractClasses;

namespace UniNote.Domain.Entities;

public class Group : EntityProductionWithUser, IWithName
{
    public string Name { get; set; } = "";
    
    public List<Note>? Notes { get; set; }
}