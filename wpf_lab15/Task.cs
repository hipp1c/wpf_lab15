using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_lab15
{
    public class Task
    {
        public string? Name { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public bool IsDoing { get; set; }

        public Task() { }

        public Task(string? name, DateTime date, string? description)
        {
            Name = name;
            Date = date;
            Description = description;
            IsDoing = false;
        }

        public override string ToString()
        {
            char c = IsDoing ? '✔' : '✖';
            return $"{c} {Name}\n\n{Description}\n\n{Date.Date}\n\n\n";
        }
    }
}