namespace STSerApp.Page;

public partial class MenuPage : ContentPage
{
    public MenuPage()
    {
        InitializeComponent();
    }

    private void ProfUserBtn_Clicked(object sender, EventArgs e)
    {
        // �������� �������� �������
        Application.Current.MainPage = new NavigationPage(new UserProfilePage());
    }

    private void GraphUserBtn_Clicked(object sender, EventArgs e)
    {
        // �������� �������� �������
        Application.Current.MainPage = new NavigationPage(new GraphPage());
    }
}
