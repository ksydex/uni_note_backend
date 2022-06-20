namespace UniNote.Core.Common.Classes;

public class PagingModel<TDto>
{
    public PagingOptions PagingOptions { get; set; } = null!;
    public int TotalItems { get; set; }
    public int TotalPages => (int)Math.Ceiling((double)TotalItems / PagingOptions.PageSize);
    public List<TDto> Items { get; set; } = new();
}