using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STSerApp.Models
{
    public class TaskModel
    {
        public string Name { get; set; } // Название задачи
        public string Description { get; set; } // Описание задачи
        public DateTime StartDate { get; set; } // Дата начала задачи
    }
}
