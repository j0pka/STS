using System;
using System.Timers; // ���������, ��� ������������ System.Timers.Timer
using STSerApp.Models;
namespace STSerApp.Page
{
    public partial class PathwayTasks : ContentPage
    {
        private System.Timers.Timer _timer; // ����� �������� ���� Timer
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
            // ������������� ����� ������ � ���������
            _startDate = DateTime.Today.AddHours(11).AddMinutes(30); // ������ � 11:30
            _endDate = DateTime.Today.AddHours(14); // ����� � 14:00

            // ������������ ��������� ���������� �����
            _remainingTime = _endDate - DateTime.Now;

            // ��������� ������� ��� ���������� ������ �������
            _timer = new System.Timers.Timer(1000); // ����� ������������� System.Timers.Timer
            _timer.Elapsed += OnTimerElapsed;
            _timer.Start();
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            // ���������� ����������� �������
            _remainingTime = _endDate - DateTime.Now;

            // ���� ���������� ����� ������ 0, ������������� ������
            if (_remainingTime <= TimeSpan.Zero)
            {
                _timer.Stop();
                _remainingTime = TimeSpan.Zero;  // ��������� ���������� ����� �� 0
            }

            // ��������� UI, ��������� MainThread ��� ������ � ���������� UI
            Device.BeginInvokeOnMainThread(() =>
            {
                // ��������� ������� ��� ����������� �������
                RemainingTimeLabel.Text = $"�������� {_remainingTime:hh\\:mm\\:ss}";

                // ��������� ����� ���������
                EndTimeLabel.Text = $"����� � {_endDate:HH:mm}";
            });
        }

        // ����� �������� �����������, ��������� ������
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _timer.Stop();
        }
    }
}
