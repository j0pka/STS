namespace STSerApp.Page;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

        // ������ ������ "�����" (�� ������ ������)
        NavigationPage.SetHasBackButton(this, false);
    }
}