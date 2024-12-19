using Firebase.Database;
using Firebase.Database.Query;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using STSerApp.Models;

namespace STSerApp.Page
{
    public partial class CurrentTasks : ContentPage
    {
        private readonly FirebaseClient _firebaseClient = new FirebaseClient("https://stsdb-ae158-default-rtdb.firebaseio.com/");
        public ObservableCollection<Tasks> TaskList { get; set; }

        public CurrentTasks()
        {
            InitializeComponent();
            TaskList = new ObservableCollection<Tasks>();
            BindingContext = this;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadTasks();
        }

        private async Task LoadTasks()
        {
            string employeeId = AppShell.CurrentEmployeeId;

            if (string.IsNullOrWhiteSpace(employeeId))
            {
                await DisplayAlert("Ошибка", "Сотрудник не авторизован.", "OK");
                return;
            }

            try
            {
                var tasks = await _firebaseClient
                    .Child("Tasks")
                    .OnceAsync<Tasks>();

                var employeeTasks = tasks
                    .Where(task => task.Object.EmployeeID == employeeId)
                    .Select(task => task.Object);

                TaskList.Clear();

                foreach (var task in employeeTasks)
                {
                    TaskList.Add(task);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", $"Не удалось загрузить задачи: {ex.Message}", "OK");
            }
        }
    }
}
