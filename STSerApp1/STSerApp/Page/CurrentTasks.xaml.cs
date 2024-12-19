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
        private List<Tasks> AllTasks { get; set; }

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

                AllTasks = tasks
                    .Where(task => task.Object.EmployeeID == employeeId)
                    .Select(task => task.Object)
                    .ToList();

                // Фильтрация предстоящих задач при первой загрузке
                var upcomingTasks = AllTasks
                    .Where(task => task.EndDate >= DateTime.Now.Date)
                    .OrderBy(task => task.StartDate);

                UpdateTaskList(upcomingTasks);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", $"Не удалось загрузить задачи: {ex.Message}", "OK");
            }
        }

        private void UpdateTaskList(IEnumerable<Tasks> tasks)
        {
            TaskList.Clear();
            foreach (var task in tasks)
            {
                TaskList.Add(task);
            }
        }

        private async void MoreInfBtn_Clicked(object sender, EventArgs e)
        {
            // Находим задачу, на которую нажали
            var button = (Button)sender;
            var task = (Tasks)button.BindingContext;

            // Открываем модальное окно с деталями задачи
            await Navigation.PushModalAsync(new TaskDetailsPage(task));
        }

        private void UpcomingTasksButton_Clicked(object sender, EventArgs e)
        {
            var upcomingTasks = AllTasks
                .Where(task => task.EndDate >= DateTime.Now.Date)
                .OrderBy(task => task.StartDate);

            UpdateTaskList(upcomingTasks);
        }

        private void CompletedTasksButton_Clicked(object sender, EventArgs e)
        {
            var completedTasks = AllTasks
                .Where(task => task.EndDate <= DateTime.Now.Date)
                .OrderByDescending(task => task.EndDate);

            UpdateTaskList(completedTasks);
        }
    }
}
