using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private List<TodoHeader> dbHeader = new List<TodoHeader>()
        {

        };

        private List<TodoDetail> dbDetail = new List<TodoDetail>()
        {
            new TodoDetail() {
                Id = 1,
                Name = "Steven",
                IsComplete = false,
                CreatedDate = DateTime.Now.ToString("dd-MM-yyyy HH:mm"),
                SubList = new List<string>()
                {   
                    "Hi", 
                    "Hello", 
                    "Hey"
                },
                IsFavorite = true,
                Detail = "Lorem ipsum dolor sit amet, consectetur adipiscing elit."
            },
            new TodoDetail() {
                Id = 2,
                Name = "Aaron",
                IsComplete = false,
                CreatedDate = DateTime.Now.AddDays(-1).ToString("dd-MM-yyyy HH:mm"),
                SubList = new List<string>()
                {
                    "Hi",
                    "Hello",
                    "Hey"
                },
                IsFavorite = true,
                Detail = "Lorem ipsum dolor sit amet, consectetur adipiscing elit."
            },
            new TodoDetail() {
                Id = 3,
                Name = "Antony",
                IsComplete = false,
                CreatedDate = DateTime.Now.AddDays(-2).ToString("dd-MM-yyyy HH:mm"),
                SubList = new List<string>()
                {
                    "Hi",
                    "Hello",
                    "Hey"
                },
                IsFavorite = true,
                Detail = "Lorem ipsum dolor sit amet, consectetur adipiscing elit."
            },
        };

        private List<TodoItem> dbItem = new List<TodoItem>()
        {
            new TodoItem() { Id = 1, Name="Alice", IsComplete = true },
        };

        [HttpGet("[action]")]
        public List<TodoDetail> GetTest()
        {
            return dbDetail;
        }
    }
}
