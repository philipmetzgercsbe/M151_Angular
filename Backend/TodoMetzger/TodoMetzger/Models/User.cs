using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoMetzger.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] Salt { get; set; }
        public byte[] PwHash { get; set; }
        public IEnumerable<TodoItem> TodoItems { get; set; } //Nav property for EF 
    }
}
