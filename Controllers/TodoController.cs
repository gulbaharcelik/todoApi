using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly todo_dbContext _context;

        public TodoController(todo_dbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> GetTodos()
        {
            var allTodoList = _context.Todo.Where(todo => todo.Status > 0).ToList();
            return allTodoList;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> Get(int id)
        {
            var todo = _context.Todo.Where(item => item.Id == id).FirstOrDefault();
            return todo;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(Todo todo)
        {
            if (todo != null)
            {
                _context.Add(todo);
                return _context.SaveChanges();
            }
            return 0;
        }

        [HttpPatch]
        public async Task<ActionResult<int>> Update(Todo todo)
        {
            var itemToUpdate = _context.Todo.Where(item => item.Id == todo.Id).FirstOrDefault();
            if (itemToUpdate != null)
            {
                itemToUpdate.Status = todo.Status;
                itemToUpdate.Text = todo.Text;

                return _context.SaveChanges();
            }
            return 0;
        }

        [HttpDelete("id")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            var itemToDelete = _context.Todo.Where(item => item.Id == id).FirstOrDefault();
            
            if(itemToDelete != null){
                _context.Todo.Remove(itemToDelete);
                return _context.SaveChanges();
            }

            return 0;
        }
    }
}