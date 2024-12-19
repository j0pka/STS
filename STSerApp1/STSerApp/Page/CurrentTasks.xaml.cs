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
            System.Diagnostics.Debug.WriteLine("Текущий пользователь: " + App.CurrentUser?.FirstName);

            var currentUser = App.CurrentUser;
            if (currentUser == null)
            {
                DisplayAlert("Ошибка", "Пользователь не авторизован.", "OK");
                return;
            }

            var tasksForUsers = new Dictionary<int, List<TaskModel>>
            {
                { 1, new List<TaskModel> {
                        new TaskModel { Title = "Очистка территории от мусора", StartDate = DateTime.Now, Address = "Территория 1", Description = "Очистка мусора в зоне 1." },
                        new TaskModel { Title = "Уборка территории", StartDate = DateTime.Now.AddDays(-1), Address = "Территория 2", Description = "Уборка территории вокруг офисного здания." }
                    }
                },
                { 2, new List<TaskModel> {
                        new TaskModel { Title = "Общий уход за территорией", StartDate = DateTime.Now.AddDays(-2), Address = "Территория 3", Description = "Уход за растительностью и уборка территории." }
                    }
                }
            };

            if (tasksForUsers.ContainsKey(currentUser.EmployeeId))
            {
                AllTasks = tasksForUsers[currentUser.EmployeeId];
                Tasks = AllTasks; // По умолчанию показываем все задачи
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

            // Обновить внешний вид кнопок (например, для выделения активной кнопки)
            UpdateButtonStyles(sender as Button);
        }

        private void onUpcomingTasks_Clicked(object sender, EventArgs e)
        {
            Tasks = AllTasks.Where(task => task.StartDate.Date >= DateTime.Today).ToList();
            TasksCollectionView.ItemsSource = Tasks;

            // Обновить внешний вид кнопок (например, для выделения активной кнопки)
            UpdateButtonStyles(sender as Button);
        }


        // Функция для обновления стилей кнопок (для выделения активной)
        private void UpdateButtonStyles(Button clickedButton)
        {
            // Использование стандартных цветов или явно указанных значений
            foreach (var button in new Button[] { (Button)FindByName("onUpcomingTasks"), (Button)FindByName("onCompletedTasks") })
            {
                button.BackgroundColor = (button == clickedButton) ? Color.FromArgb("#FFA500") : Color.FromArgb("#404040");
            }
        }


        private void OnMoreInfoBtn_Clicked(object sender, EventArgs e)
        {
            // Реализуйте логику для кнопки "Больше информации"
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
//            System.Diagnostics.Debug.WriteLine("Текущий пользователь: " + App.CurrentUser?.FirstName);

//            // Проверка на null для текущего пользователя
//            var currentUser = App.CurrentUser;
//            if (currentUser == null)
//            {
//                // Если пользователь не найден, можно показать ошибку или выйти из метода
//                DisplayAlert("Ошибка", "Пользователь не авторизован.", "OK");
//                return;
//            }

//            // Словарь задач для разных пользователей
//            var tasksForUsers = new Dictionary<int, List<TaskModel>>
//    {
//        { 1, new List<TaskModel> {
//                new TaskModel { Title = "Очистка территории от мусора", StartDate = DateTime.Now, Address = "Территория 1", Description = "Очистка мусора в зоне 1." },
//                new TaskModel { Title = "Уборка территории", StartDate = DateTime.Now.AddDays(1), Address = "Территория 2", Description = "Уборка территории вокруг офисного здания." }
//            }
//        },
//        { 2, new List<TaskModel> {
//                new TaskModel { Title = "Общий уход за территорией", StartDate = DateTime.Now, Address = "Территория 3", Description = "Уход за растительностью и уборка территории." }
//            }
//        }
//    };

//            // Получить задачи для текущего пользователя
//            if (tasksForUsers.ContainsKey(currentUser.EmployeeId))
//            {
//                // Привязать задачи к CollectionView
//                TasksCollectionView.ItemsSource = tasksForUsers[currentUser.EmployeeId];
//            }
//            else
//            {
//                TasksCollectionView.ItemsSource = new List<TaskModel>(); // Если задач нет, показать пустой список
//            }
//        }

//        private void OnMoreInfoBtn_Clicked(object sender, EventArgs e)
//        {
//            var button = (Button)sender;
//            var task = (TaskModel)button.BindingContext;  // Получаем задачу, к которой привязана кнопка

//            // Открываем Popup с информацией о задаче
//            var popup = new TaskDetailsPopup();
//            popup.BindingContext = task;  // Передаем данные задачи в Popup
//            await Navigation.PushAsync(new TaskDetailsPopup(task));  // Переход на страницу с деталями
//        }


//        //private async void LoadTasks()
//        //{
//        //    try
//        //    {
//        //        // Получаем все задачи из Firebase
//        //        var tasks = await _firebaseClient
//        //            .Child("Tasks")
//        //            .OnceAsync<Tasks>();

//        //        // Фильтруем задачи, если они принадлежат текущему сотруднику
//        //        _tasks = tasks
//        //            .Where(t => t.Object.EmployeeId == App.CurrentUser.EmployeeId)  // Сравниваем по EmployeeId
//        //            .Select(t => t.Object)
//        //            .ToList();

//        //        // Привязываем задачи к интерфейсу
//        //        TasksCollectionView.ItemsSource = _tasks;
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        // Логируем ошибку и отображаем сообщение
//        //        Console.WriteLine($"Error loading tasks: {ex.Message}");
//        //        await DisplayAlert("Ошибка", $"Произошла ошибка: {ex.Message}", "OK");
//        //    }
//        //}





//        //private async void MoreInfBtn_Clicked(object sender, EventArgs e)
//        //{
//        //    var button = sender as Button;
//        //    var task = button?.BindingContext as Tasks;
//        //    if (task != null)
//        //    {
//        //        await Navigation.PushAsync(new TaskDetailsPopup(task));  // Переход на страницу с деталями
//        //    }
//        //}
//    }
//}
