using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STSerApp.Models
{
    public class Tasks
    {
        public string Title { get; set; } // Название
        public DateTime StartDate { get; set; } // Дата начала
        public DateTime EndDate { get; set; } // Дата окончания
        public Employees Employee { get; set; } // Сотрудник (ссылка на класс Employees)
        public Customers Customer { get; set; } // Заказчик (ссылка на ранее созданный класс Customers)
        public Vehicles Vehicle { get; set; } // Автомобиль (ссылка на ранее созданный класс Vehicles)
        public string Address { get; set; } // Адрес
        public string Description { get; set; } // Описание
        public string TaskComment { get; set; } // Комментарий к задаче
    }
}
