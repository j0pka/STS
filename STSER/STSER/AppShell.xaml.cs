using STSER.Views;

namespace STSER
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Пути доступа
            Routing.RegisterRoute(nameof(NewPage1),typeof(NewPage1));
        }
    }
}