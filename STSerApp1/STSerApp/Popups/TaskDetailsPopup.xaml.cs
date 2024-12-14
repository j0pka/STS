using CommunityToolkit.Maui.Views;
using STSerApp.Page;  // Ёто пространство имен, где должен быть класс TaskDetailsPage


namespace STSerApp.Popups;

public partial class TaskDetailsPopup : Popup
{
    public TaskDetailsPopup(object task)
    {
        InitializeComponent();
        BindingContext = task; // ѕрив€зываем данные задачи
    }


    // «акрытие всплывающего окна
    private void ClosePopup(object sender, EventArgs e)
    {
        Close();
    }
}
