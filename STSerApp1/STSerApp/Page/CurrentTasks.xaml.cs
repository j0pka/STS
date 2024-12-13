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
        public List<TaskModel> AllTasks { get; set; }
        public List<TaskModel> Tasks { get; set; }

        public CurrentTasks()
        {
            InitializeComponent();
            LoadTasks();
            this.BindingContext = this;
        }

        private void LoadTasks()
        {
            System.Diagnostics.Debug.WriteLine("������� ������������: " + App.CurrentUser?.FirstName);

            var currentUser = App.CurrentUser;
            if (currentUser == null)
            {
                DisplayAlert("������", "������������ �� �����������.", "OK");
                return;
            }

            var tasksForUsers = new Dictionary<int, List<TaskModel>>
            {
                { 1, new List<TaskModel> {
                        new TaskModel { Title = "������������ ������� ", StartDate = new DateTime(2004, 12, 19, 9, 30, 0), Address = "�. ��� ��.������������� 3", Description = "���������� �������� ������� (��������� ����� 100-150 ������). ������������ ������ ��������." },
                        new TaskModel { Title = "������ ����������", StartDate = new DateTime(2024, 12, 14, 9, 30, 0), Address = "�. ��� ��.������ 153", Description = "������ ���������� �� ������������� ������ ������ �������� ������." },
                        new TaskModel { Title = "��������� ����� �� ���������� ", StartDate = new DateTime(2024, 12, 21, 12, 30, 0), Address = "�. ��� ��.������ 153", Description = "������� � �������� ���� �� ���������� ������� � ������� �����." },
                        new TaskModel { Title = "��������� ����� �� ���������� ", StartDate = new DateTime(2024, 12, 22, 12, 30, 0), Address = "�. ��� ��.������ 153", Description = "������� � �������� ���� �� ���������� ������� � ������� �����." },
                        new TaskModel { Title = "��������� ����� �� ���������� ", StartDate = new DateTime(2024, 12, 25, 12, 30, 0), Address = "�. ��� ��.������ 153", Description = "������� � �������� ���� �� ���������� ������� � ������� �����." }
                    }
                },
                { 2, new List<TaskModel> {
                        new TaskModel { Title = "�������� ������� ��� ������� ", StartDate = new DateTime(2024, 12, 20, 12, 30, 0), Address = "�. ��� ��.������ 153", Description = "������� � ������������� ������� � ��������� ���������, ���� �� ����� ����������� � ������ ������." },
                        new TaskModel { Title = "��������� ����� �� ���������� ", StartDate = new DateTime(2024, 12, 14, 12, 30, 0), Address = "�. ��� ��.������ 153", Description = "������� � �������� ���� �� ���������� ������� � ������� �����." },
                        new TaskModel { Title = "��������� ����� �� ���������� ", StartDate = new DateTime(2024, 12, 21, 12, 30, 0), Address = "�. ��� ��.������ 153", Description = "������� � �������� ���� �� ���������� ������� � ������� �����." },
                        new TaskModel { Title = "��������� ����� �� ���������� ", StartDate = new DateTime(2024, 12, 22, 12, 30, 0), Address = "�. ��� ��.������ 153", Description = "������� � �������� ���� �� ���������� ������� � ������� �����." },
                        new TaskModel { Title = "��������� ����� �� ���������� ", StartDate = new DateTime(2024, 12, 25, 12, 30, 0), Address = "�. ��� ��.������ 153", Description = "������� � �������� ���� �� ���������� ������� � ������� �����." }

                    }
                }
            };

            if (tasksForUsers.ContainsKey(currentUser.EmployeeId))
            {
                AllTasks = tasksForUsers[currentUser.EmployeeId];
                Tasks = AllTasks; // �� ��������� ���������� ��� ������
                TasksCollectionView.ItemsSource = Tasks;
            }
            else
            {
                Tasks = new List<TaskModel>();
                TasksCollectionView.ItemsSource = Tasks;
            }
        }

        private void onCompletedTasks_Clicked(object sender, EventArgs e)
        {
            Tasks = AllTasks.Where(task => task.StartDate.Date < DateTime.Today).ToList();
            TasksCollectionView.ItemsSource = Tasks;

            // �������� ������� ��� ������ (��������, ��� ��������� �������� ������)
            UpdateButtonStyles(sender as Button);
        }

        private void onUpcomingTasks_Clicked(object sender, EventArgs e)
        {
            Tasks = AllTasks.Where(task => task.StartDate.Date >= DateTime.Today).ToList();
            TasksCollectionView.ItemsSource = Tasks;

            // �������� ������� ��� ������ (��������, ��� ��������� �������� ������)
            UpdateButtonStyles(sender as Button);
        }


        // ������� ��� ���������� ������ ������ (��� ��������� ��������)
        private void UpdateButtonStyles(Button clickedButton)
        {
            // ������������� ����������� ������ ��� ���� ��������� ��������
            foreach (var button in new Button[] { (Button)FindByName("onUpcomingTasks"), (Button)FindByName("onCompletedTasks") })
            {
                button.BackgroundColor = (button == clickedButton) ? Color.FromArgb("#F49D37") : Color.FromArgb("#E1E1E1");
            }
        }


        private void OnMoreInfoBtn_Clicked(object sender, EventArgs e)
        {
            // ���������� ������ ��� ������ "������ ����������"
        }
    }
}







//using Firebase.Database;
//using Firebase.Database.Query;

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using STSerApp.Models;
//using STSerApp.Popups;
//namespace STSerApp.Page
//{
//    public partial class CurrentTasks : ContentPage
//    {
//        //private readonly FirebaseClient _firebaseClient = new FirebaseClient("https://stsdb-ae158-default-rtdb.firebaseio.com/");
//        //private List<Tasks> _tasks;

//        public CurrentTasks()
//        {
//            InitializeComponent();
//            LoadTasks();
//            this.BindingContext = this;
//        }

//        private void LoadTasks()
//        {
//            System.Diagnostics.Debug.WriteLine("������� ������������: " + App.CurrentUser?.FirstName);

//            // �������� �� null ��� �������� ������������
//            var currentUser = App.CurrentUser;
//            if (currentUser == null)
//            {
//                // ���� ������������ �� ������, ����� �������� ������ ��� ����� �� ������
//                DisplayAlert("������", "������������ �� �����������.", "OK");
//                return;
//            }

//            // ������� ����� ��� ������ �������������
//            var tasksForUsers = new Dictionary<int, List<TaskModel>>
//    {
//        { 1, new List<TaskModel> {
//                new TaskModel { Title = "������� ���������� �� ������", StartDate = DateTime.Now, Address = "���������� 1", Description = "������� ������ � ���� 1." },
//                new TaskModel { Title = "������ ����������", StartDate = DateTime.Now.AddDays(1), Address = "���������� 2", Description = "������ ���������� ������ �������� ������." }
//            }
//        },
//        { 2, new List<TaskModel> {
//                new TaskModel { Title = "����� ���� �� �����������", StartDate = DateTime.Now, Address = "���������� 3", Description = "���� �� ��������������� � ������ ����������." }
//            }
//        }
//    };

//            // �������� ������ ��� �������� ������������
//            if (tasksForUsers.ContainsKey(currentUser.EmployeeId))
//            {
//                // ��������� ������ � CollectionView
//                TasksCollectionView.ItemsSource = tasksForUsers[currentUser.EmployeeId];
//            }
//            else
//            {
//                TasksCollectionView.ItemsSource = new List<TaskModel>(); // ���� ����� ���, �������� ������ ������
//            }
//        }

//        private void OnMoreInfoBtn_Clicked(object sender, EventArgs e)
//        {
//            var button = (Button)sender;
//            var task = (TaskModel)button.BindingContext;  // �������� ������, � ������� ��������� ������

//            // ��������� Popup � ����������� � ������
//            var popup = new TaskDetailsPopup();
//            popup.BindingContext = task;  // �������� ������ ������ � Popup
//            await Navigation.PushAsync(new TaskDetailsPopup(task));  // ������� �� �������� � ��������
//        }


//        //private async void LoadTasks()
//        //{
//        //    try
//        //    {
//        //        // �������� ��� ������ �� Firebase
//        //        var tasks = await _firebaseClient
//        //            .Child("Tasks")
//        //            .OnceAsync<Tasks>();

//        //        // ��������� ������, ���� ��� ����������� �������� ����������
//        //        _tasks = tasks
//        //            .Where(t => t.Object.EmployeeId == App.CurrentUser.EmployeeId)  // ���������� �� EmployeeId
//        //            .Select(t => t.Object)
//        //            .ToList();

//        //        // ����������� ������ � ����������
//        //        TasksCollectionView.ItemsSource = _tasks;
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        // �������� ������ � ���������� ���������
//        //        Console.WriteLine($"Error loading tasks: {ex.Message}");
//        //        await DisplayAlert("������", $"��������� ������: {ex.Message}", "OK");
//        //    }
//        //}





//        //private async void MoreInfBtn_Clicked(object sender, EventArgs e)
//        //{
//        //    var button = sender as Button;
//        //    var task = button?.BindingContext as Tasks;
//        //    if (task != null)
//        //    {
//        //        await Navigation.PushAsync(new TaskDetailsPopup(task));  // ������� �� �������� � ��������
//        //    }
//        //}
//    }
//}
