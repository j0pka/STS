using Firebase.Database;
using Firebase.Database.Query;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using STSerApp.Models;
using STSerApp.Popups;
namespace STSerApp.Page
{
    public partial class CurrentTasks : ContentPage
    {
        //private readonly FirebaseClient _firebaseClient = new FirebaseClient("https://stsdb-ae158-default-rtdb.firebaseio.com/");
        //private List<Tasks> _tasks;

        public CurrentTasks()
        {
            InitializeComponent();
            LoadTasks();
            this.BindingContext = this;
        }

        private void LoadTasks()
        {
            System.Diagnostics.Debug.WriteLine("������� ������������: " + App.CurrentUser?.FirstName);

            // �������� �� null ��� �������� ������������
            var currentUser = App.CurrentUser;
            if (currentUser == null)
            {
                // ���� ������������ �� ������, ����� �������� ������ ��� ����� �� ������
                DisplayAlert("������", "������������ �� �����������.", "OK");
                return;
            }

            // ������� ����� ��� ������ �������������
            var tasksForUsers = new Dictionary<int, List<TaskModel>>
    {
        { 1, new List<TaskModel> {
                new TaskModel { Title = "������� ���������� �� ������", StartDate = DateTime.Now, Address = "���������� 1", Description = "������� ������ � ���� 1." },
                new TaskModel { Title = "������ ����������", StartDate = DateTime.Now.AddDays(1), Address = "���������� 2", Description = "������ ���������� ������ �������� ������." }
            }
        },
        { 2, new List<TaskModel> {
                new TaskModel { Title = "����� ���� �� �����������", StartDate = DateTime.Now, Address = "���������� 3", Description = "���� �� ��������������� � ������ ����������." }
            }
        }
    };

            // �������� ������ ��� �������� ������������
            if (tasksForUsers.ContainsKey(currentUser.EmployeeId))
            {
                // ��������� ������ � CollectionView
                TasksCollectionView.ItemsSource = tasksForUsers[currentUser.EmployeeId];
            }
            else
            {
                TasksCollectionView.ItemsSource = new List<TaskModel>(); // ���� ����� ���, �������� ������ ������
            }
        }

        private void OnMoreInfoBtn_Clicked(object sender, EventArgs e)
        {
            
        }


        //private async void LoadTasks()
        //{
        //    try
        //    {
        //        // �������� ��� ������ �� Firebase
        //        var tasks = await _firebaseClient
        //            .Child("Tasks")
        //            .OnceAsync<Tasks>();

        //        // ��������� ������, ���� ��� ����������� �������� ����������
        //        _tasks = tasks
        //            .Where(t => t.Object.EmployeeId == App.CurrentUser.EmployeeId)  // ���������� �� EmployeeId
        //            .Select(t => t.Object)
        //            .ToList();

        //        // ����������� ������ � ����������
        //        TasksCollectionView.ItemsSource = _tasks;
        //    }
        //    catch (Exception ex)
        //    {
        //        // �������� ������ � ���������� ���������
        //        Console.WriteLine($"Error loading tasks: {ex.Message}");
        //        await DisplayAlert("������", $"��������� ������: {ex.Message}", "OK");
        //    }
        //}





        //private async void MoreInfBtn_Clicked(object sender, EventArgs e)
        //{
        //    var button = sender as Button;
        //    var task = button?.BindingContext as Tasks;
        //    if (task != null)
        //    {
        //        await Navigation.PushAsync(new TaskDetailsPopup(task));  // ������� �� �������� � ��������
        //    }
        //}
    }
}
