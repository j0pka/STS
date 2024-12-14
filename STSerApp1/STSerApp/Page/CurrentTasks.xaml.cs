using Firebase.Database;
using Firebase.Database.Query;
using STSerApp.Models;
using STSerApp.Page;
using STSerApp.Popups;

namespace STSerApp.Page
{
    public partial class CurrentTasks : ContentPage
    {
        private readonly FirebaseClient _firebaseClient = new FirebaseClient("https://stsdb-ae158-default-rtdb.firebaseio.com/");
        private List<Tasks> _tasks;

        public CurrentTasks()
        {
            InitializeComponent();
            LoadTasks();
        }

        private async void LoadTasks()
        {
            try
            {
                // Получаем все задачи из Firebase
                var tasks = await _firebaseClient
                    .Child("Tasks")
                    .OnceAsync<Tasks>();

                // Фильтруем задачи, если они принадлежат текущему сотруднику
                _tasks = tasks
                    .Where(t => t.Object.Employee.EmployeeId == App.CurrentUser.EmployeeId) // ID текущего сотрудника
                    .Select(t => t.Object)
                    .ToList();

                // Привязываем задачи к интерфейсу
                TasksCollectionView.ItemsSource = _tasks;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", $"Произошла ошибка: {ex.Message}", "OK");
            }
        }

        

        //private async void MoreInfBtn_Clicked(object sender, EventArgs e)
        //{
        //    var button = sender as Button;
        //    var task = button?.BindingContext as Tasks;
        //    if (task != null)
        //    {
        //        await Navigation.PushAsync(new TaskDetailsPopup(task));  // Переход на страницу с деталями
        //    }
        //}
    }
}
