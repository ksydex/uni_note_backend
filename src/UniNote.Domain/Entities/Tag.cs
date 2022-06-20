using UniNote.Core.Common.Interfaces;
using UniNote.Domain.Common;
using UniNote.Domain.Common.AbstractClasses;

namespace UniNote.Domain.Entities;

public class Tag : EntityProduction, IWithName
{
    public string Name { get; set; } = "";
    public string ColorHex { get; set; } = "";
}