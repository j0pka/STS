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

                    // ��������� ������ �������� ������������ ��� ����������� �������
                    App.CurrentUser = employee.Object;

                    // ������������� �� ������� ��������
                    Application.Current.MainPage = new NavigationPage(new AppShell());
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
    }
}
