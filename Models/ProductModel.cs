using System;
using System.ComponentModel;

namespace ScheduleOneInventoryManager.Models
{
    public class ProductModel : INotifyPropertyChanged
    {
        private int _productID;
        private string _productName;
        private decimal _productPrice; // Changed to decimal
        private int _productQuantity;
        private string _productQuality;
        private int _productSelling;
        private int _userID;
        private string _productIngredients;

        public int ProductID
        {
            get => _productID;
            set
            {
                _productID = value;
                OnPropertyChanged(nameof(ProductID));
            }
        }

        public string ProductName
        {
            get => _productName;
            set
            {
                _productName = value;
                OnPropertyChanged(nameof(ProductName));
            }
        }

        public decimal ProductPrice // Changed to decimal
        {
            get => _productPrice;
            set
            {
                _productPrice = value;
                OnPropertyChanged(nameof(ProductPrice));
            }
        }

        public int ProductQuantity
        {
            get => _productQuantity;
            set
            {
                _productQuantity = value;
                OnPropertyChanged(nameof(ProductQuantity));
            }
        }

        public string ProductQuality
        {
            get => _productQuality;
            set
            {
                _productQuality = value;
                OnPropertyChanged(nameof(ProductQuality));
            }
        }

        public int ProductSelling
        {
            get => _productSelling;
            set
            {
                _productSelling = value;
                OnPropertyChanged(nameof(ProductSelling));
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

        public string ProductIngredients
        {
            get => _productIngredients;
            set
            {
                _productIngredients = value;
                OnPropertyChanged(nameof(ProductIngredients));
            }
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}