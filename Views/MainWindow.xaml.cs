using ScheduleOneInventoryManager.Services;
using ScheduleOneInventoryManager.Views;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ScheduleOneInventoryManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WindowService _windowService;
        private UserService _userService;
        public MainWindow()
        {
            InitializeComponent();
            initializeWindowManager();
            _userService = new UserService();
        }

        public void initializeWindowManager()
        {
            _windowService = new WindowService(this);
        }

        // Window control methods
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _windowService.MoveWindow(sender, e);
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            _windowService.MinimizeApplication(sender, e);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            _windowService.ExitApplication(sender, e);
        }

        // Text field methods
        private void textUsername_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtUsername.Focus();
        }

        private void textUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUsername.Text) && txtUsername.Text.Length > 0)
            {
                textUsername.Visibility = Visibility.Collapsed;
            }
            else
            {
                textUsername.Visibility = Visibility.Visible;
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            int? loggedInUserId = _userService.Login(username, password);
            if (loggedInUserId.HasValue)
            {
                Dashboard dashboard = new Dashboard(username, loggedInUserId.Value);
                dashboard.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Authentication Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void textPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtPassword.Focus();
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPassword.Password) && txtPassword.Password.Length > 0)
            {
                textPassword.Visibility = Visibility.Collapsed;
            }
            else
            {
                textPassword.Visibility = Visibility.Visible;
            }
        }
    }
}