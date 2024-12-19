using STSerApp.Models;  

namespace STSerApp.Page
{
    public partial class TaskDetailsPage : ContentPage
    {
        public TaskDetailsPage(Tasks task)
        {
            InitializeComponent();
            BindingContext = task;
        }

        private async void closeButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();  // Закрывает модальное окно
        }
    }
}