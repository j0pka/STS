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
                await DisplayAlert("������", "������� ����� � ������.", "OK");
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
                    await DisplayAlert("�������", $"����� ����������, {employee.Object.FirstName}!", "OK");

                    // ���������� �������� ����������
                    AppShell.SetCurrentEmployee(employee.Object.EmployeeID);

                    // ������� � ������� ��������
                    Application.Current.MainPage = new AppShell();
                }
                else
                {
                    await DisplayAlert("������", "�������� ����� ��� ������.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("������", $"��������� ������: {ex.Message}", "OK");
            }
        }



        private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            var phoneNumber = "https://wa.me/79963452489?text=%D0%97%D0%B4%D1%80%D0%B0%D0%B2%D1%81%D1%82%D0%B2%D1%83%D0%B9%D1%82%D0%B5!%20%D0%AF%20%D0%B7%D0%B0%D0%B1%D1%8B%D0%BB%20%D0%BF%D0%B0%D1%80%D0%BE%D0%BB%D1%8C%20%D0%BA%20%D1%81%D0%B2%D0%BE%D0%B5%D0%B9%20%D1%83%D1%87%D0%B5%D1%82%D0%BD%D0%BE%D0%B9%20%D0%B7%D0%B0%D0%BF%D0%B8%D1%81%D0%B8";

            // �������� ������ � �������� ��� WhatsApp
            await Browser.OpenAsync(phoneNumber, BrowserLaunchMode.SystemPreferred);
        }
    }
}
