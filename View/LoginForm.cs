using BankSystem.Controller;
namespace BankSystem.View
{
    public partial class LoginForm : Form
    {
        MainWindows mainWindows;

        public LoginForm(MainWindows form)
        {
            InitializeComponent();
            mainWindows = form;
            open.Visible = true;
            close.Visible = false;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            btn_login.Enabled = false;
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            Login controller = new Login();
            bool isAuthenticated = controller.LoginController(txt_email.Text, txt_pass.Text);

            if (isAuthenticated)
            {
                MessageBox.Show("Đăng nhập thành công!");
                mainWindows.isLoggedIn = true;
                mainWindows.role = controller.GetRole(txt_email.Text, txt_pass.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.");
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_pass_TextChanged(object sender, EventArgs e)
        {
            UpdateLoginButtonState();

        }

        private void txt_email_TextChanged(object sender, EventArgs e)
        {
            UpdateLoginButtonState();
        }
        private void UpdateLoginButtonState()
        {
            // Kiểm tra xem cả hai ô nhập liệu đều có dữ liệu
            bool isUsernameFilled = !string.IsNullOrWhiteSpace(txt_email.Text);
            bool isPasswordFilled = !string.IsNullOrWhiteSpace(txt_pass.Text);

            // Cập nhật trạng thái nút "Login"
            btn_login.Enabled = isUsernameFilled && isPasswordFilled;
        }

        private void open_Click(object sender, EventArgs e)
        {
            close.Visible = true;
            open.Visible = false;
            txt_pass.PasswordChar = '\0';
            
        }

        private void close_Click(object sender, EventArgs e)
        {
            open.Visible = true;
            close.Visible = false;
            txt_pass.PasswordChar = '*';
        }
    }
}
