namespace StockApp.Helper
{
    public class QueryObject
    {
        // filtering
        public string? Symbol { get; set; }
        public string? CompanyName { get; set; }

        // sorting
        public string? SortBy { get; set; } = null;
        public bool IsDescending { get; set; } = false;

        // pagination
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

    }
}
