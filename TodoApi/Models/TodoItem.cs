namespace TodoApi.Models
{
    interface ITodoComponents
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
    }

    public class TodoItem : ITodoComponents
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
    }

}