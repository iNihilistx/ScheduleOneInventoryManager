using System.Configuration;
using System.Data;
using System.Windows;
using ScheduleOneInventoryManager.Services;
using ScheduleOneInventoryManager.Helpers;

namespace ScheduleOneInventoryManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            DatabaseHelper.InitializeDatabase();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            DatabaseHelper.CloseConnection();
        }
    }
}
