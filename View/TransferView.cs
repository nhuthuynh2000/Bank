using BankSystem.Controller;
using BankSystem.Model;
using Guna.UI2.WinForms;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace BankSystem.View
{
    public partial class TransferView : Form, IView
    {
        private TransactionController transactionController;
        private AccountController accountController;
        private EmployeeController employeeController;
        private BindingList<AccountModel> accountList;
        private AccountModel selectedAccountFrom;
        private AccountModel selectedAccountTo;
        private EmployeeModel employee;

        public TransferView()
        {
            InitializeComponent();


            employeeController = new EmployeeController();
            transactionController = new TransactionController();
            accountController = new AccountController();
            accountList = new BindingList<AccountModel>();
            employee = employeeController.GetActiveEmployee();

            LoadAccounts();
            txtaccount.SelectedIndexChanged += CboAccountFrom_SelectedIndexChanged;
            txtaccount2.SelectedIndexChanged += CboAccountTo_SelectedIndexChanged;
        }

        private void LoadAccounts()
        {
            try
            {
                if (accountController.Load())
                {
                    var accounts = accountController.Items.Cast<AccountModel>().ToList();
                    if (accounts == null || !accounts.Any())
                    {
                        ShowError("Không có dữ liệu tài khoản để hiển thị.");
                        return;
                    }

                    // Tạo một danh sách riêng cho txtaccount
                    var fromAccounts = new BindingList<AccountModel>(accounts);
                    txtaccount.DataSource = fromAccounts;
                    txtaccount.DisplayMember = "id";
                    txtaccount.ValueMember = "id";

                    // Tạo một danh sách riêng cho txtaccount2
                    var toAccounts = new BindingList<AccountModel>(accounts);
                    txtaccount2.DataSource = toAccounts;
                    txtaccount2.DisplayMember = "id";
                    txtaccount2.ValueMember = "id";
                }
                else
                {
                    ShowError("Không có dữ liệu về tài khoản để hiển thị.");
                }
            }
            catch (Exception ex)
            {
                ShowError($"Có lỗi xảy ra khi tải dữ liệu về tài khoản: {ex.Message}");
            }
        }

        private void CboAccountFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtaccount.SelectedItem is AccountModel selectedAccount)
            {
                selectedAccountFrom = selectedAccount;
                SetDataToText(); // Cập nhật số dư của tài khoản gửi

                // Reset số dư của tài khoản nhận khi chọn tài khoản gửi khác
                txtbalance2.Text = "0.00";
            }
        }

        private void CboAccountTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtaccount2.SelectedItem is AccountModel selectedAccount)
            {
                selectedAccountTo = selectedAccount; // Lưu tài khoản được chọn
                Console.WriteLine($"Selected To Account ID: {selectedAccountTo.id}");

                // Cập nhật số dư của tài khoản nhận
                txtbalance2.Text = selectedAccountTo.balance.ToString("F2");
            }
        }

        private bool ValidateTransferAmount(out double transferAmount)
        {
            bool isValid = double.TryParse(txtamount.Text, out transferAmount) && transferAmount > 0;
            if (!isValid)
            {
                ShowError("Số tiền chuyển không hợp lệ. Vui lòng nhập số tiền dương.");
            }
            return isValid;
        }

        private void UpdateAccountBalances(double transferAmount)
        {
            selectedAccountFrom.balance -= transferAmount; // Trừ từ tài khoản gửi
            selectedAccountTo.balance += transferAmount; // Cộng vào tài khoản nhận
            accountController.Update(selectedAccountFrom);
            accountController.Update(selectedAccountTo);

            // Cập nhật hiển thị số dư
            txtbalance.Text = selectedAccountFrom.balance.ToString("F2"); // Cập nhật số dư tài khoản gửi
            txtbalance2.Text = selectedAccountTo.balance.ToString("F2"); // Cập nhật số dư tài khoản nhận
        }

        private void SaveTransferTransaction(double transferAmount)
        {
            var transaction = new TransactionModel
            {
                id = 0,
                amount = transferAmount,
                branch_id = "HCM",
                date_of_trans = DateTime.Now,
                from_account_id = selectedAccountFrom.id,
                to_account_id = selectedAccountTo.id,
                employee_id = employee.id,
            };


            if (!transactionController.Transfer(transaction))
            {
                ShowError("Không thể lưu giao dịch chuyển tiền.");
            }
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message);
        }

        public void SetDataToText()
        {
            if (selectedAccountFrom != null)
            {
                txtbalance.Text = selectedAccountFrom.balance.ToString("F2");
                txtamount.Text = "0.00";
            }
        }

        public void GetDataFromText()
        {
            if (selectedAccountFrom != null && selectedAccountTo != null && ValidateTransferAmount(out double transferAmount))
            {
                try
                {
                    if (selectedAccountFrom.id == selectedAccountTo.id)
                    {
                        ShowError("Tài khoản gửi và tài khoản nhận phải khác nhau.");
                        return;
                    }

                    if (selectedAccountFrom.balance < transferAmount)
                    {
                        ShowError("Số dư không đủ để thực hiện giao dịch.");
                        return;
                    }

                    SaveTransferTransaction(transferAmount); // Lưu giao dịch
                    UpdateAccountBalances(transferAmount); // Cập nhật số dư
                    MessageBox.Show("Chuyển tiền thành công!");
                    txtamount.Text = "0.00"; // Reset ô nhập tiền
                }
                catch (Exception ex)
                {
                    ShowError($"Có lỗi xảy ra khi xử lý chuyển tiền: {ex.Message}");
                }
            }
        }

        private void btn_transfer_Click(object sender, EventArgs e)
        {
            GetDataFromText();
        }

        private void TransferView_Load_1(object sender, EventArgs e)
        {
            LoadAccounts();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
