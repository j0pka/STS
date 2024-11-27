using System.Collections.ObjectModel;

namespace STSerApp.Page;

public partial class CurrentTasks : ContentPage
{
    // ��������� �����
    public ObservableCollection<TaskModel> Tasks { get; set; }

    public CurrentTasks()
    {
        InitializeComponent();

        // ������������� ������ �����
        Tasks = new ObservableCollection<TaskModel>
            {
                new TaskModel
                {
                    Title = "������������� ��������",
                    Date = new DateTime(2024, 11, 1, 9, 0, 0),
                    Vehicle = "�������������",
                    Description = "������� ������ ��� ��������� ���������� ��������."
                },
                new TaskModel
                {
                    Title = "������� ��������",
                    Date = new DateTime(2024, 11, 3, 10, 0, 0),
                    Vehicle = "�����",
                    Description = "��������������� ��������� �������� �� ������� ���������."
                },
                new TaskModel
                {
                    Title = "�������� �������� �����������",
                    Date = new DateTime(2024, 11, 7, 10, 0, 0),
                    Vehicle = "����������",
                    Description = "���� � ��������� �������� ���� � ����������� ������� ������."
                },
                new TaskModel
                {
                    Title = "������� ������������ ��������",
                    Date = new DateTime(2024, 11, 8, 14, 0, 0),
                    Vehicle = "���������",
                    Description = "������ ������������� ������ � �������������� ��������� ����������."
                },
                new TaskModel
                {
                    Title = "������ ������������ ����������",
                    Date = new DateTime(2024, 11, 12, 11, 15, 0),
                    Vehicle = "����",
                    Description = "�������� ������������ ������ �� ������ �������� �����."
                },
                new TaskModel
                {
                    Title = "���������� ���������",
                    Date = new DateTime(2024, 11, 17, 9, 30, 0),
                    Vehicle = "����������",
                    Description = "����� ��������� ��� ����������� ������������� ����������."
                },
                new TaskModel
                {
                    Title = "������ �������� �����",
                    Date = new DateTime(2024, 11, 18, 10, 45, 0),
                    Vehicle = "�������������",
                    Description = "������ �������� ����� � ����� ������� ����������."
                },
                new TaskModel
                {
                    Title = "������������ ������",
                    Date = new DateTime(2024, 11, 23, 12, 30, 0),
                    Vehicle = "���������",
                    Description = "����������� ������������� ������ �� ������������ ��������."
                },
                new TaskModel
                {
                    Title = "����������� ������������� ������",
                    Date = new DateTime(2024, 11, 19, 14, 0, 0),
                    Vehicle = "���������",
                    Description = "����������� �������� ������������� ������ ��� ���������� ����������."
                }
            };

        BindingContext = this; // ��������� ��������� ������ ��� �������� � ����������
    }
}
public class TaskModel
{
    public string Title { get; set; } // �������� ������
    public DateTime Date { get; set; } // ���� � ����� ���������� ������
    public string Vehicle { get; set; } // ���������/�������
    public string Description { get; set; } // ������� �������� ������
}