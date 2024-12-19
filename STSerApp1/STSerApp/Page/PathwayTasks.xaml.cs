using Firebase.Database;
using Firebase.Database.Query;
using STSerApp.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
namespace STSerApp.Page;

public partial class PathwayTasks : ContentPage
{
    private readonly FirebaseClient _firebaseClient = new FirebaseClient("https://stsdb-ae158-default-rtdb.firebaseio.com/");
    public List<Customers> CustomerList { get; set; }
    public List<Vehicles> VehicleList { get; set; }

    public PathwayTasks() { 

        InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadData();
    }

    private async Task LoadData()
    {
        try
        {
            // Загрузка списка клиентов
            var customers = await _firebaseClient
                .Child("Customers")
                .OnceAsync<Customers>();

            CustomerList = customers.Select(c => c.Object).ToList();
            CustomerPicker.ItemsSource = CustomerList;

            // Загрузка списка транспортных средств
            var vehicles = await _firebaseClient
                .Child("Vehicles")
                .OnceAsync<Vehicles>();

            VehicleList = vehicles.Select(v => v.Object).ToList();
            VehiclePicker.ItemsSource = VehicleList;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ошибка", $"Не удалось загрузить данные: {ex.Message}", "OK");
        }
    }

    private async void OnAddTaskClicked(object sender, EventArgs e)
    {
        // Получаем данные из полей ввода
        var title = TitleEntry.Text;
        var startDate = StartDatePicker.Date;
        var endDate = EndDatePicker.Date;
        var address = AddressEntry.Text;
        var description = DescriptionEditor.Text;
        var taskComment = TaskCommentEditor.Text;

        var customer = (Customers)CustomerPicker.SelectedItem;
        var vehicle = (Vehicles)VehiclePicker.SelectedItem;

        // Проверка обязательных полей
        if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(description))
        {
            await DisplayAlert("Ошибка", "Все поля должны быть заполнены.", "OK");
            return;
        }

        if (customer == null || vehicle == null)
        {
            await DisplayAlert("Ошибка", "Необходимо выбрать клиента и транспорт.", "OK");
            return;
        }

        try
        {
            var newTask = new Tasks
            {
                Title = title,
                StartDate = startDate,
                EndDate = endDate,
                Address = address,
                Description = description,
                TaskComment = taskComment,
                CustomerID = customer.CustomerId,
                VehicleID = vehicle.VehicleId,
                EmployeeID = EmployeeIDEntry.Text,
                Customer = customer,
                Vehicle = vehicle
            };

            // Добавление задачи в Firebase
            await _firebaseClient
                .Child("Tasks") // Добавляем в коллекцию Tasks
                .PostAsync(newTask);

            // Уведомление об успешном добавлении
            await DisplayAlert("Успех", "Задача успешно добавлена!", "OK");

            // Очистка формы после добавления задачи
            TitleEntry.Text = string.Empty;
            AddressEntry.Text = string.Empty;
            DescriptionEditor.Text = string.Empty;
            TaskCommentEditor.Text = string.Empty;
            CustomerIDEntry.Text = string.Empty;
            VehicleIDEntry.Text = string.Empty;
            EmployeeIDEntry.Text = string.Empty;
            StartDatePicker.Date = DateTime.Now;
            EndDatePicker.Date = DateTime.Now;
            CustomerPicker.SelectedItem = null;
            VehiclePicker.SelectedItem = null;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ошибка", $"Не удалось добавить задачу: {ex.Message}", "OK");
        }
    }
}
