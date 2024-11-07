using BankSystem.Controller;
using BankSystem.Model;
using System;
using System.ComponentModel;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace BankSystem.View
{
    public partial class TransactionView : Form, IView
    {
        private TransactionController transactionController;
        private BindingList<TransactionModel> transactionList;
        private TransactionModel transaction;
        private PrintDocument printDocument;

        public TransactionView()
        {
            InitializeComponent();
            transactionController = new TransactionController();
            transactionList = new BindingList<TransactionModel>();
            transaction = new TransactionModel();

            LoadTransactions();
            txtid.SelectedIndexChanged += Txtid_SelectedIndexChanged;

            // Khởi tạo đối tượng PrintDocument
            printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;
        }

        private void LoadTransactions()
        {
            try
            {
                if (transactionController.Load())
                {
                    var transactions = transactionController.Items.Cast<TransactionModel>().ToList();
                    transactionList = new BindingList<TransactionModel>(transactions);
                    txtid.DataSource = transactionList;
                    txtid.DisplayMember = "id"; 
                    txtid.ValueMember = "id"; 
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu về giao dịch để hiển thị.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi tải dữ liệu về giao dịch: {ex.Message}");
            }
        }

        private void Txtid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtid.SelectedItem is TransactionModel selectedTransaction)
            {
                int selectedTransactionId = selectedTransaction.id;
                FilterTransactionsById(selectedTransactionId);
            }
        }

        private void FilterTransactionsById(int transactionId)
        {
            try
            {
                var allTransactions = transactionController.Items.Cast<TransactionModel>().ToList();

                // Kiểm tra xem có giao dịch nào hay không
                if (!allTransactions.Any())
                {
                    MessageBox.Show("Không có dữ liệu giao dịch để hiển thị.");
                    return;
                }

                // Lọc giao dịch theo ID đã chọn
                var filteredTransactions = allTransactions
                    .Where(t => t.id == transactionId)
                    .Select(t => new
                    {
                        id = t.id,
                        from_account_id = t.from_account_id,
                        branch_id = t.branch_id,
                        date_of_trans = t.date_of_trans.ToString("yyyy/MM/dd"),
                        amount = t.amount,
                        to_account_id = t.to_account_id,
                        employee_id = t.employee_id
                    }).ToList();

                // Kiểm tra dữ liệu đã lọc

                if (!filteredTransactions.Any())
                {
                    MessageBox.Show("Không có giao dịch nào cho ID đã chọn.");
                    guna2DataGridView1.DataSource = null; // Xóa dữ liệu trước đó
                    return;
                }

                // Cập nhật DataGridView với dữ liệu đã lọc
                guna2DataGridView1.DataSource = filteredTransactions;

                // Cập nhật tiêu đề cột
                guna2DataGridView1.Columns["id"].HeaderText = "Mã Giao Dịch";
                guna2DataGridView1.Columns["from_account_id"].HeaderText = "Số Tài Khoản Chuyển Tiền";
                guna2DataGridView1.Columns["branch_id"].HeaderText = "Mã Chi Nhánh";
                guna2DataGridView1.Columns["date_of_trans"].HeaderText = "Ngày Giao Dịch";
                guna2DataGridView1.Columns["amount"].HeaderText = "Số Tiền";
                guna2DataGridView1.Columns["to_account_id"].HeaderText = "Số Tài Khoản Nhận Tiền";
                guna2DataGridView1.Columns["employee_id"].HeaderText = "Mã Nhân Viên";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi lọc dữ liệu: {ex.Message}");
            }
        }

        private void guna2DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                SetDataToText();
            }
        }

        public void SetDataToText()
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = guna2DataGridView1.SelectedRows[0];

                transaction = new TransactionModel
                {
                    id = selectedRow.Cells["id"].Value != null ? int.Parse(selectedRow.Cells["id"].Value.ToString()) : 0,
                    from_account_id = selectedRow.Cells["from_account_id"].Value != null ? int.Parse(selectedRow.Cells["from_account_id"].Value.ToString()) : 0,
                    branch_id = selectedRow.Cells["branch_id"].Value?.ToString(),
                    date_of_trans = selectedRow.Cells["date_of_trans"].Value != null ? DateTime.Parse(selectedRow.Cells["date_of_trans"].Value.ToString()) : DateTime.MinValue,
                    amount = selectedRow.Cells["amount"].Value != null ? double.Parse(selectedRow.Cells["amount"].Value.ToString()) : 0.0,
                    to_account_id = selectedRow.Cells["to_account_id"].Value != null ? int.Parse(selectedRow.Cells["to_account_id"].Value.ToString()) : 0,
                    employee_id = selectedRow.Cells["employee_id"].Value?.ToString()
                };

                // Cập nhật dữ liệu vào TextBox
                txtid.Text = transaction.id.ToString();
            }
        }

        public void GetDataFromText()
        {
            if (!int.TryParse(txtid.Text.Trim(), out int id))
            {
                MessageBox.Show("ID không hợp lệ.");
                return;
            }

            transaction.id = id; // Cập nhật ID trong đối tượng TransactionModel
        }
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = guna2DataGridView1.SelectedRows[0];

                // Lấy thông tin giao dịch từ dòng đã chọn
                string printContent = $"Mã Giao Dịch: {selectedRow.Cells["id"].Value}\n" +
                                      $"Số Tài Khoản Chuyển Tiền: {selectedRow.Cells["from_account_id"].Value}\n" +
                                      $"Số Tài Khoản Nhận Tiền: {selectedRow.Cells["to_account_id"].Value}\n" +
                                      $"Ngày Giao Dịch: {selectedRow.Cells["date_of_trans"].Value}\n" +
                                      $"Số Tiền: {selectedRow.Cells["amount"].Value}\n" +
                                      $"Mã Chi Nhánh: {selectedRow.Cells["branch_id"].Value}\n" +
                                      $"Mã Nhân Viên: {selectedRow.Cells["employee_id"].Value}";

                // In nội dung lên trang
                e.Graphics.DrawString(printContent, new Font("Arial", 12), Brushes.Black, new PointF(100, 100));
            }
            else
            {
                e.Cancel = true; // Hủy in nếu không có dòng nào được chọn
            }
        }
        private void txtid_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            LoadTransactions();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có giao dịch nào được chọn để in không
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDocument;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một giao dịch để in.");
            }
        }
    }
}
