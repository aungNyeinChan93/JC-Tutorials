using System;
using System.Collections.Generic;
using System.Text;

namespace One.ConsoleApp1.Models
{
    public class Quotes
    {
        public List<Quote>? quotes { get; set; }
    }
    public class Quote
    {
        public int id { get; set; }
        public string? quote { get; set; }
        public string? author { get; set; }
    }
}
