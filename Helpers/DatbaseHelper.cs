using System.IO;
using MySqlConnector;
using Microsoft.Extensions.Configuration;

namespace ScheduleOneInventoryManager.Helpers
{
    public static class DatabaseHelper
    {
        private static MySqlConnection _connection;
        private static IConfiguration _configuration;

        public static void InitializeDatabase()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _configuration = builder.Build();

            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            if(!string.IsNullOrEmpty(connectionString))
            {
                _connection = new MySqlConnection(connectionString);
                try
                {
                    _connection.Open();
                    System.Diagnostics.Debug.WriteLine("Connection to database was established.");
                }
                catch(MySqlException ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error connecting to database: {ex.Message}");
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Connection string is empty or not found.");
                _connection = null;
            }
        }

        public static MySqlConnection GetConnection()
        {
            if(_connection == null)
            {
                throw new InvalidOperationException("Database connection is not initialized. Call InitializeDatabase first.");
            }
            return _connection;
        }

        public static void CloseConnection()
        {
            if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    _connection.Close();
                    System.Diagnostics.Debug.WriteLine("Session has been terminated...");
                }
                catch(MySqlException ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
                finally
                {
                    _connection = null;
                }
            }
        }
    }
}