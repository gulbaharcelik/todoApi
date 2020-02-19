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

        public TodoController(todo_dbContext context){
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> GetTodos()
        {
            var allTodoLidt = _context.Todo.ToList();
            return allTodoLidt;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> Get(int id)
        {
            return null;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(Todo todo)
        {
            return 0;
        }

        [HttpPatch]
        public async Task<ActionResult<int>> Update(Todo todo)
        {
            return 0;
        }

        [HttpDelete("id")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            return 0;
        }
    }
}