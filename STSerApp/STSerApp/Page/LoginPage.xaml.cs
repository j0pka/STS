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
        // ���������� MainPage ��� ����� �������� �������� ����������
        Application.Current.MainPage = new NavigationPage(new AppShell());
    }

}
