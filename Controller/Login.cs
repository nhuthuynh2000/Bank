using BankSystem.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Controller
{
    internal class Login
    {
        private string connectionString = "server=BAONGOC\\DULICH;Initial Catalog=DotNet;User ID=sa;Password=123456";
        EmployeeController employeeController = new EmployeeController();
        public bool LoginController(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM EMPLOYEE WHERE id = @username AND password = @password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password); 
                  
                    int result = (int)command.ExecuteScalar();
                    if(result > 0)
                    {
                        EmployeeModel employee = GetEmployeeByUsername(username);
                        employeeController.SetActiveEmployee(employee); // Thiết lập nhân viên đang hoạt động
                        return true; 
                    }
                    return false; 
                }
            }
        }

        private EmployeeModel GetEmployeeByUsername(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM EMPLOYEE WHERE id = @username"; 
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                           
                            return new EmployeeModel
                            {
                                id = reader["id"].ToString(),
                                
                            };
                        }
                    }
                }
            }
            return null; 
        }

        public string GetRole(string id, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT role FROM EMPLOYEE WHERE id = @id AND password = @password";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@password", password);

                    string result = (string)cmd.ExecuteScalar();
                    return result;
                }
            }
        }
    }
}
