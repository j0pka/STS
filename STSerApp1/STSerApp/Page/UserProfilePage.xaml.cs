using STSerApp.Models;

namespace STSerApp.Page
{
    public partial class UserProfilePage : ContentPage
    {
        private Employees _currentUser;

        public UserProfilePage()
        {
            InitializeComponent();

            // Получаем данные текущего пользователя
            _currentUser = App.CurrentUser;

            // Привязываем данные пользователя к интерфейсу
            BindingContext = _currentUser;
        }
    }
}
