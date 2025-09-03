namespace RanjaKen.Api.Model
{
    public class ApiResponse<T>
    {
        public bool? Success { get; set; }
        public int? Code { get; set; }
        public string? Message { get; set; }
        public Meta? Meta { get; set; }
        public T? Data { get; set; }
    }
    public class Meta
    {
        public int? TotalPage { get; set; }
        public long? Total { get; set; }
        public int? Page { get; set; }
        public int? Limit { get; set; }
    }
}
