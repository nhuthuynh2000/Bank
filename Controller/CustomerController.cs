using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BankSystem.Model;

namespace BankSystem.Controller
{
    internal class CustomerController : IController
    {
        private readonly string connectionString = "server=BAONGOC\\DULICH;Initial Catalog=DotNet;User ID=sa;Password=123456";
        private List<IModel> customers = new List<IModel>();

        public List<IModel> Items => customers;

        public bool Create(IModel model)
        {
            if (model is CustomerModel customer)
            {
                SqlConnection conn = new SqlConnection(connectionString);
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO CUSTOMER (id, name, phone, email, house_no, city, pin) VALUES (@id, @name, @phone, @email, @house_no, @city, @pin)", conn);
                    cmd.Parameters.AddWithValue("@id", customer.id);
                    cmd.Parameters.AddWithValue("@name", customer.name);
                    cmd.Parameters.AddWithValue("@phone", customer.phone);
                    cmd.Parameters.AddWithValue("@email", customer.email);
                    cmd.Parameters.AddWithValue("@house_no", customer.house_no);
                    cmd.Parameters.AddWithValue("@city", customer.city);
                    cmd.Parameters.AddWithValue("@pin", customer.pin);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
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
            if (id is CustomerModel customer)
            {
                SqlConnection conn = new SqlConnection(connectionString);
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM CUSTOMER WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", customer.id);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
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
            if (model is CustomerModel customer)
            {
                SqlConnection conn = new SqlConnection(connectionString);
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM CUSTOMER WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", customer.id);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
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
            customers.Clear();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM CUSTOMER ORDER BY id ASC", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    CustomerModel customer = new CustomerModel
                    {
                        id = reader["id"].ToString(),
                        name = reader["name"].ToString(),
                        phone = reader["phone"].ToString(),
                        email = reader["email"].ToString(),
                        house_no = reader["house_no"].ToString(),
                        city = reader["city"].ToString(),
                        pin = reader["pin"].ToString()
                    };
                    customers.Add(customer);
                }
                return customers.Count > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM CUSTOMER WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    CustomerModel customer = new CustomerModel
                    {
                        id = reader["id"].ToString(),
                        name = reader["name"].ToString(),
                        phone = reader["phone"].ToString(),
                        email = reader["email"].ToString(),
                        house_no = reader["house_no"].ToString(),
                        city = reader["city"].ToString(),
                        pin = reader["pin"].ToString()
                    };
                    customers.Clear();
                    customers.Add(customer);
                    return true;
                }
                return false;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public IModel Read(IModel id)
        {
            if (id is CustomerModel customer)
            {
                SqlConnection conn = new SqlConnection(connectionString);
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM CUSTOMER WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", customer.id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return new CustomerModel
                        {
                            id = reader["id"].ToString(),
                            name = reader["name"].ToString(),
                            phone = reader["phone"].ToString(),
                            email = reader["email"].ToString(),
                            house_no = reader["house_no"].ToString(),
                            city = reader["city"].ToString(),
                            pin = reader["pin"].ToString()
                        };
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
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
            if (model is CustomerModel customer)
            {
                SqlConnection conn = new SqlConnection(connectionString);
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE CUSTOMER SET name = @name, phone = @phone, email = @email, house_no = @house_no, city = @city, pin = @pin WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", customer.id);
                    cmd.Parameters.AddWithValue("@name", customer.name);
                    cmd.Parameters.AddWithValue("@phone", customer.phone);
                    cmd.Parameters.AddWithValue("@email", customer.email);
                    cmd.Parameters.AddWithValue("@house_no", customer.house_no);
                    cmd.Parameters.AddWithValue("@city", customer.city);
                    cmd.Parameters.AddWithValue("@pin", customer.pin);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
            return false;
        }
    }
}
