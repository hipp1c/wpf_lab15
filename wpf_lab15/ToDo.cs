using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_lab15
{
    public class ToDo
    {
        public string? Name { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }

        public ToDo() { }

        public ToDo(string? name, DateTime date, string? description)
        {
            Name = name;
            Date = date;
            Description = description;
        }
    }
}
