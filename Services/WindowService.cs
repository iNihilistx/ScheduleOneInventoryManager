using System.Windows;
using System.Windows.Controls;
using System;
using System.Windows.Input;

namespace ScheduleOneInventoryManager.Services
{
    public class WindowService
    {
        private readonly Window _window;
        public WindowService(Window window)
        {
            _window = window;
        }

        public void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                _window.DragMove();
            }
        }

        public void ExitApplication(object sender, RoutedEventArgs e)
        {
            _window.Close();
        }

        public void MinimizeApplication(object sender, RoutedEventArgs e)
        {
            _window.WindowState = WindowState.Minimized;
        }
    }
}