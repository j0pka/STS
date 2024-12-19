namespace STSerApp
{
    public partial class AppShell : Shell
    {
        public static string CurrentEmployeeId { get; private set; }
        public AppShell()
        {
            InitializeComponent();


        }
        public static void SetCurrentEmployee(string employeeId)
        {
            CurrentEmployeeId = employeeId;
        }
    }
}