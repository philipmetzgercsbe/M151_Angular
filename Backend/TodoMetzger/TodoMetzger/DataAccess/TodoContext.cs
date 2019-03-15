using Microsoft.EntityFrameworkCore;
using TodoMetzger.Models;

namespace TodoMetzger.DataAccess
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }
        
    }
}