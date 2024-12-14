using Firebase.Database;
using Firebase.Database.Query;
using STSerApp.Models;

namespace STSerApp.Page
{
    public partial class LoginPage : ContentPage
    {
        private readonly FirebaseClient _firebaseClient = new FirebaseClient("https://stsdb-ae158-default-rtdb.firebaseio.com/");

        public LoginPage()
        {
            InitializeComponent();
        }

        private async void LoginBtn_Clicked(object sender, EventArgs e)
        {
            string enteredLogin = LoginEntry.Text?.Trim();
            string enteredPassword = PasswordEntry.Text?.Trim();

            if (string.IsNullOrWhiteSpace(enteredLogin) || string.IsNullOrWhiteSpace(enteredPassword))
            {
                await DisplayAlert("Ошибка", "Введите логин и пароль.", "OK");
                return;
            }

            try
            {
                var employees = await _firebaseClient
                    .Child("Employees")
                    .OnceAsync<Employees>();

                var employee = employees.FirstOrDefault(emp =>
                    emp.Object.Login == enteredLogin && emp.Object.Password == enteredPassword);

                if (employee != null)
                {
                    await DisplayAlert("Успешно", $"Добро пожаловать, {employee.Object.FirstName}!", "OK");

                    // Сохранить данные текущего пользователя для глобального доступа
                    App.CurrentUser = employee.Object;

                    // Перенаправить на главную страницу
                    Application.Current.MainPage = new NavigationPage(new AppShell());
                }
                else
                {
                    await DisplayAlert("Ошибка", "Неверный логин или пароль.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", $"Произошла ошибка: {ex.Message}", "OK");
            }
        }
    }
}
