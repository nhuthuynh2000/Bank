using BankSystem.Controller;
using BankSystem.Model;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace BankSystem.View
{
    public partial class DepositView : Form, IView
    {
        private TransactionController transactionController;
        private AccountController accountController;
        private EmployeeController employeeController;
        private BindingList<AccountModel> accountList;
        private AccountModel selectedAccount;
        private EmployeeModel employee;

        public DepositView()
        {
            InitializeComponent();

            employeeController = new EmployeeController();
            transactionController = new TransactionController();
            accountController = new AccountController();
            accountList = new BindingList<AccountModel>();
            employee = employeeController.GetActiveEmployee();

            LoadAccounts();
            cboAccountID.SelectedIndexChanged += CboAccountID_SelectedIndexChanged;
        }

        private void LoadAccounts()
        {
            try
            {
                if (accountController.Load())
                {
                    // Chuyển đổi và kiểm tra xem danh sách tài khoản có dữ liệu không
                    var accounts = accountController.Items.Cast<AccountModel>().ToList();
                    if (accounts == null || !accounts.Any())
                    {
                        ShowError("Không có dữ liệu tài khoản để hiển thị.");
                        return;
                    }

                    accountList = new BindingList<AccountModel>(accounts);
                    cboAccountID.DataSource = accountList;
                    cboAccountID.DisplayMember = "id";
                    cboAccountID.ValueMember = "id";
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
            if (cboAccountID.SelectedItem is AccountModel selectedAccount)
            {
                this.selectedAccount = selectedAccount; // Lưu tài khoản đã chọn
                SetDataToText(); // Cập nhật giao diện với dữ liệu tài khoản
            }
        }

        private bool ValidateDepositAmount(out double depositAmount)
        {
            bool isValid = double.TryParse(txtamount.Text, out depositAmount) && depositAmount > 0;
            if (!isValid)
            {
                ShowError("Số tiền nạp không hợp lệ. Vui lòng nhập số tiền dương.");
            }
            return isValid;
        }

        private void UpdateAccountBalance(AccountModel account, double depositAmount)
        {
            account.balance += depositAmount; // Cộng tiền vào tài khoản
            accountController.Update(account); // Cập nhật tài khoản
            txtbalance.Text = account.balance.ToString("F2"); // Cập nhật giao diện
        }

        private void SaveDepositTransaction(AccountModel account, double depositAmount, EmployeeModel employee)
        {
            var transaction = new TransactionModel
            {
                id = 0,
                amount = depositAmount,
                branch_id = "HCM",
                date_of_trans = DateTime.Now,
                from_account_id = account.id,
                to_account_id = 0,
                employee_id = employee.id,
            };


            if (!transactionController.Create(transaction))
            {
                ShowError("Không thể lưu giao dịch nạp tiền.");
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
                txtamount.Text = "0.00"; // Reset ô nhập tiền
            }
        }

        public void GetDataFromText()
        {
            if (selectedAccount != null && ValidateDepositAmount(out double depositAmount))
            {
                try
                {
                    SaveDepositTransaction(selectedAccount, depositAmount, employee);
                    UpdateAccountBalance(selectedAccount, depositAmount);

                    MessageBox.Show("Nạp tiền thành công!");
                    txtamount.Text = "0.00";
                }
                catch (Exception ex)
                {
                    ShowError($"Có lỗi xảy ra khi xử lý nạp tiền: {ex.Message}");
                }
            }
        }

        private void DepositView_Load(object sender, EventArgs e)
        {
            LoadAccounts();
        }

        private void btn_deposit_Click(object sender, EventArgs e)
        {
            GetDataFromText(); // Lấy dữ liệu từ giao diện và xử lý nạp tiền
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
