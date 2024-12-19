using Firebase.Database;
using Firebase.Database.Query;
using STSerApp.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
namespace STSerApp.Models
{
    public class FirebaseHelper
    {
        private static FirebaseClient firebase = new FirebaseClient("https://stsdb-ae158-default-rtdb.firebaseio.com/");

        // Получение информации о заказчике по CustomerID
        public static async Task<Customers> GetCustomerById(string customerId)
        {
            var customer = await firebase
                .Child("customers") // Имя коллекции заказчиков
                .Child(customerId)   // Идентификатор заказчика
                .OnceSingleAsync<Customers>(); // Получаем один объект

            return customer;
        }

        // Получение информации о машине по VehicleID
        public static async Task<Vehicles> GetVehicleById(string vehicleId)
        {
            var vehicle = await firebase
                .Child("vehicles") // Имя коллекции машин
                .Child(vehicleId)  // Идентификатор машины
                .OnceSingleAsync<Vehicles>(); // Получаем один объект

            return vehicle;
        }
    }
}
