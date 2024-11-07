using BankSystem.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Transactions;

namespace BankSystem.Controller
{
    internal class TransactionController : IController
    {
        private readonly string connectionString = "server=BAONGOC\\DULICH;Initial Catalog=DotNet;User ID=sa;Password=123456";
        private List<IModel> transactions = new List<IModel>();
        public List<IModel> Items => transactions;

        public bool IsExist(object model)
        {
            if (model is TransactionModel transaction)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                 
                    string query = "SELECT COUNT(*) FROM [ACCOUNT] WHERE id = @accountId";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                   
                        command.Parameters.AddWithValue("@accountId", transaction.from_account_id);

                        int count = (int)command.ExecuteScalar();
                        return count > 0; 
                    }
                }
            }
            return false; 
        }


        public bool Create(IModel model)
        {
            if (model is TransactionModel transaction)
            {
               

                // Lấy from_account_id từ transaction và gán to_account_id bằng from_account_id
                int fromAccountId = transaction.from_account_id; 
                int toAccountId = fromAccountId;


               
                if (!AccountExists(fromAccountId))
                {
                    MessageBox.Show("Tài khoản không tồn tại.");
                    return false; 
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Lấy giá trị ID tiếp theo
                    transaction.id = GetNextTransactionId();

                    string query = "INSERT INTO [TRANSACTION] (id, from_account_id, branch_id, date_of_trans, amount, to_account_id, employee_id) VALUES (@id, @from_account_id, @branch_id, @date_of_trans, @amount, @to_account_id, @employee_id)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", transaction.id);
                        command.Parameters.AddWithValue("@from_account_id", fromAccountId); 
                        command.Parameters.AddWithValue("@branch_id", transaction.branch_id);
                  

                        if (transaction.date_of_trans == null || transaction.date_of_trans == DateTime.MinValue)
                        {
                           
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@date_of_trans", transaction.date_of_trans);
                            
                        }
                        command.Parameters.AddWithValue("@amount", transaction.amount);
                      
                        command.Parameters.AddWithValue("@to_account_id", toAccountId); 
                     
                        command.Parameters.AddWithValue("@employee_id", transaction.employee_id);
                

                        try
                        {
                            int rowsAffected = command.ExecuteNonQuery();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
                            return false;
                        }
                        return false;
                       
                    }
                }
            }
            return false; 
        }


        private bool AccountExists(int accountId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM ACCOUNT WHERE id = @accountId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@accountId", accountId);
                    int count = (int)command.ExecuteScalar();
                    return count > 0; 
                }
            }
        }

        //Làm id tự động tăng
        public int GetNextTransactionId()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Truy vấn để lấy giá trị ID lớn nhất
                string query = "SELECT ISNULL(MAX(id), 0) FROM [TRANSACTION]";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    
                    return (int)command.ExecuteScalar() + 1; // Tăng thêm 1
                }
            }
        }
        //Withdraw
        public bool Withdraw(IModel model)
        {
            if (model is TransactionModel transaction)
            {
                // Lấy from_account_id từ transaction
                int fromAccountId = transaction.from_account_id;

            
                if (!AccountExists(fromAccountId))
                {
                    MessageBox.Show("Tài khoản không tồn tại.");
                    return false; 
                }

                // Kiểm tra số dư tài khoản trước khi rút
                if (!HasSufficientBalance(fromAccountId, transaction.amount))
                {
                    MessageBox.Show("Số dư không đủ để thực hiện giao dịch này.");
                    return false; 
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Lấy giá trị ID tiếp theo
                    transaction.id = GetNextTransactionId();

                    string query = "INSERT INTO [TRANSACTION] (id, from_account_id, branch_id, date_of_trans, amount, to_account_id, employee_id) VALUES (@id, @from_account_id, @branch_id, @date_of_trans, @amount, @to_account_id, @employee_id)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", transaction.id);
                        command.Parameters.AddWithValue("@from_account_id", fromAccountId);
                        command.Parameters.AddWithValue("@branch_id", transaction.branch_id);

                        if (transaction.date_of_trans == null || transaction.date_of_trans == DateTime.MinValue)
                        {
                            MessageBox.Show("transaction.date_of_trans chưa được gán giá trị hoặc là giá trị mặc định.");
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@date_of_trans", transaction.date_of_trans);
                        }

                        command.Parameters.AddWithValue("@amount", -transaction.amount); // Rút tiền 
                        command.Parameters.AddWithValue("@to_account_id", fromAccountId); // Đặt lại to_account_id
                        command.Parameters.AddWithValue("@employee_id", transaction.employee_id);

                        try
                        {
                            int rowsAffected = command.ExecuteNonQuery();
                          
                            return true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
                            return false;
                        }
                    }
                }
            }
            return false; 
        }
        // kiểm tra xem tài khoản có đủ số dư để thực hiện giao dịch hay không.
        private bool HasSufficientBalance(int accountId, double amount)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT balance FROM ACCOUNT WHERE id = @accountId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@accountId", accountId);
                    double balance = (double)command.ExecuteScalar(); 
                    return balance >= amount; 
                }
            }
        }
        public bool Transfer(IModel model)
        {
            if (model is TransactionModel transaction)
            {
                int fromAccountId = transaction.from_account_id;
                int toAccountId = transaction.to_account_id;

             
                if (!AccountExists(fromAccountId) || !AccountExists(toAccountId))
                {
                    MessageBox.Show("Tài khoản không tồn tại.");
                    return false;
                }

                if (fromAccountId == toAccountId)
                {
                    MessageBox.Show("Tài khoản gửi và tài khoản nhận phải khác nhau.");
                    return false;
                }

                if (!HasSufficientBalance(fromAccountId, transaction.amount))
                {
                    MessageBox.Show("Số dư không đủ để thực hiện giao dịch này.");
                    return false;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    transaction.id = GetNextTransactionId(); // Lấy ID tiếp theo cho giao dịch

                    using (var transactionScope = connection.BeginTransaction())
                    {
                        try
                        {
                            
                            string updateFromAccountQuery = "UPDATE ACCOUNT SET balance = balance - @amount WHERE id = @from_account_id";
                            using (SqlCommand command = new SqlCommand(updateFromAccountQuery, connection, transactionScope))
                            {
                                command.Parameters.AddWithValue("@amount", transaction.amount);
                                command.Parameters.AddWithValue("@from_account_id", fromAccountId);
                                command.ExecuteNonQuery();
                            }

                        
                            string updateToAccountQuery = "UPDATE ACCOUNT SET balance = balance + @amount WHERE id = @to_account_id";
                            using (SqlCommand command = new SqlCommand(updateToAccountQuery, connection, transactionScope))
                            {
                                command.Parameters.AddWithValue("@amount", transaction.amount);
                                command.Parameters.AddWithValue("@to_account_id", toAccountId);
                                command.ExecuteNonQuery();
                            }

                            // Lưu giao dịch
                            string insertTransactionQuery = "INSERT INTO [TRANSACTION] (id, from_account_id, to_account_id, amount, date_of_trans) VALUES (@id, @from_account_id, @to_account_id, @amount, @date_of_trans)";
                            using (SqlCommand command = new SqlCommand(insertTransactionQuery, connection, transactionScope))
                            {
                                command.Parameters.AddWithValue("@id", transaction.id);
                                command.Parameters.AddWithValue("@from_account_id", fromAccountId);
                                command.Parameters.AddWithValue("@to_account_id", toAccountId);
                                command.Parameters.AddWithValue("@amount", transaction.amount);
                                command.Parameters.AddWithValue("@date_of_trans", DateTime.Now);
                                command.ExecuteNonQuery();
                            }

                            // Cam kết giao dịch
                            transactionScope.Commit();
                        }
                        catch (Exception ex)
                        {
                            
                            transactionScope.Rollback();
                            MessageBox.Show($"Có lỗi xảy ra khi thực hiện giao dịch: {ex.Message}");
                            return false;
                        }
                    }
                }
                return true; 
            }
            return false; 
        }


        public bool Delete(IModel id)
        {
            if (id is TransactionModel transaction)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM [TRANSACTION] WHERE id = @id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", transaction.id);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            return false;
        }




        public bool Load()
        {

            transactions.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM [TRANSACTION] ORDER BY id ASC";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TransactionModel account = new TransactionModel
                            {
                                id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                                from_account_id = reader.IsDBNull(1) ? 0 : reader.GetInt32(1),
                                branch_id = reader.IsDBNull(2) ? null : reader.GetString(2),
                                date_of_trans = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3),
                                amount = reader.IsDBNull(4) ? 0.0 : reader.GetDouble(4),
                                to_account_id = reader.IsDBNull(5) ? 0 : reader.GetInt32(5),
                                employee_id = reader.IsDBNull(6) ? null : reader.GetString(6)
                            };
                            transactions.Add(account);

                        }
                    }
                }
            }

            return transactions.Count > 0;
        }

        public bool Load(object id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM [TRANSACTION] WHERE id = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            TransactionModel account = new TransactionModel
                            {
                                id = reader.GetInt32(0),
                                from_account_id = reader.GetInt32(1),
                                branch_id = reader.GetString(2),
                                date_of_trans = reader.GetDateTime(3), 
                                amount = reader.GetDouble(4), 
                                to_account_id = reader.GetInt32(5),
                                employee_id = reader.GetString(6)
                            };
                            transactions.Clear();
                            transactions.Add(account);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public IModel Read(IModel id)
        {
            if (id is TransactionModel transaction)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM [TRANSACTION] WHERE id = @id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", transaction.id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new TransactionModel
                                {
                                    id = reader.GetInt32(0),
                                    from_account_id = reader.GetInt32(1),
                                    branch_id = reader.GetString(2),
                                    date_of_trans = reader.GetDateTime(3), 
                                    amount = reader.GetDouble(4),
                                    to_account_id = reader.GetInt32(5),
                                    employee_id = reader.GetString(6)
                                };
                            }
                        }
                    }
                }
            }
            return null;
        }

        public bool Update(IModel model)
        {
            if (model is not TransactionModel transaction)
            {
                Console.WriteLine("Model không hợp lệ.");
                return false;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE [TRANSACTION] SET from_account_id = @from_account_id, branch_id = @branch_id, date_of_trans = @date_of_trans, amount = @amount, to_account_id = @to_account_id, employee_id = @employee_id  WHERE id = @id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", transaction.id);
                        command.Parameters.AddWithValue("@from_account_id", transaction.from_account_id);
                        command.Parameters.AddWithValue("@branch_id", transaction.branch_id);
                        command.Parameters.AddWithValue("@date_of_trans", transaction.date_of_trans);
                        command.Parameters.AddWithValue("@amount", transaction.amount);
                        command.Parameters.AddWithValue("@to_account_id", transaction.to_account_id);
                        command.Parameters.AddWithValue("@employee_id", transaction.employee_id);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine($"SQL Error: {sqlEx.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }
    }
}