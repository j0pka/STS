using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STSerApp.Models
{
    public class TaskModel
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
    }
}
