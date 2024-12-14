using STSerApp.Page;
using STSerApp.Models;

namespace STSerApp
{
    public partial class App : Application
    {
        public static Employees CurrentUser { get; set; }  // Статическое свойство для текущего пользователя

        public App()
        {
            InitializeComponent();
            MainPage = new LoginPage();
        }
    }
}