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
    }
}
