namespace STSerApp.Page;

public partial class PathwayTasks : ContentPage
{
	public PathwayTasks()
	{
		InitializeComponent();
	}

    

    private void Login1Btn_Clicked(object sender, EventArgs e)
    {
        Application.Current.MainPage = new NavigationPage(new TestPage());
    }

    
}