using Microsoft.Maui.Controls.PlatformConfiguration;

namespace STSerApp.Page;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    //private async void LoginBtn_Clicked(object sender, EventArgs e)
    //{
    //    await Navigation.PushAsync(new MainPage());
    //}
    private void LoginBtn_Clicked(object sender, EventArgs e)
    {
        // Установить MainPage как новую корневую страницу приложения
        Application.Current.MainPage = new NavigationPage(new AppShell());
    }

}
