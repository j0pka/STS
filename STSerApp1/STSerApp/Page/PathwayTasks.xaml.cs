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
    public PathwayTasks()
	{
		InitializeComponent();
	}

    private async void OnAddTaskClicked(object sender, EventArgs e)
    {
        // �������� ������ �� ����� �����
        var title = TitleEntry.Text;
        var startDate = StartDatePicker.Date;
        var endDate = EndDatePicker.Date;
        var address = AddressEntry.Text;
        var description = DescriptionEditor.Text;
        var taskComment = TaskCommentEditor.Text;
        var customerID = CustomerIDEntry.Text;
        var vehicleID = VehicleIDEntry.Text;
        var employeeID = EmployeeIDEntry.Text;

        // �������� ������������ �����
        if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(description))
        {
            await DisplayAlert("������", "��� ���� ������ ���� ���������.", "OK");
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
                CustomerID = customerID,
                VehicleID = vehicleID,
                EmployeeID = employeeID
               
            };

            // ���������� ������ � Firebase
            await _firebaseClient
                .Child("Tasks") // ��������� � ��������� Tasks
                .PostAsync(newTask);

            // ����������� �� �������� ����������
            await DisplayAlert("�����", "������ ������� ���������!", "OK");

            // ������� ����� ����� ���������� ������
            TitleEntry.Text = string.Empty;
            AddressEntry.Text = string.Empty;
            DescriptionEditor.Text = string.Empty;
            TaskCommentEditor.Text = string.Empty;
            CustomerIDEntry.Text = string.Empty;
            VehicleIDEntry.Text = string.Empty;
            EmployeeIDEntry.Text = string.Empty;
            StartDatePicker.Date = DateTime.Now;
            EndDatePicker.Date = DateTime.Now;
        }
        catch (Exception ex)
        {
            await DisplayAlert("������", $"�� ������� �������� ������: {ex.Message}", "OK");
        }
    }

}