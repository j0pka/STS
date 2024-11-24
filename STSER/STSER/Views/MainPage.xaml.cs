using Firebase.Database;
using STSER.Model;
using System.Collections.ObjectModel;

namespace STSER.Views;

public partial class MainPage : ContentPage
{
    FirebaseClient client  = new FirebaseClient("https://stserdb-default-rtdb.firebaseio.com/");
    public ObservableCollection<Employee> Lista { get; set; } = new ObservableCollection<Employee>();
	public MainPage()
	{
		InitializeComponent();
        BindingContext = this;
        CargarLista();

    }
    public void CargarLista()
    {
        client.Child("Employees")
            .AsObservable<Employee>()
            .Subscribe((empleado) =>
        {
            if (empleado.Object != null)
            {
                Lista.Add(empleado.Object);
            }
        });
    }

    private async void newBtn_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync(nameof(NewPage1));
    }

    private void filterEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        string filter = filterEntry.Text.ToLower();
        if (filter.Length > 0)
        {
            listColl.ItemsSource = Lista.Where(x => x.NUMChevoto.ToLower().Contains(filter));
        }
        else
        {
            listColl.ItemsSource = Lista;
        }
    }
}