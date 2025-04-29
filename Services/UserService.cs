using System;
using ScheduleOneInventoryManager.Models;
using ScheduleOneInventoryManager.Helpers;
using MySqlConnector;

namespace ScheduleOneInventoryManager.Services
{
    public class UserService
    {
        private readonly MySqlConnection _connection;

        public UserService()
        {
            try
            {
                _connection = DatabaseHelper.GetConnection();
            }
            catch (InvalidOperationException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public int? Login(string username, string password)
        {
            var command = new MySqlCommand("SELECT LoginID, LoginPassword FROM user_table WHERE LoginUsername = @username", _connection);
            command.Parameters.AddWithValue("@username", username);

            using var reader = command.ExecuteReader();
            try
            {
                if (reader.Read())
                {
                    string storedHash = reader.GetString("LoginPassword");
                    if (PasswordHasher.VerifyPassword(password, storedHash))
                    {
                        return reader.GetInt32("LoginID"); // ONLY return the LoginID on success
                    }
                }
            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return null; // Return null if login fails
        }
    }
}