namespace UniNote.Core.Common.Classes;

public class PagingOptions
{
    public PagingOptions()
    {
        Normalize();
    }

    private int _page;

    public int Page
    {
        get => _page;
        set => _page = value <= 0 ? 1 : value;
    }

    private int _pageSize;

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value <= 0 ? 10 : value;
    }

    private string _orderBy = OrderByTypes.Fallback;

    public string OrderBy { get; set; } = OrderByTypes.DateCreated;

        
    private string _order = OrderTypes.Fallback;
    public string Order { get; set; } = OrderTypes.Desc;

    public void Normalize()
    {
        if (Page == 0) Page = 0;
        if (PageSize == 0) PageSize = 0;
    }

    public static class OrderTypes
    {
        public const string Asc = "asc";
        public const string Desc = "desc";

        public static string Fallback => Desc;

        public static readonly IReadOnlyList<string> All = new[]
        {
            Asc,
            Desc
        };
    }

    public static class OrderByTypes
    {
        public const string DateCreated = "date_created";
        public const string Name = "name";

        public static string Fallback => DateCreated;

        public static readonly IReadOnlyList<string> All = new[]
        {
            DateCreated,
            Name
        };
    }
}