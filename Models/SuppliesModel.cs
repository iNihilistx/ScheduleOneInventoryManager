using System;
using System.ComponentModel;

namespace ScheduleOneInventoryManager.Models
{
    public class SuppliesModel : INotifyPropertyChanged
    {
        private int _supplyID;
        private string _supplyName;
        private int _supplyPrice;
        private int _supplyQuantity;
        private int _userID;

        public int SupplyID
        {
            get => _supplyID;
            set
            {
                _supplyID = value;
                OnPropertyChanged(nameof(SupplyID));
            }
        }

        public string SupplyName
        {
            get => _supplyName;
            set
            {
                _supplyName = value;
                OnPropertyChanged(nameof(SupplyName));
            }
        }

        public int SupplyPrice
        {
            get => _supplyPrice;
            set
            {
                _supplyPrice = value;
                OnPropertyChanged(nameof(SupplyPrice));
            }
        }

        public int SupplyQuantity
        {
            get => _supplyQuantity;
            set
            {
                _supplyQuantity = value;
                OnPropertyChanged(nameof(SupplyQuantity));
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