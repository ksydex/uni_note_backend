using UniNote.Core.Common.Interfaces;

namespace UniNote.Core.Models;

public record AutocompleteModel : IWithId<int>
{
    public int Id { get; set; }
    public string? Text { get; set; } = "";
}