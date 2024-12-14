namespace STSerApp.Page;
using Firebase.Database;
using Firebase.Database.Query;
using STSerApp.Models;
using System.Diagnostics;
using System.Formats.Tar;
using System.Reflection.PortableExecutable;

public partial class TestPage : ContentPage
{
    FirebaseClient client = new FirebaseClient("https://stsdb-ae158-default-rtdb.firebaseio.com/");
    public List<Employees> Employees
    {
        get => _employees;
        set
        {
            _employees = value;
            OnPropertyChanged(nameof(Employees)); // Обновление привязки данных
        }
    }
    private List<Employees> _employees;

    public List<Vehicles> Vehicles { get; set; }
    public List<Customers> Customers { get; set; }

    public TestPage()
	{
		InitializeComponent();

        EmployeesEmployees();
        VehiclesVehicles();
        CustomersCustomers();
        BindingContext = this;
	}

    public async void EmployeesEmployees()
    {
        var employees = await client.Child("Employees").OnceAsync<Employees>();
        Employees = employees.Select(x => x.Object).ToList();
        OnPropertyChanged(nameof(Employees)); // Обновляем привязку
    }

    public async void VehiclesVehicles()
    {
        var vehicles = await client.Child("Vehicles").OnceAsync<Vehicles>();
        Vehicles = vehicles.Select(x => x.Object).ToList();
        OnPropertyChanged(nameof(Vehicles)); // Обновляем привязку
    }

    public async void CustomersCustomers()
    {
        var customers = await client.Child("Customers").OnceAsync<Customers>();
        Customers = customers.Select(x => x.Object).ToList();
        OnPropertyChanged(nameof(Customers)); // Обновляем привязку
    }

    private void Login2Btn_Clicked(object sender, EventArgs e)
    {
        Application.Current.MainPage = new NavigationPage(new AppShell());
    }

    private async void SaveBtn_Clicked(object sender, EventArgs e)
    {
        // Сбор даты и времени для начала и окончания задачи
        var startDateTime = startDatePicker.Date.Add(startTimePicker.Time);
        var endDateTime = endDatePicker.Date.Add(endTimePicker.Time);

        // Получение выбранных элементов из Picker
        Employees selectedEmployee = employeePicker.SelectedItem as Employees;
        Vehicles selectedVehicle = vehiclePicker.SelectedItem as Vehicles;
        Customers selectedCustomer = customerPicker.SelectedItem as Customers;

        // Проверка, что все элементы выбраны
        if (selectedEmployee != null && selectedVehicle != null && selectedCustomer != null)
        {
            // Создание новой задачи
            var newTask = new Tasks
            {
                Title = titleEntry.Text,
                StartDate = startDateTime,
                EndDate = endDateTime,
                Address = addressEntry.Text,
                Description = descriptionEntry.Text,
                TaskComment = taskCommentEntry.Text,
                // Передаем ID или уникальные данные, связанные с выбранными объектами
                Employee = selectedEmployee, 
                Vehicle = selectedVehicle,   
                Customer = selectedCustomer  
            };

            // Сохранение задачи в Firebase
            await client.Child("Tasks").PostAsync(newTask);
        }
        else
        {
            // Если что-то не выбрано, показываем сообщение об ошибке
            await DisplayAlert("Ошибка", "Пожалуйста, выберите сотрудника, машину и заказчика.", "OK");
        }
    }




}