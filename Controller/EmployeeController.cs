using BankSystem.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BankSystem.Controller
{
    internal class EmployeeController : IController
    {
        private readonly string connectionString = "server=BAONGOC\\DULICH;Initial Catalog=DotNet;User ID=sa;Password=123456";
        private List<IModel> employees = new List<IModel>();
        public List<IModel> Items => employees;

        private static EmployeeModel activeEmployee;

        public bool Create(IModel model)
        {
            if (model is EmployeeModel employee)
            {
                SqlConnection conn = new SqlConnection(connectionString);
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO EMPLOYEE (id, password, role) VALUES (@id, @password, @role)", conn);
                    cmd.Parameters.AddWithValue("@id", employee.id);
                    cmd.Parameters.AddWithValue("@password", employee.password);
                    cmd.Parameters.AddWithValue("@role", employee.role);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Error: {ex.Message}");
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
            return false;
        }

        public bool Delete(IModel id)
        {
            if (id is EmployeeModel employee)
            {
                SqlConnection conn = new SqlConnection(connectionString);
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM EMPLOYEE WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", employee.id);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Error: {ex.Message}");
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
            return false;
        }

        public bool IsExist(object model)
        {
            if (model is EmployeeModel employee)
            {
                SqlConnection conn = new SqlConnection(connectionString);
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM EMPLOYEE WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", employee.id);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Error: {ex.Message}");
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
            return false;
        }

        public bool Load()
        {
            employees.Clear();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM EMPLOYEE ORDER BY id ASC", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EmployeeModel employee = new EmployeeModel
                    {
                        id = reader.GetString(0),
                        password = reader.GetString(1),
                        role = reader.GetString(2)
                    };
                    employees.Add(employee);
                }
                return employees.Count > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool Load(object id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM EMPLOYEE WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    EmployeeModel employee = new EmployeeModel
                    {
                        id = reader.GetString(0),
                        password = reader.GetString(1),
                        role = reader.GetString(2)
                    };
                    employees.Clear();
                    employees.Add(employee);
                    return true;
                }
                return false;
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public IModel Read(IModel id)
        {
            if (id is EmployeeModel employee)
            {
                SqlConnection conn = new SqlConnection(connectionString);
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM EMPLOYEE WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", employee.id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return new EmployeeModel
                        {
                            id = reader.GetString(0),
                            password = reader.GetString(1),
                            role = reader.GetString(2)
                        };
                    }
                    return null;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Error: {ex.Message}");
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
            return null;
        }

        public bool Update(IModel model)
        {
            if (model is EmployeeModel employee)
            {
                SqlConnection conn = new SqlConnection(connectionString);
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE EMPLOYEE SET password = @password, role = @role WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", employee.id);
                    cmd.Parameters.AddWithValue("@password", employee.password);
                    cmd.Parameters.AddWithValue("@role", employee.role);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Error: {ex.Message}");
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
            return false;
        }
        // Lấy thông tin nhân viên đang hoạt động.
        public EmployeeModel GetActiveEmployee()
        {
            return activeEmployee;
        }
        // Đặt nhân viên đang hoạt động.

        public void SetActiveEmployee(EmployeeModel employee)
        {
            activeEmployee = employee;
        }
    }
}
