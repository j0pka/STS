using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STSerApp.Models
{
    public class Vehicles
    {
        public string Name { get; set; } // Название
        public string LicensePlate { get; set; } // Госномер
        public string Description { get; set; } // Описание
        public string WorkType { get; set; } // Типа работ
        public int Year { get; set; } // Год
        public DateTime InspectionDate { get; set; } // Дата прохождения ТО
        public string LicenseCategory { get; set; } // Категория прав
        public string SpecialCertificates { get; set; } // Спец удостоверений

        public string VehicleId { get; set; }
    }
}
