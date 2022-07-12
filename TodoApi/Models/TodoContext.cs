namespace TodoApi.Models
{
    public class TodoContext
    {
        private readonly List<TodoItem>? _items;

        public TodoContext()
        {
            _items = new List<TodoItem>();
        }
    }

}