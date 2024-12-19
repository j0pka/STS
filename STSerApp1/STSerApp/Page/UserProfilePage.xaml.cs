
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
            await LoadUserProfile(); // ��������� ������ ������������
        }

        private async Task LoadUserProfile()
        {
            string employeeId = AppShell.CurrentEmployeeId;

            if (string.IsNullOrWhiteSpace(employeeId))
            {
                await DisplayAlert("������", "��������� �� �����������.", "OK");
                return;
            }

            try
            {
                var users = await _firebaseClient
                    .Child("Employees")  // ������ ����������� � Firebase
                    .OnceAsync<Employees>();

                var currentUser = users
                    .FirstOrDefault(u => u.Object.EmployeeID == employeeId)?.Object;

                if (currentUser != null)
                {
                    CurrentUser = currentUser; // ����������� �������� ������������ � BindingContext
                    OnPropertyChanged(nameof(CurrentUser)); // ��������� ��������
                }
                else
                {
                    await DisplayAlert("������", "�� ������� ����� ������ ������������.", "OK");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"������ ��� �������� ������ ������������: {ex.Message}");
                await DisplayAlert("������", $"�� ������� ��������� ������: {ex.Message}", "OK");
            }
        }


        private async void exitBtn_Clicked(object sender, EventArgs e)
        {
            bool confirm = await DisplayAlert("�������������", "�� ������������� ������ �����?", "��", "���");

            if (confirm)
            {
                // ������� ������ �������� ������������
                App.CurrentUser = null;

                // ��������������� �� �������� �����
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            }
        }





        private async void backBtn_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new AppShell();
        }
    }
}