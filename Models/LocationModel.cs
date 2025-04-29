using System;
using System.ComponentModel;

namespace ScheduleOneInventoryManager.Models
{
    public class LocationModel : INotifyPropertyChanged
    {
        private int _locationID;
        private string _locationName;
        private string _locationType;
        private int _locationCost;
        private int _locationEmployees;
        private int _userID;

        public int LocationID
        {
            get => _locationID;
            set
            {
                _locationID = value;
                OnPropertyChanged(nameof(LocationID));
            }
        }

        public string LocationName
        {
            get => _locationName;
            set
            {
                _locationName = value;
                OnPropertyChanged(nameof(LocationName));
            }
        }

        public string LocationType
        {
            get => _locationType;
            set
            {
                _locationType = value;
                OnPropertyChanged(nameof(LocationType));
            }
        }

        public int LocationCost
        {
            get => _locationCost;
            set
            {
                _locationCost = value;
                OnPropertyChanged(nameof(LocationCost));
            }
        }

        public int LocationEmployees
        {
            get => _locationEmployees;
            set
            {
                _locationEmployees = value;
                OnPropertyChanged(nameof(LocationEmployees));
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