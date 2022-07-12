using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private List<TodoItem> database = new List<TodoItem>()
        {
            new TodoItem() { Id = 1, Name="Alice", IsComplete=true},
            new TodoItem() { Id = 2, Name="Bobby", IsComplete=false},
            new TodoItem() { Id = 3, Name="Tony", IsComplete=false},
            new TodoItem() { Id = 4, Name="Johny", IsComplete=true},
            new TodoItem() { Id = 5, Name="Morgan", IsComplete=false},
        };

        #region Test playground

        //Test Get method
        [HttpGet("[action]")]
        public ActionResult<List<TodoItem>> TestGet(string? test = "test")
        {
            return Ok(test);
        }

        //Test Post method
        [HttpPost("[action]")]
        public ActionResult<List<TodoItem>> TestPost(TodoItem todos, int id = 99,
            string? name = "Toby")
        {
            if(todos.Id != id) return BadRequest();
            var tempObject = new TodoItem()
            {
                Id = todos.Id,
                Name = todos.Name==null? name: todos.Name,
                IsComplete = todos.IsComplete
            };
            database.Add(tempObject);
            return database;
        }
        #endregion

        #region Get all todos or by id

        //Get all todo lists
        [HttpGet("[action]")]
        public ActionResult<List<TodoItem>> GetTodoItem()
       {
           return Ok(database);
       }

        //Get todo list(s) by require Id
        [HttpGet("[action]/{id}")]
        public ActionResult<List<TodoItem>> GetTodoItem(int id)
        {
            var result = new List<TodoItem>();
            foreach(var item in database)
            {
                if(item.Id==id) result.Add(item);
            }
            return Ok(result);
        }

        //Get todo list(s) with/without Id
        [HttpGet("[action]/{id?}")]
        public ActionResult<List<TodoItem>> GetTodoItem2(int? id)
        {
            if(id == null) return Ok(database);
            var result = new List<TodoItem>();
            foreach (var item in database)
            {
                if (item.Id == id) result.Add(item);
            }
            return Ok(result);
        }

        //Get todo list(s) by require Id as integer type
        [HttpGet("[action]/{id:int}")]
        public ActionResult<List<TodoItem>> GetTodoItemByReqIntId(int id)
        {
            return Ok(database);
        }

        //Get todo list(s) with/without Id as integer type
        [HttpGet("[action]/{id:int?}")]
        public ActionResult<List<TodoItem>> GetTodoItemByNotReqIntId(int? id)
        {
            return Ok(database);
        }
        #endregion

        #region Get: Show todo using query string params

        //Get todo list using query string parameter(s)
        [HttpGet("[action]")]
        public ActionResult GetTodoByQueryParam(int? id, string? name)
        {
            return Ok(id + ":" + name);
        }

        //Get todo list using object
        [HttpGet("[action]")]
        public ActionResult GetTodoByQueryParamObject(TodoItem todo)
        {
            var tempTodo = new TodoItem();
            //tempTodo = todo.GetValue();
            return Ok(todo.Id + ":" + todo.Name);
        }

        //Get todo list using properties
        [HttpGet("[action]")]
        public ActionResult GetTodoByQueryParamProperty()
        {
            var tempTodo = new TodoItem();
            //tempTodo = todo.GetValue();
            return Ok();
        }
        #endregion

        #region Post: Adding new todos and test body content
      
        //Insert todo
        [HttpPost("[action]")]
        public IActionResult AddTodoItem(TodoItem todoItem)
        {
            database.Add(todoItem);
            return Ok(database);
        }
        #endregion

        #region Post: Optional parameters
        //Insert todo with default data
        [HttpPost("[action]")]
        public ActionResult<List<TodoItem>> AddTodoItemWithParam(TodoItem todos, int id = 99, string? name = "Toby")
        {
            if (todos.Id != id) return BadRequest();
            var tempObject = new TodoItem()
            {
                Id = todos.Id,
                Name = todos.Name == null ? name : todos.Name,
                IsComplete = todos.IsComplete
            };
            database.Add(tempObject);
            return database;
        }
        #endregion

        #region Put: Update todo data

        //Update data entire row
        [HttpPut("[action]/{id}")]
        public ActionResult<List<TodoItem>> PutTodoItem(int id, TodoItem todoItem)
        {
            if (id != todoItem.Id) return BadRequest(); //RFC able to create new data if does not exist
            DeleteTodoItem(id);
            database.Add(todoItem);

            return Ok(database);
        }
        #endregion

        #region Delete: todo item
        
        //Delete todo item by id
        [HttpDelete("[action]/{id}")]
        public ActionResult<List<TodoItem>> DeleteTodoItem(int id)
        {
            var todoItem = database.Find(todos => todos.Id == id);
            if (todoItem == null)
            {
                return NotFound();
            }
            database.Remove(todoItem);
            return Ok(database);
        }
        #endregion

        #region Patch: Update specifically
        
        //Update specific data
        [HttpPatch("[action]/{id}")]
        public ActionResult<List<TodoItem>> UpdateSpecificData(int id,TodoItem updateTodos)
        {
            if(id != updateTodos.Id) return BadRequest();
            var currentTodos = database.Find(todos => todos.Id == id);
            if (currentTodos == null) return BadRequest();

            var result = new TodoItem(); //Compare current data and updated data
            
            result.Id = id;
            result.Name = updateTodos.Name == null ? currentTodos.Name : updateTodos.Name;
            result.IsComplete = updateTodos.IsComplete;

            DeleteTodoItem(id);
            database.Add(result);

            return Ok(database);
        }
        #endregion

    }
}
