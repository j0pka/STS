//using Android.Mtp;
using Plugin.Maui.Calendar.Models;
using System.Globalization;

namespace STSerApp.Page;

public partial class GraphPage : ContentPage
{
    public EventCollection Events { get; set; }
    public CultureInfo Culture => new CultureInfo("ru-RU");
    public GraphPage()
	{
		InitializeComponent();

        Events = new EventCollection
        {
       
            // custom date
            [new DateTime(2024, 11, 1)] = new List<EventModel>
    {
        new() { Name = "Рабочий день", Description = "9:00 - Бетонирование площадки" }
    },
            [new DateTime(2024, 11, 2)] = new List<EventModel>
    {
        new() { Name = "Рабочий день", Description = "Заказов на сегодня нет." }
    },
            [new DateTime(2024, 11, 3)] = new List<EventModel>
    {
        new() { Name = "Рабочий день", Description = "10:00 - Укладка асфальта" }
    },
            [new DateTime(2024, 11, 7)] = new List<EventModel>
    {
        new() { Name = "Рабочий день", Description = "10:00 - Демонтаж бетонных конструкций " }
    },
            [new DateTime(2024, 11, 8)] = new List<EventModel>
    {
        new() { Name = "Рабочий день", Description = "14:00 - Очистка строительной площадки" }
    },
            [new DateTime(2024, 11, 11)] = new List<EventModel>
    {
        new() { Name = "Рабочий день", Description = "Заказов на сегодня нет." }
    },
            [new DateTime(2024, 11, 12)] = new List<EventModel>
    {
        new() { Name = "Рабочий день", Description = "11:15 - Подъем строительных материалов" }
    },
            [new DateTime(2024, 11, 13)] = new List<EventModel>
    {
        new() { Name = "Рабочий день", Description = "Заказов на сегодня нет." }
    },
            [new DateTime(2024, 11, 14)] = new List<EventModel>
    {
        new() { Name = "Рабочий день", Description = "Заказов на сегодня нет." }
    },
            [new DateTime(2024, 11, 17)] = new List<EventModel>
    {
        new() { Name = "Рабочий день", Description = "9:30 - Подготовка котлована" }
    },
            [new DateTime(2024, 11, 18)] = new List<EventModel>
    {
        new() { Name = "Рабочий день", Description = "10:45 - Подача бетонной смеси" }
    },
            [new DateTime(2024, 11, 19)] = new List<EventModel>
    {
        new() { Name = "Рабочий день", Description = "Заказов на сегодня нет." }
    },
            [new DateTime(2024, 11, 22)] = new List<EventModel>
    {
        new() { Name = "Рабочий день", Description = "Заказов на сегодня нет." }
    },
            [new DateTime(2024, 11, 23)] = new List<EventModel>
    {
        new() { Name = "Рабочий день", Description = "12:30 - Выравнивание грунта " }
    },
            [new DateTime(2024, 11, 24)] = new List<EventModel>
    {
        new() { Name = "Рабочий день", Description = "Заказов на сегодня нет." }
    },
            [new DateTime(2024, 11, 27)] = new List<EventModel>
    {
        new() { Name = "Рабочий день", Description = "14:00 - Перемещение строительного мусора" }
    },
            [new DateTime(2024, 11, 28)] = new List<EventModel>
    {
        new() { Name = "Рабочий день", Description = "Заказов на сегодня нет." }
    }

        };

        BindingContext = this;
    }
}

internal class EventModel
{
    public string Name { get; set; }
    public string Description { get; set; }
}