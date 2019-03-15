using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using TodoMetzger.Models;
using MTask = TodoMetzger.Models.Task;

namespace TodoMetzger.Models
{
    public class TodoItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsFinished { get; set; } //bool starts with is, has or can
        public string Priority { get; set; }
        public User User { get; set; }
    }
}
