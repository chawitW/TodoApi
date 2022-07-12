namespace TodoApi.Models
{
    public sealed class TodoDetail : TodoItem
    {
        public string? CreatedDate { get; set; }
        public List<string>? SubList { get; set; }
        public bool IsFavorite { get; set; }
        public string? Detail { get; set; }
    }

}
