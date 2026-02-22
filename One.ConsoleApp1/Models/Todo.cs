using System;
using System.Collections.Generic;
using System.Text;

namespace One.ConsoleApp1.Models
{

    public class Todos
    {
        public Todo[]? todos { get; set; }
       
    }

    public class Todo
    {
        public int id { get; set; }
        public string? todo { get; set; }
        public bool completed { get; set; }
        public int? userId { get; set; }
    }

}
