namespace STSerApp.Page;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

        // Убрать кнопку "Назад" (на всякий случай)
        NavigationPage.SetHasBackButton(this, false);
    }
}