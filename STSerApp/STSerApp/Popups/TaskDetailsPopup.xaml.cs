using CommunityToolkit.Maui.Views;

namespace STSerApp.Popups;

public partial class TaskDetailsPopup : Popup
{
    public TaskDetailsPopup(object task)
    {
        InitializeComponent();
        BindingContext = task; // Привязываем данные задачи
    }

    // Закрытие всплывающего окна
    private void ClosePopup(object sender, EventArgs e)
    {
        Close();
    }
}
