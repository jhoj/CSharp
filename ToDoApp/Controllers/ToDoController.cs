using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using ToDoApp.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoApp.Controllers
{
    [Route("api/[controller]")]
    public class ToDoController : Controller
    {
        [FromServices]
        public IToDoItemRepository ToDoItems { get; set; }

        // GET: /api/todo

        [HttpGet]
        public IEnumerable<ToDoItem> GetAll()
        {
            return ToDoItems.GetAll();
        }

        // GET: /api/todo/id

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(string id)
        {
            var item = ToDoItems.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ToDoItem item)
        {
            if (item == null)
            {
                return HttpBadRequest();
            }
            ToDoItems.Add(item);
            return CreatedAtRoute("GetTodo", new { controller = "Todo", id = item.Key }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] ToDoItem item)
        {
            if (item == null || item.Key != id)
            {
                return HttpBadRequest();
            }
            var todo = ToDoItems.Find(id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            ToDoItems.Update(item);
            return new NoContentResult();
        }


    }   
}
