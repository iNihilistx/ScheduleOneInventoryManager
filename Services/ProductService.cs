using MySqlConnector;
using ScheduleOneInventoryManager.Helpers;
using ScheduleOneInventoryManager.Models;
using System.Collections.ObjectModel;

namespace ScheduleOneInventoryManager.Services
{
    public class ProductService
    {
        private readonly MySqlConnection _connection;
        public ProductService()
        {
            _connection = DatabaseHelper.GetConnection();
        }

        public ObservableCollection<ProductModel> GetProducts(int userID)
        {
            ObservableCollection<ProductModel> products = new ObservableCollection<ProductModel>();
            try
            {
                using var command = new MySqlCommand("SELECT ProductID, ProductName, ProductPrice, ProductQuantity, ProductQuality, ProductSelling, UserID, ProductIngredients FROM product_table WHERE UserID = @userID", _connection);
                command.Parameters.AddWithValue("@userID", userID);
                using var reader = command.ExecuteReader();
                while(reader.Read())
                {
                    products.Add(new ProductModel
                    {
                        ProductID = reader.GetInt32("ProductID"),
                        ProductName = reader.GetString("ProductName"),
                        ProductPrice = reader.GetInt32("ProductPrice"),
                        ProductQuantity = reader.GetInt32("ProductQuantity"),
                        ProductIngredients = reader.GetString("ProductIngredients"),
                        ProductQuality = reader.GetString("ProductQuality")
                    });
                }
            }
            catch(MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return products;
        }

        public void AddProduct(ProductModel product, int userID)
        {
            try
            {
                using var command = new MySqlCommand("INSERT INTO product_table (ProductName, ProductPrice, ProductQuantity, ProductQuality, UserID, ProductIngredients) VALUES (@productName, @productPrice, @productQuantity, @productQuality, @userID, @productIngredients)", _connection);
                command.Parameters.AddWithValue("@ProductName", product.ProductName);
                command.Parameters.AddWithValue("@ProductPrice", product.ProductPrice);
                command.Parameters.AddWithValue("@ProductQuantity", product.ProductQuantity);
                command.Parameters.AddWithValue("@productIngredients", product.ProductIngredients);
                command.Parameters.AddWithValue("@ProductQuality", product.ProductQuality);
                command.Parameters.AddWithValue("@userID", userID);

                command.ExecuteNonQuery();
            }
            catch(MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public void DeleteProduct(int productID)
        {
            try
            {
                using var command = new MySqlCommand("DELETE FROM product_table WHERE ProductID = @productID", _connection);
                command.Parameters.AddWithValue("@ProductID", productID);
                command.ExecuteNonQuery();
            }
            catch(MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}