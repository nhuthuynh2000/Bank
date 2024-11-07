using BankSystem.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BankSystem.Controller
{
    internal class AccountController : IController
    {
        readonly string connectionString = "server=BAONGOC\\DULICH;Initial Catalog=DotNet;User ID=sa;Password=123456";
        List<IModel> accounts = new List<IModel>();
        public List<IModel> Items => accounts;

        public bool Create(IModel model)
        {
            if (model is AccountModel account)
            {
                SqlConnection conn = new SqlConnection(connectionString);
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO ACCOUNT (id, customerid, date_opened, balance) VALUES (@id, @customerid, @date_opened, @balance)", conn);
                    cmd.Parameters.AddWithValue("@id", account.id);
                    cmd.Parameters.AddWithValue("@customerid", account.customerid);
                    cmd.Parameters.AddWithValue("@date_opened", account.date_opened);
                    cmd.Parameters.AddWithValue("@balance", account.balance);

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
            if (id is AccountModel account)
            {
                SqlConnection conn = new SqlConnection(connectionString);
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM ACCOUNT WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", account.id);

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
            if (model is AccountModel account)
            {
                SqlConnection conn = new SqlConnection(connectionString);
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM ACCOUNT WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", account.id);

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
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM ACCOUNT ORDER BY id ASC", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                accounts.Clear();
                while (reader.Read())
                {
                    AccountModel account = new AccountModel
                    {
                        id = reader.GetInt32(0),
                        customerid = reader.GetString(1),
                        date_opened = reader.GetDateTime(2),
                        balance = reader.GetDouble(3)
                    };
                    accounts.Add(account);
                }
                return accounts.Count > 0;
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM ACCOUNT WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();
                accounts.Clear();
                if (reader.Read())
                {
                    AccountModel account = new AccountModel
                    {
                        id = reader.GetInt32(0),
                        customerid = reader.GetString(1),
                        date_opened = reader.GetDateTime(2),
                        balance = reader.GetDouble(3)
                    };
                    accounts.Add(account);
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
            if (id is AccountModel account)
            {
                SqlConnection conn = new SqlConnection(connectionString);
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM ACCOUNT WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", account.id);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return new AccountModel
                        {
                            id = reader.GetInt32(0),
                            customerid = reader.GetString(1),
                            date_opened = reader.GetDateTime(2),
                            balance = reader.GetDouble(3)
                        };
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Error: {ex.Message}");
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
            if (model is AccountModel account)
            {
                SqlConnection conn = new SqlConnection(connectionString);
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE ACCOUNT SET customerid = @customerid, date_opened = @date_opened, balance = @balance WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", account.id);
                    cmd.Parameters.AddWithValue("@customerid", account.customerid);
                    cmd.Parameters.AddWithValue("@date_opened", account.date_opened);
                    cmd.Parameters.AddWithValue("@balance", account.balance);

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
    }
}
