using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BankSystem.Model;

namespace BankSystem.Controller
{
    internal class BranchController : IController
    {
        private readonly string connectionString = "server=BAONGOC\\DULICH;Initial Catalog=DotNet;User ID=sa;Password=123456";
        private List<IModel> branches = new List<IModel>();
        public List<IModel> Items => branches;

        public bool Create(IModel model)
        {
            if (model is BranchModel branch)
            {
                SqlConnection conn = new SqlConnection(connectionString);
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO BRANCH (id, name, house_no, city) VALUES (@id, @name, @house_no, @city)", conn);
                    cmd.Parameters.AddWithValue("@id", branch.id);
                    cmd.Parameters.AddWithValue("@name", branch.name);
                    cmd.Parameters.AddWithValue("@house_no", branch.house_no);
                    cmd.Parameters.AddWithValue("@city", branch.city);

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
            if (id is BranchModel branch)
            {
                SqlConnection conn = new SqlConnection(connectionString);
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM BRANCH WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", branch.id);

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
            if (model is BranchModel branch)
            {
                SqlConnection conn = new SqlConnection(connectionString);
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM BRANCH WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", branch.id);
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
            branches.Clear();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM BRANCH ORDER BY id ASC", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    BranchModel branch = new BranchModel
                    {
                        id = reader["id"].ToString(),
                        name = reader["name"].ToString(),
                        house_no = reader["house_no"].ToString(),
                        city = reader["city"].ToString()
                    };
                    branches.Add(branch);
                }
                return branches.Count > 0;
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM BRANCH WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    BranchModel branch = new BranchModel
                    {
                        id = reader["id"].ToString(),
                        name = reader["name"].ToString(),
                        house_no = reader["house_no"].ToString(),
                        city = reader["city"].ToString()
                    };
                    branches.Clear();
                    branches.Add(branch);
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
            if (id is BranchModel branch)
            {
                SqlConnection conn = new SqlConnection(connectionString);
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM BRANCH WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", branch.id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return new BranchModel
                        {
                            id = reader["id"].ToString(),
                            name = reader["name"].ToString(),
                            house_no = reader["house_no"].ToString(),
                            city = reader["city"].ToString()
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
            if (model is BranchModel branch)
            {
                SqlConnection conn = new SqlConnection(connectionString);
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE BRANCH SET name = @name, house_no = @house_no, city = @city WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", branch.id);
                    cmd.Parameters.AddWithValue("@name", branch.name);
                    cmd.Parameters.AddWithValue("@house_no", branch.house_no);
                    cmd.Parameters.AddWithValue("@city", branch.city);

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
