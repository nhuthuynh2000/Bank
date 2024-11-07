namespace BankSystem
{
    partial class MainWindows
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindows));
            menuStrip1 = new MenuStrip();
            menu_sys = new ToolStripMenuItem();
            menu_system_logout = new ToolStripMenuItem();
            menu_branch = new ToolStripMenuItem();
            menu_employee = new ToolStripMenuItem();
            menu_account = new ToolStripMenuItem();
            menu_customer = new ToolStripMenuItem();
            menu_transaction = new ToolStripMenuItem();
            rútTiềnToolStripMenuItem = new ToolStripMenuItem();
            menu_deposit = new ToolStripMenuItem();
            menu_transfer = new ToolStripMenuItem();
            menu_report = new ToolStripMenuItem();
            menu_history = new ToolStripMenuItem();
            menu_login = new ToolStripMenuItem();
            panel2 = new Panel();
            label1 = new Label();
            menuStrip1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.AutoSize = false;
            menuStrip1.BackColor = Color.FromArgb(0, 192, 0);
            menuStrip1.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { menu_sys, menu_branch, menu_employee, menu_account, menu_customer, menu_transaction, menu_report, menu_login });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(8, 2, 0, 2);
            menuStrip1.Size = new Size(1646, 66);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // menu_sys
            // 
            menu_sys.DropDownItems.AddRange(new ToolStripItem[] { menu_system_logout });
            menu_sys.ForeColor = Color.White;
            menu_sys.Name = "menu_sys";
            menu_sys.Size = new Size(101, 62);
            menu_sys.Text = "Hệ thống";
            menu_sys.Click += menu_sys_Click;
            // 
            // menu_system_logout
            // 
            menu_system_logout.BackColor = Color.FromArgb(0, 192, 0);
            menu_system_logout.ForeColor = Color.White;
            menu_system_logout.Image = (Image)resources.GetObject("menu_system_logout.Image");
            menu_system_logout.Name = "menu_system_logout";
            menu_system_logout.Size = new Size(179, 28);
            menu_system_logout.Text = "Đăng xuất";
            menu_system_logout.Click += menu_system_logout_Click_1;
            // 
            // menu_branch
            // 
            menu_branch.ForeColor = Color.White;
            menu_branch.Image = (Image)resources.GetObject("menu_branch.Image");
            menu_branch.Name = "menu_branch";
            menu_branch.Size = new Size(132, 62);
            menu_branch.Text = "Chi Nhánh";
            menu_branch.Click += menu_branch_Click;
            // 
            // menu_employee
            // 
            menu_employee.ForeColor = Color.White;
            menu_employee.Image = (Image)resources.GetObject("menu_employee.Image");
            menu_employee.Name = "menu_employee";
            menu_employee.Size = new Size(132, 62);
            menu_employee.Text = "Nhân Viên";
            menu_employee.Click += menu_employee_Click;
            // 
            // menu_account
            // 
            menu_account.ForeColor = Color.White;
            menu_account.Image = (Image)resources.GetObject("menu_account.Image");
            menu_account.Name = "menu_account";
            menu_account.Size = new Size(126, 62);
            menu_account.Text = "Tài Khoản";
            menu_account.Click += menu_account_Click;
            // 
            // menu_customer
            // 
            menu_customer.ForeColor = Color.White;
            menu_customer.Image = (Image)resources.GetObject("menu_customer.Image");
            menu_customer.Name = "menu_customer";
            menu_customer.Size = new Size(141, 62);
            menu_customer.Text = "Khách hàng";
            menu_customer.Click += menu_customer_Click;
            // 
            // menu_transaction
            // 
            menu_transaction.DropDownItems.AddRange(new ToolStripItem[] { rútTiềnToolStripMenuItem, menu_deposit, menu_transfer });
            menu_transaction.ForeColor = Color.White;
            menu_transaction.Image = (Image)resources.GetObject("menu_transaction.Image");
            menu_transaction.Name = "menu_transaction";
            menu_transaction.Size = new Size(123, 62);
            menu_transaction.Text = "Giao dịch";
            menu_transaction.Click += menu_transaction_Click;
            // 
            // rútTiềnToolStripMenuItem
            // 
            rútTiềnToolStripMenuItem.BackColor = Color.FromArgb(0, 192, 0);
            rútTiềnToolStripMenuItem.ForeColor = Color.White;
            rútTiềnToolStripMenuItem.Image = (Image)resources.GetObject("rútTiềnToolStripMenuItem.Image");
            rútTiềnToolStripMenuItem.Name = "rútTiềnToolStripMenuItem";
            rútTiềnToolStripMenuItem.Size = new Size(195, 28);
            rútTiềnToolStripMenuItem.Text = "Rút tiền";
            rútTiềnToolStripMenuItem.Click += rútTiềnToolStripMenuItem_Click;
            // 
            // menu_deposit
            // 
            menu_deposit.BackColor = Color.FromArgb(0, 192, 0);
            menu_deposit.ForeColor = Color.White;
            menu_deposit.Image = (Image)resources.GetObject("menu_deposit.Image");
            menu_deposit.Name = "menu_deposit";
            menu_deposit.Size = new Size(195, 28);
            menu_deposit.Text = "Nạp tiền";
            menu_deposit.Click += menu_deposit_Click;
            // 
            // menu_transfer
            // 
            menu_transfer.BackColor = Color.FromArgb(0, 192, 0);
            menu_transfer.ForeColor = Color.White;
            menu_transfer.Name = "menu_transfer";
            menu_transfer.Size = new Size(195, 28);
            menu_transfer.Text = "Chuyển tiền";
            menu_transfer.Click += chuyểnTiềnToolStripMenuItem_Click;
            // 
            // menu_report
            // 
            menu_report.DropDownItems.AddRange(new ToolStripItem[] { menu_history });
            menu_report.ForeColor = Color.White;
            menu_report.Image = (Image)resources.GetObject("menu_report.Image");
            menu_report.Name = "menu_report";
            menu_report.Size = new Size(110, 62);
            menu_report.Text = "Báo cáo";
            menu_report.Click += menu_report_Click;
            // 
            // menu_history
            // 
            menu_history.BackColor = Color.FromArgb(0, 192, 0);
            menu_history.ForeColor = Color.White;
            menu_history.Image = (Image)resources.GetObject("menu_history.Image");
            menu_history.Name = "menu_history";
            menu_history.Size = new Size(271, 28);
            menu_history.Text = "Xem lịch sử giao dịch";
            menu_history.Click += xeToolStripMenuItem_Click;
            // 
            // menu_login
            // 
            menu_login.ForeColor = Color.White;
            menu_login.Image = Properties.Resources.icons8_login_35;
            menu_login.Name = "menu_login";
            menu_login.Size = new Size(135, 62);
            menu_login.Text = "Đăng nhập";
            menu_login.Click += menu_login_Click;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 613);
            panel2.Name = "panel2";
            panel2.Size = new Size(1646, 93);
            panel2.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(714, 36);
            label1.Name = "label1";
            label1.Size = new Size(313, 24);
            label1.TabIndex = 0;
            label1.Text = "© Bản quyền thuộc về VCB Digibank";
            // 
            // MainWindows
            // 
            AutoScaleDimensions = new SizeF(10F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1646, 706);
            Controls.Add(panel2);
            Controls.Add(menuStrip1);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4);
            Name = "MainWindows";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainWindows";
            Load += MainWindows_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem menu_sys;
        private ToolStripMenuItem menu_branch;
        private ToolStripMenuItem menu_employee;
        private ToolStripMenuItem menu_account;
        private ToolStripMenuItem menu_customer;
        private ToolStripMenuItem menu_report;
        private ToolStripMenuItem menu_login;
        private Panel panel2;
        private Label label1;
        private ToolStripMenuItem menu_transaction;
        private ToolStripMenuItem rútTiềnToolStripMenuItem;
        private ToolStripMenuItem menu_deposit;
        private ToolStripMenuItem menu_history;
        private ToolStripMenuItem menu_system_logout;
        private ToolStripMenuItem menu_transfer;
    }
}
