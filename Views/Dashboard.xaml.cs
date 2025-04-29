using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ScheduleOneInventoryManager.Services;

namespace ScheduleOneInventoryManager.Views
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        private WindowService _windowService;
        private string _loggedInUsername;
        private int _loggedinUserID;
        public Dashboard(string username, int userId)
        {
            InitializeComponent();
            _loggedInUsername = username;
            _loggedinUserID = userId;
            txtUsernameDisplay.Text = $"Welcome, {_loggedInUsername}!";
            _windowService = new WindowService(this);
        }

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

        private void LocationsButton_Click(object sender, RoutedEventArgs e)
        {
            contentPresenter.Content = new LocationsView();
            SetActiveButton(sender as Button);
        }

        private void ProductsButton_Click(object sender, RoutedEventArgs e)
        {
            contentPresenter.Content = new ProductsView(_loggedinUserID);
            SetActiveButton(sender as Button);
        }

        private void EmployeesButton_Click(object sender, RoutedEventArgs e)
        {
            contentPresenter.Content = new EmployeesView();
            SetActiveButton(sender as Button);
        }

        private void SuppliesButton_Click(object sender, RoutedEventArgs e)
        {
            contentPresenter.Content = new SuppliesView();
            SetActiveButton(sender as Button);
        }

        private void SetActiveButton(Button activeButton)
        {
            // Remove the "ActiveMenuButton" style from all menu buttons
            LocationsButton.Style = (Style)FindResource("MenuButton");
            ProductsButton.Style = (Style)FindResource("MenuButton");
            EmployeesButton.Style = (Style)FindResource("MenuButton");
            SuppliesButton.Style = (Style)FindResource("MenuButton");

            // Apply the "ActiveMenuButton" style to the clicked button
            if (activeButton != null)
            {
                activeButton.Style = (Style)FindResource("ActiveMenuButton");
            }
        }
    }
}