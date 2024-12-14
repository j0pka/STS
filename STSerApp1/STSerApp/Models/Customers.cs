using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STSerApp.Models
{
    public class Customers
    {
        public string CompanyName { get; set; } // Название компании
        public string PhoneNumber { get; set; } // Номер телефона
        public string Director { get; set; } // Директор
        public string Representative { get; set; } // Представитель
        public string RepresentativePhoneNumber { get; set; } // Номер представителя
        public string Address { get; set; } // Адрес
        public string Description { get; set; } // Описание
        public string CustomerId { get; set; }
    }
}
