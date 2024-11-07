using BankSystem.View;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace BankSystem
{
    public partial class MainWindows : Form
    {
        public bool isLoggedIn = false; // Biến theo dõi trạng thái đăng nhập
        public string role = "";


        public MainWindows()
        {
            InitializeComponent();
            UpdateMenuItems();
            SetMenuItemsEnabled(false); // Menu mờ đi
            this.IsMdiContainer = true;

        }

        private void SetMenuItemsEnabled(bool enabled)
        {
            menu_account.Enabled = enabled; // Bật/tắt menu tài khoản
            menu_branch.Enabled = enabled;
            menu_sys.Enabled = enabled;
            menu_employee.Enabled = enabled;
            menu_transaction.Enabled = enabled;
            menu_report.Enabled = enabled;
            menu_customer.Enabled = enabled;



        }

        private void UpdateMenuItems()
        {
            // Hiển thị hoặc ẩn menu đăng nhập và đăng xuất dựa trên trạng thái đăng nhập
            menu_login.Visible = !isLoggedIn;
            menu_system_logout.Visible = isLoggedIn;
        }

        private void MainWindows_Load(object sender, EventArgs e)
        {
            UpdateMenuItems();
        }

        private void menu_system_logout_Click(object sender, EventArgs e)
        {
            isLoggedIn = false; // Đặt lại trạng thái đăng nhập
            role = ""; // Đặt lại vai trò
            SetMenuItemsEnabled(false); 
            UpdateMenuItems(); 
        }

        private void menu_login_Click(object sender, EventArgs e)
        {
            if (!isLoggedIn)
            {
                LoginForm loginForm = new LoginForm(this);
                loginForm.ShowDialog(); 

                // Kiểm tra trạng thái đăng nhập sau khi đóng LoginForm
                if (isLoggedIn) // Nếu đăng nhập thành công
                {
                    menu_login.Visible = false; // Thay đổi văn bản thành Đăng xuất
                    SetMenuItemsEnabled(true);
                    menu_login.Image = Properties.Resources.icons8_logout_48; 
                                                                            
                    if (role == "Admin")
                    {
                        menu_account.Visible = true; // Hiển thị cho Admin
                        menu_employee.Visible = true;
                        menu_branch.Visible = true;
                        menu_customer.Visible = true; ;
                    }
                    else
                    {
                        menu_account.Visible = false; 
                        menu_employee.Visible = false;
                        menu_employee.Visible = false;

                        menu_branch.Visible = false;
                        menu_customer.Visible = false; ;
                    }
                }
            }
            else
            {
                // Nếu đã đăng nhập, thực hiện đăng xuất
                menu_login.Image = Properties.Resources.icons8_login_35;
                isLoggedIn = false; 
                role = "";
                SetMenuItemsEnabled(false); // Tắt các mục menu
                UpdateMenuItems(); // Cập nhật giao diện
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void menu_sys_Click(object sender, EventArgs e)
        {
            menu_system_logout.Visible = true;
        }

        private void menu_deposit_Click(object sender, EventArgs e)
        {
            DepositView deposit = new DepositView();
            deposit.MdiParent = this;
            deposit.Show();
            deposit.WindowState = FormWindowState.Maximized;

        }

        private void menu_branch_Click(object sender, EventArgs e)
        {
            BranchView branch = new BranchView();
            branch.MdiParent = this;
            branch.Show();
            branch.WindowState = FormWindowState.Maximized;
        }

        private void menu_employee_Click(object sender, EventArgs e)
        {
            EmployeeView employee = new EmployeeView();
            employee.MdiParent = this;
            employee.Show();
           employee.WindowState = FormWindowState.Maximized;

        }

        private void menu_account_Click(object sender, EventArgs e)
        {
            AccountView account = new AccountView();
            account.MdiParent = this;
            account.Show();
           account.WindowState = FormWindowState.Maximized;

        }

        private void menu_customer_Click(object sender, EventArgs e)
        {
            CustomerView customer = new CustomerView();
            customer.MdiParent = this;
            customer.Show();
            customer.WindowState = FormWindowState.Maximized;

        }

        private void menu_transaction_Click(object sender, EventArgs e)
        {

        }

        private void menu_report_Click(object sender, EventArgs e)
        {
           
        }

        private void rútTiềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WithdrawView withdraw = new WithdrawView();
            withdraw.MdiParent = this;
            withdraw.Show();
            withdraw.WindowState = FormWindowState.Maximized;

        }

        private void chuyểnTiềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TransferView transfer = new TransferView();
            transfer.MdiParent = this;
            transfer.Show();
            transfer.WindowState = FormWindowState.Maximized;

        }

        private void xeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TransactionView transaction = new TransactionView();
            transaction.MdiParent = this;

            transaction.Show();
            transaction.WindowState = FormWindowState.Maximized;

        }

        private void menu_system_logout_Click_1(object sender, EventArgs e)
        {
            // Nếu đã đăng nhập, thực hiện đăng xuất
            menu_login.Visible = true;
            menu_login.Image = Properties.Resources.icons8_login_35;
            isLoggedIn = false; 
            role = ""; 
            SetMenuItemsEnabled(false); 
            UpdateMenuItems(); 
        }
    }
}