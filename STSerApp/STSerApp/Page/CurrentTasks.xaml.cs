using System.Collections.ObjectModel;
using System.Net;
using CommunityToolkit.Maui.Views;
using STSerApp.Popups;

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
                    Description = "���������� �������� � �������. ������� ������ ��� ��������� ���������� ��������.",
                    Customer = "��� ������� (������ ���� ���������)",
                    CustomerPhone = "+7 963 657-67-65",
                    Address ="�. �������� ��. ������ �.5"

                },
                new TaskModel
                {
                    Title = "������� ��������",
                    Date = new DateTime(2024, 11, 3, 10, 0, 0),
                    Vehicle = "�����",
                    Description = "��������������� ��������� �������� �� ������� ���������. ��������������� �������������.",
                    Customer = "��� ��������� (������� ������ ��������)",
                    CustomerPhone = "+7 963 657-67-65",
                    Address ="�. ����-��������� ��. ������ �.5"
                },
                new TaskModel
                {
                    Title = "�������� �������� �����������",
                    Date = new DateTime(2024, 11, 7, 10, 0, 0),
                    Vehicle = "����������",
                    Description = "���� � ��������� �������� ���� � ����������� ������� ������.",
                    Customer = "�� ����� ������ ���������",
                    CustomerPhone = "+7 963 657-67-65",
                    Address ="�. �������� ��. ������ �.52"

                },
                new TaskModel
                {
                    Title = "������� ������������ ��������",
                    Date = new DateTime(2024, 11, 8, 14, 0, 0),
                    Vehicle = "���������",
                    Description = "������ ������������� ������ � �������������� ��������� ����������.",
                    Customer = "��� ������� (������ ���� ���������)",
                    CustomerPhone = "+7 963 657-67-65",
                    Address ="�. �������� ��. ������ �.5"
                },
                new TaskModel
                {
                    Title = "������ ������������ ����������",
                    Date = new DateTime(2024, 11, 12, 11, 15, 0),
                    Vehicle = "����",
                    Description = "�������� ������������ ������ �� ������ �������� �����.",
                    Customer = "��� ������� (������ ���� ���������)",
                    CustomerPhone = "+7 963 657-67-65",
                    Address ="�. �������� ��. ������ �.5"
                },
                new TaskModel
                {
                    Title = "���������� ���������",
                    Date = new DateTime(2024, 11, 17, 9, 30, 0),
                    Vehicle = "����������",
                    Description = "����� ��������� ��� ����������� ������������� ����������.",
                    Customer = "��� ������� (������ ���� ���������)",
                    CustomerPhone = "+7 963 657-67-65",
                    Address ="�. �������� ��. ������ �.5"
                },
                new TaskModel
                {
                    Title = "������ �������� �����",
                    Date = new DateTime(2024, 11, 18, 10, 45, 0),
                    Vehicle = "�������������",
                    Description = "������ �������� ����� � ����� ������� ����������.",
                    Customer = "��� ������� (������ ���� ���������)",
                    CustomerPhone = "+7 963 657-67-65",
                    Address ="�. �������� ��. ������ �.5"
                },
                new TaskModel
                {
                    Title = "������������ ������",
                    Date = new DateTime(2024, 11, 23, 12, 30, 0),
                    Vehicle = "���������",
                    Description = "����������� ������������� ������ �� ������������ ��������.",
                    Customer = "��� ������� (������ ���� ���������)",
                    CustomerPhone = "+7 963 657-67-65",
                    Address ="�. �������� ��. ������ �.5"
                },
                new TaskModel
                {
                    Title = "����������� ������������� ������",
                    Date = new DateTime(2024, 11, 19, 14, 0, 0),
                    Vehicle = "���������",
                    Description = "����������� �������� ������������� ������ ��� ���������� ����������.",
                    Customer = "��� ������� (������ ���� ���������)",
                    CustomerPhone = "+7 963 657-67-65",
                    Address ="�. �������� ��. ������ �.5"

                }
            };

        BindingContext = this; // ��������� ��������� ������ ��� �������� � ����������
    }
    // ����� ��� ��������� ������� ������ "������ ����������"
    private async void OnMoreInfoClicked(object sender, EventArgs e)
    {
        // ��������� ��������� ������ �� ������� ������
        if (sender is Button button && button.BindingContext is TaskModel task)
        {
            // �������� ������������ ���� � �������� ������
            await this.ShowPopupAsync(new TaskDetailsPopup(task));
        }
    }
}

public class TaskModel
{
    public string Title { get; set; } // �������� ������
    public DateTime Date { get; set; } // ���� � ����� ���������� ������
    public string Vehicle { get; set; } // ���������/�������
    public string Description { get; set; } // ������� �������� ������
    public string Customer { get; set; } 
    public string CustomerPhone { get; set; }
    public string Address { get; set; }
}
