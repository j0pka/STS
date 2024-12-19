
using Firebase.Database.Query;
using System.Threading.Tasks;
using Firebase.Database;
using System.Collections.ObjectModel;
using STSerApp.Models;

namespace STSerApp.Page
{
    public partial class UserProfilePage : ContentPage
    {
        private readonly FirebaseClient _firebaseClient = new FirebaseClient("https://stsdb-ae158-default-rtdb.firebaseio.com/");
        public Employees CurrentUser { get; set; }


        public UserProfilePage()
        {
            InitializeComponent();

            BindingContext = this;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadUserProfile(); // Загружаем данные пользователя
        }

        private async Task LoadUserProfile()
        {
            string employeeId = AppShell.CurrentEmployeeId;

            if (string.IsNullOrWhiteSpace(employeeId))
            {
                await DisplayAlert("Ошибка", "Сотрудник не авторизован.", "OK");
                return;
            }

            try
            {
                var users = await _firebaseClient
                    .Child("Employees")  // Данные сотрудников в Firebase
                    .OnceAsync<Employees>();

                var currentUser = users
                    .FirstOrDefault(u => u.Object.EmployeeID == employeeId)?.Object;

                if (currentUser != null)
                {
                    CurrentUser = currentUser; // Привязываем текущего пользователя к BindingContext
                    OnPropertyChanged(nameof(CurrentUser)); // Обновляем привязку
                }
                else
                {
                    await DisplayAlert("Ошибка", "Не удалось найти данные пользователя.", "OK");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка при загрузке данных пользователя: {ex.Message}");
                await DisplayAlert("Ошибка", $"Не удалось загрузить данные: {ex.Message}", "OK");
            }
        }


        private async void exitBtn_Clicked(object sender, EventArgs e)
        {
            bool confirm = await DisplayAlert("Подтверждение", "Вы действительно хотите выйти?", "Да", "Нет");

            if (confirm)
            {
                // Очистка данных текущего пользователя
                App.CurrentUser = null;

                // Перенаправление на страницу входа
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            }
        }





        private async void backBtn_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new AppShell();
        }
    }
}