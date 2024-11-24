using Firebase.Database;
using Firebase.Database.Query;
using STSER.Model;

namespace STSER.Views;

public partial class NewPage1 : ContentPage
{
	FirebaseClient client = new FirebaseClient("https://stserdb-default-rtdb.firebaseio.com/");
	public List<Order> Orders { get; set; }

    public NewPage1()
	{
		InitializeComponent();
		OrderOrders();
		BindingContext = this;

    }
	public void OrderOrders()
	{
		var orders  = client.Child("Orders").OnceAsync<Order>();
		Orders = orders.Result.Select(x => x.Object).ToList();
	}

    private async void saveBtn_Clicked(object sender, EventArgs e)
    {
		Order order = orderPicker.SelectedItem as Order;
		await client.Child("Employees").PostAsync(new Employee
		{
			NUMChevoto = numEntry.Text,
			Birthday = fIPicker.Date,
			ZPshka = double.Parse(zpEntry.Text),
			Order = order,
		});
		await Shell.Current.GoToAsync("..");
    }
}