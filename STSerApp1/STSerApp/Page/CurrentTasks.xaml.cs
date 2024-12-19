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
            System.Diagnostics.Debug.WriteLine("Текущий пользователь: " + App.CurrentUser?.FirstName);

            // Проверка на null для текущего пользователя
            var currentUser = App.CurrentUser;
            if (currentUser == null)
            {
                // Если пользователь не найден, можно показать ошибку или выйти из метода
                DisplayAlert("Ошибка", "Пользователь не авторизован.", "OK");
                return;
            }

            // Словарь задач для разных пользователей
            var tasksForUsers = new Dictionary<int, List<TaskModel>>
    {
        { 1, new List<TaskModel> {
                new TaskModel { Title = "Очистка территории от мусора", StartDate = DateTime.Now, Address = "Территория 1", Description = "Очистка мусора в зоне 1." },
                new TaskModel { Title = "Уборка территории", StartDate = DateTime.Now.AddDays(1), Address = "Территория 2", Description = "Уборка территории вокруг офисного здания." }
            }
        },
        { 2, new List<TaskModel> {
                new TaskModel { Title = "Общий уход за территорией", StartDate = DateTime.Now, Address = "Территория 3", Description = "Уход за растительностью и уборка территории." }
            }
        }
    };

            // Получить задачи для текущего пользователя
            if (tasksForUsers.ContainsKey(currentUser.EmployeeId))
            {
                // Привязать задачи к CollectionView
                TasksCollectionView.ItemsSource = tasksForUsers[currentUser.EmployeeId];
            }
            else
            {
                TasksCollectionView.ItemsSource = new List<TaskModel>(); // Если задач нет, показать пустой список
            }
        }

        private void OnMoreInfoBtn_Clicked(object sender, EventArgs e)
        {
            
        }


        //private async void LoadTasks()
        //{
        //    try
        //    {
        //        // Получаем все задачи из Firebase
        //        var tasks = await _firebaseClient
        //            .Child("Tasks")
        //            .OnceAsync<Tasks>();

        //        // Фильтруем задачи, если они принадлежат текущему сотруднику
        //        _tasks = tasks
        //            .Where(t => t.Object.EmployeeId == App.CurrentUser.EmployeeId)  // Сравниваем по EmployeeId
        //            .Select(t => t.Object)
        //            .ToList();

        //        // Привязываем задачи к интерфейсу
        //        TasksCollectionView.ItemsSource = _tasks;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Логируем ошибку и отображаем сообщение
        //        Console.WriteLine($"Error loading tasks: {ex.Message}");
        //        await DisplayAlert("Ошибка", $"Произошла ошибка: {ex.Message}", "OK");
        //    }
        //}





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
