using System;
using System.ComponentModel;

namespace ScheduleOneInventory.Models
{
    public class EmployeeModel : INotifyPropertyChanged
    {
        private int _employeeID;
        private string _employeeName;
        private string _employeePosition;
        private int _userID;

        public int EmployeeID
        {
            get => _employeeID;
            set
            {
                _employeeID = value;
                OnPropertyChanged(nameof(EmployeeID));
            }
        }

        public string EmployeeName
        {
            get => _employeeName;
            set
            {
                _employeeName = value;
                OnPropertyChanged(nameof(EmployeeName));
            }
        }

        public string EmployeePosition
        {
            get => _employeePosition;
            set
            {
                _employeePosition = value;
                OnPropertyChanged(nameof(EmployeePosition));
            }
        }

        public int UserID
        {
            get => _userID;
            set
            {
                _userID = value;
                OnPropertyChanged(nameof(UserID));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}