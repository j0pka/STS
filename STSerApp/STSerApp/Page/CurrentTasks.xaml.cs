using System.Collections.ObjectModel;
using System.Net;
using CommunityToolkit.Maui.Views;
using STSerApp.Popups;

namespace STSerApp.Page;

public partial class CurrentTasks : ContentPage
{
    // Коллекция задач
    public ObservableCollection<TaskModel> Tasks { get; set; }

    public CurrentTasks()
    {
        InitializeComponent();

        // Инициализация данных задач
        Tasks = new ObservableCollection<TaskModel>
            {
                new TaskModel
                {
                    Title = "Бетонирование площадки",
                    Date = new DateTime(2024, 11, 1, 9, 0, 0),
                    Vehicle = "Бетономешалка",
                    Description = "Подготовка площадки к заливке. Заливка бетона для основания спортивной площадки.",
                    Customer = "ООО Флагман (Иванов Петр Сергеевич)",
                    CustomerPhone = "+7 963 657-67-65",
                    Address ="г. Корсаков ул. Ленина д.5"

                },
                new TaskModel
                {
                    Title = "Укладка асфальта",
                    Date = new DateTime(2024, 11, 3, 10, 0, 0),
                    Vehicle = "Каток",
                    Description = "Асфальтирование дорожного покрытия на объекте заказчика. Предварительное выравниевание.",
                    Customer = "ООО СТОРОЙДОМ (Плесков Сергей Иванович)",
                    CustomerPhone = "+7 963 657-67-65",
                    Address ="г. Южно-Сахалинск ул. Ленина д.5"
                },
                new TaskModel
                {
                    Title = "Демонтаж бетонных конструкций",
                    Date = new DateTime(2024, 11, 7, 10, 0, 0),
                    Vehicle = "Экскаватор",
                    Description = "Снос и дробление бетонных стен с последующим вывозом мусора.",
                    Customer = "ИП Белов Андрей Сергеевич",
                    CustomerPhone = "+7 963 657-67-65",
                    Address ="г. Корсаков ул. Ленина д.52"

                },
                new TaskModel
                {
                    Title = "Очистка строительной площадки",
                    Date = new DateTime(2024, 11, 8, 14, 0, 0),
                    Vehicle = "Погрузчик",
                    Description = "Уборка строительного мусора с использованием ковшового погрузчика.",
                    Customer = "ООО Флагман (Иванов Петр Сергеевич)",
                    CustomerPhone = "+7 963 657-67-65",
                    Address ="г. Корсаков ул. Ленина д.5"
                },
                new TaskModel
                {
                    Title = "Подъем строительных материалов",
                    Date = new DateTime(2024, 11, 12, 11, 15, 0),
                    Vehicle = "Кран",
                    Description = "Доставка строительных блоков на высоту третьего этажа.",
                    Customer = "ООО Флагман (Иванов Петр Сергеевич)",
                    CustomerPhone = "+7 963 657-67-65",
                    Address ="г. Корсаков ул. Ленина д.5"
                },
                new TaskModel
                {
                    Title = "Подготовка котлована",
                    Date = new DateTime(2024, 11, 17, 9, 30, 0),
                    Vehicle = "Экскаватор",
                    Description = "Рытье котлована для дальнейшего строительства фундамента.",
                    Customer = "ООО Флагман (Иванов Петр Сергеевич)",
                    CustomerPhone = "+7 963 657-67-65",
                    Address ="г. Корсаков ул. Ленина д.5"
                },
                new TaskModel
                {
                    Title = "Подача бетонной смеси",
                    Date = new DateTime(2024, 11, 18, 10, 45, 0),
                    Vehicle = "Бетономешалка",
                    Description = "Подача бетонной смеси к месту заливки фундамента.",
                    Customer = "ООО Флагман (Иванов Петр Сергеевич)",
                    CustomerPhone = "+7 963 657-67-65",
                    Address ="г. Корсаков ул. Ленина д.5"
                },
                new TaskModel
                {
                    Title = "Выравнивание грунта",
                    Date = new DateTime(2024, 11, 23, 12, 30, 0),
                    Vehicle = "Бульдозер",
                    Description = "Равномерное распределение грунта по строительной площадке.",
                    Customer = "ООО Флагман (Иванов Петр Сергеевич)",
                    CustomerPhone = "+7 963 657-67-65",
                    Address ="г. Корсаков ул. Ленина д.5"
                },
                new TaskModel
                {
                    Title = "Перемещение строительного мусора",
                    Date = new DateTime(2024, 11, 19, 14, 0, 0),
                    Vehicle = "Погрузчик",
                    Description = "Перемещение крупного строительного мусора для дальнейшей утилизации.",
                    Customer = "ООО Флагман (Иванов Петр Сергеевич)",
                    CustomerPhone = "+7 963 657-67-65",
                    Address ="г. Корсаков ул. Ленина д.5"

                }
            };

        BindingContext = this; // Установка контекста данных для привязки к интерфейсу
    }
    // Метод для обработки нажатия кнопки "Больше информации"
    private async void OnMoreInfoClicked(object sender, EventArgs e)
    {
        // Получение контекста задачи из нажатой кнопки
        if (sender is Button button && button.BindingContext is TaskModel task)
        {
            // Открытие всплывающего окна с деталями задачи
            await this.ShowPopupAsync(new TaskDetailsPopup(task));
        }
    }
}

public class TaskModel
{
    public string Title { get; set; } // Название задачи
    public DateTime Date { get; set; } // Дата и время выполнения задачи
    public string Vehicle { get; set; } // Транспорт/техника
    public string Description { get; set; } // Краткое описание задачи
    public string Customer { get; set; } 
    public string CustomerPhone { get; set; }
    public string Address { get; set; }
}
