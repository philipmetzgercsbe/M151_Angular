using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using TodoMetzger.DataAccess;
using TodoMetzger.Models;
using Task = System.Threading.Tasks.Task;


namespace TodoMetzger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;

            if (_context.TodoItems.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.TodoItems.Add(new TodoItem { Name = "Test", Description = "Test", EndDate = DateTime.Parse("13.1.1970"),IsFinished = false, Priority = "low"});
                _context.SaveChanges();
            }
            
        }
        // GET: api/Todo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
            return await _context.TodoItems.ToListAsync();
        }
        //GET: api/Todo/id
        /*[HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetUserTodoItem(User user)
        {
            var result = _context.TodoItems.Where(r => r.User == user).ToListAsync();
            return await result;
        }*/

        // GET: api/Todo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        //POST: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoItem>> DeleteTodoItem(long id)
        {
            var item = await _context.TodoItems.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            
            _context.TodoItems.Remove(item);
            await _context.SaveChangesAsync();
           

            return NoContent();

        }
        // POST: api/Todo
        [HttpPost]
        public async Task<ActionResult<TodoItem>> CreateTodoItem(TodoItem todo)
        {
            _context.TodoItems.Add(todo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodoItem", new { id = todo.Id }, todo);
        }

        // PUT: api/Todo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodoItem(long id, TodoItem todo)
        {
            if (id != todo.Id)
            {
                return NotFound();
            }

            _context.Entry(todo).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateException )
            {
                return BadRequest();
            }
            

            return Ok();
        }
    }
}