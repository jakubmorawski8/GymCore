namespace GymCore.Application.Requests
{
    public class QueryParameters
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public string SortField { get; set; }
        public string SortDirection { get; set; }
    }
}
