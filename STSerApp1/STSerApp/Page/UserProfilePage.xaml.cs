using STSerApp.Models;

namespace STSerApp.Page
{
    public partial class UserProfilePage : ContentPage
    {
        private Employees _currentUser;

        public UserProfilePage()
        {
            InitializeComponent();

            // �������� ������ �������� ������������
            _currentUser = App.CurrentUser;

            // ����������� ������ ������������ � ����������
            BindingContext = _currentUser;
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

    }
}
