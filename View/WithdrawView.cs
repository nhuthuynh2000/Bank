using BankSystem.Controller;
using BankSystem.Model;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace BankSystem.View
{
    public partial class WithdrawView : Form, IView
    {
        private TransactionController transactionController;
        private AccountController accountController;
        private EmployeeController employeeController;
        private BindingList<AccountModel> accountList;
        private AccountModel selectedAccount;
        private EmployeeModel employee;

        public WithdrawView()
        {
            InitializeComponent();


            employeeController = new EmployeeController();
            transactionController = new TransactionController();
            accountController = new AccountController();
            accountList = new BindingList<AccountModel>();
            employee = employeeController.GetActiveEmployee();

            LoadAccounts();
            txtaccount.SelectedIndexChanged += CboAccountID_SelectedIndexChanged;
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

                    accountList = new BindingList<AccountModel>(accounts);
                    txtaccount.DataSource = accountList;
                    txtaccount.DisplayMember = "id";
                    txtaccount.ValueMember = "id";
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

        private void CboAccountID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtaccount.SelectedItem is AccountModel selectedAccount)
            {
                this.selectedAccount = selectedAccount; // Lưu tài khoản đã chọn
                SetDataToText();
            }
        }

        private bool ValidateWithdrawAmount(out double withdrawAmount)
        {
            bool isValid = double.TryParse(txtamount.Text, out withdrawAmount) && withdrawAmount > 0;
            if (!isValid)
            {
                ShowError("Số tiền rút không hợp lệ. Vui lòng nhập số tiền dương.");
            }
            return isValid;
        }

        private void UpdateAccountBalance(AccountModel account, double withdrawAmount)
        {
            account.balance -= withdrawAmount; // Trừ tiền khỏi tài khoản
            accountController.Update(account); // Cập nhật tài khoản
            txtbalance.Text = account.balance.ToString("F2"); // Cập nhật giao diện
        }

        private void SaveWithdrawTransaction(AccountModel account, double withdrawAmount, EmployeeModel employee)
        {
            var transaction = new TransactionModel
            {
                id = 0, // ID tự động sinh
                amount = -withdrawAmount,
                branch_id = "HCM",
                date_of_trans = DateTime.Now,
                from_account_id = account.id,
                to_account_id = 0,
                employee_id = employee.id,
            };

            // Gọi controller để lưu giao dịch
            if (!transactionController.Withdraw(transaction))
            {
                ShowError("Không thể lưu giao dịch rút tiền.");
            }
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message);
        }

        public void SetDataToText()
        {
            if (selectedAccount != null)
            {
                txtbalance.Text = selectedAccount.balance.ToString("F2");
                txtamount.Text = "0.00";
            }
        }

        public void GetDataFromText()
        {
            if (selectedAccount != null && ValidateWithdrawAmount(out double withdrawAmount))
            {
                try
                {
                    // Kiểm tra số dư trước khi rút tiền
                    if (selectedAccount.balance < withdrawAmount)
                    {
                        ShowError("Số dư không đủ để thực hiện giao dịch.");
                        return;
                    }

                    SaveWithdrawTransaction(selectedAccount, withdrawAmount, employee); // Lưu giao dịch
                    UpdateAccountBalance(selectedAccount, withdrawAmount); // Cập nhật số dư
                    MessageBox.Show("Rút tiền thành công!");
                    txtamount.Text = "0.00"; // Reset ô nhập tiền
                }
                catch (Exception ex)
                {
                    ShowError($"Có lỗi xảy ra khi xử lý rút tiền: {ex.Message}");
                }
            }
        }

        private void WithdrawView_Load_1(object sender, EventArgs e)
        {
            LoadAccounts();
        }

        private void btn_withdraw_Click_1(object sender, EventArgs e)
        {
            GetDataFromText(); // Lấy dữ liệu từ giao diện và xử lý rút tiền
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
