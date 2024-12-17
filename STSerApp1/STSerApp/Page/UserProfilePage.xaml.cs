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

    }
}
