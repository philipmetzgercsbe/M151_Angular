﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoMetzger.Models
{
    public class Task
    {
        public long id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
