using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STSerApp.Models
{
    public class Employees
    {
        public string LastName { get; set; } // Фамилия
        public string FirstName { get; set; } // Имя
        public string MiddleName { get; set; } // Отчество
        public DateTime DateOfBirth { get; set; } // Дата рождения
        public string PhoneNumber { get; set; } // Номер телефона
        public string PassportSeries { get; set; } // Серия паспорта
        public string PassportNumber { get; set; } // Номер паспорта
        public DateTime PassportIssueDate { get; set; } // Дата выдачи паспорта
        public string PassportIssuedBy { get; set; } // Кем выдан паспорт
        public int DrivingExperience { get; set; } // Стаж вождения (в годах)
        public string DrivingLicenseCategories { get; set; } // Категории водительских прав
        public string RegistrationAddress { get; set; } // Адрес прописки
        public string ActualAddress { get; set; } // Фактический адрес
        public string MilitaryID { get; set; } // Военный билет
        public string SNILS { get; set; } // СНИЛС
        public string INN { get; set; } // ИНН
        //public byte[] Photo { get; set; } // Фото (хранится как массив байт)
        public string Login { get; set; } // Логин
        public string Password { get; set; } // Пароль
        public int EmployeeId { get; set; }
    }
}
