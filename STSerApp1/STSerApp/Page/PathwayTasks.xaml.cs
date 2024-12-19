using System;
using System.Timers; // Убедитесь, что используется System.Timers.Timer
using STSerApp.Models;
namespace STSerApp.Page
{
    public partial class PathwayTasks : ContentPage
    {
        private System.Timers.Timer _timer; // Явное указание типа Timer
        private DateTime _startDate;
        private DateTime _endDate;
        private TimeSpan _remainingTime;

        public PathwayTasks()
        {
            InitializeComponent();
            SetupTimer();
        }

        private void SetupTimer()
        {
            // Устанавливаем время начала и окончания
            _startDate = DateTime.Today.AddHours(11).AddMinutes(30); // Начало в 11:30
            _endDate = DateTime.Today.AddHours(14); // Конец в 14:00

            // Рассчитываем начальное оставшееся время
            _remainingTime = _endDate - DateTime.Now;

            // Настройка таймера для обновления каждую секунду
            _timer = new System.Timers.Timer(1000); // Явное использование System.Timers.Timer
            _timer.Elapsed += OnTimerElapsed;
            _timer.Start();
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            // Обновление оставшегося времени
            _remainingTime = _endDate - DateTime.Now;

            // Если оставшееся время меньше 0, останавливаем таймер
            if (_remainingTime <= TimeSpan.Zero)
            {
                _timer.Stop();
                _remainingTime = TimeSpan.Zero;  // Обновляем оставшееся время на 0
            }

            // Обновляем UI, используя MainThread для работы с элементами UI
            Device.BeginInvokeOnMainThread(() =>
            {
                // Обновляем надпись для оставшегося времени
                RemainingTimeLabel.Text = $"Осталось {_remainingTime:hh\\:mm\\:ss}";

                // Обновляем время окончания
                EndTimeLabel.Text = $"Конец в {_endDate:HH:mm}";
            });
        }

        // Когда страница закрывается, остановим таймер
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _timer.Stop();
        }
    }
}
