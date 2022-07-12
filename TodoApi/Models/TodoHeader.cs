namespace TodoApi.Models
{
    public class TodoHeader : TodoItem
    {
        public string? Topic { get; set; }
        public int Priority { get; set; }
    }
}
