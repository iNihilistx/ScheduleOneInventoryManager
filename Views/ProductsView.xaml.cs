using System.Windows.Controls;
using System.Collections.ObjectModel;
using ScheduleOneInventoryManager.Services;
using ScheduleOneInventoryManager.Models;
using System.Windows;

namespace ScheduleOneInventoryManager.Views
{
    /// <summary>
    /// Interaction logic for ProductsView.xaml
    /// </summary>
    public partial class ProductsView : UserControl
    {
        private readonly ProductService _productService;
        private readonly int _loggedinUserId;
        private ObservableCollection<ProductModel> _products;

        public ProductsView(int userID)
        {
            InitializeComponent();
            _productService = new ProductService();
            _loggedinUserId = userID;
            LoadProducts();
        }

        private void LoadProducts()
        {
            _products = _productService.GetProducts(_loggedinUserId);
            ProductDataGrid.ItemsSource = _products;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ProductNameTextBox.Text))
            {
                MessageBox.Show("Product Name cannot be empty.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!decimal.TryParse(ProductPriceTextBox.Text, out decimal price))
            {
                MessageBox.Show("Invalid Price.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(ProductQuantityTextBox.Text, out int quantity))
            {
                MessageBox.Show("Invalid Quantity.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(ProductQualityTextBox.Text))
            {
                MessageBox.Show("Product Quality cannot be empty.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var newProduct = new ProductModel
            {
                ProductName = ProductNameTextBox.Text,
                ProductIngredients = ProductIngredientsTextBox.Text,
                ProductPrice = price,
                ProductQuantity = quantity,
                ProductQuality = ProductQualityTextBox.Text,
                UserID = _loggedinUserId
            };

            _productService.AddProduct(newProduct, _loggedinUserId);
            _products.Add(newProduct); // Add the new product to the ObservableCollection
            ClearInputFields();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProductDataGrid.SelectedItem is ProductModel productToDelete)
            {
                // Implement your deletion logic using your ProductService
                _productService.DeleteProduct(productToDelete.ProductID);

                // Remove the deleted item from the ObservableCollection
                if (_products.Contains(productToDelete))
                {
                    _products.Remove(productToDelete);
                }
            }
            else
            {
                MessageBox.Show("Please select a product to delete.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ClearInputFields()
        {
            ProductNameTextBox.Clear();
            ProductIngredientsTextBox.Clear();
            ProductPriceTextBox.Clear();
            ProductQuantityTextBox.Clear();
            ProductQualityTextBox.Clear();
        }
    }
}