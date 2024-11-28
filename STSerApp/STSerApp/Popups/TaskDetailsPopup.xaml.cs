using CommunityToolkit.Maui.Views;

namespace STSerApp.Popups;

public partial class TaskDetailsPopup : Popup
{
    public TaskDetailsPopup(object task)
    {
        InitializeComponent();
        BindingContext = task; // ����������� ������ ������
    }

    // �������� ������������ ����
    private void ClosePopup(object sender, EventArgs e)
    {
        Close();
    }
}
