using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STSER.Model
{
    public class Employee
    {
        public string NUMChevoto { get; set; }
        public DateTime Birthday { get; set; }
        public double ZPshka { get; set; }
        public Order Order { get; set; }
    }
}
