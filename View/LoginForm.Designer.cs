namespace BankSystem.View
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btn_close = new Guna.UI2.WinForms.Guna2Button();
            open = new PictureBox();
            close = new PictureBox();
            label2 = new Label();
            label1 = new Label();
            linkLabel1 = new LinkLabel();
            btn_login = new Guna.UI2.WinForms.Guna2Button();
            txt_pass = new Guna.UI2.WinForms.Guna2TextBox();
            txt_email = new Guna.UI2.WinForms.Guna2TextBox();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)open).BeginInit();
            ((System.ComponentModel.ISupportInitialize)close).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // btn_close
            // 
            btn_close.BackColor = SystemColors.Control;
            btn_close.BorderRadius = 8;
            btn_close.CustomizableEdges = customizableEdges1;
            btn_close.DisabledState.BorderColor = Color.DarkGray;
            btn_close.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_close.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_close.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_close.FillColor = Color.FromArgb(0, 192, 0);
            btn_close.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btn_close.ForeColor = Color.White;
            btn_close.Location = new Point(316, 346);
            btn_close.Name = "btn_close";
            btn_close.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btn_close.Size = new Size(165, 44);
            btn_close.TabIndex = 19;
            btn_close.Text = "Đóng";
            btn_close.Click += btn_close_Click;
            // 
            // open
            // 
            open.Image = (Image)resources.GetObject("open.Image");
            open.Location = new Point(430, 282);
            open.Name = "open";
            open.Size = new Size(51, 36);
            open.TabIndex = 18;
            open.TabStop = false;
            open.Click += open_Click;
            // 
            // close
            // 
            close.Image = (Image)resources.GetObject("close.Image");
            close.Location = new Point(430, 282);
            close.Name = "close";
            close.Size = new Size(51, 36);
            close.TabIndex = 17;
            close.TabStop = false;
            close.Click += close_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(277, 176);
            label2.Name = "label2";
            label2.Size = new Size(69, 25);
            label2.TabIndex = 16;
            label2.Text = "Login";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label1.ForeColor = SystemColors.ControlDark;
            label1.Location = new Point(239, 142);
            label1.Name = "label1";
            label1.Size = new Size(145, 19);
            label1.TabIndex = 11;
            label1.Text = "Xin chào Quý khách";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // linkLabel1
            // 
            linkLabel1.ActiveLinkColor = Color.WhiteSmoke;
            linkLabel1.AutoSize = true;
            linkLabel1.LinkColor = Color.FromArgb(0, 192, 0);
            linkLabel1.Location = new Point(258, 414);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(109, 20);
            linkLabel1.TabIndex = 15;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Quên mật khẩu";
            // 
            // btn_login
            // 
            btn_login.BorderRadius = 8;
            btn_login.CustomizableEdges = customizableEdges3;
            btn_login.DisabledState.BorderColor = Color.DarkGray;
            btn_login.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_login.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_login.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_login.FillColor = Color.FromArgb(0, 192, 0);
            btn_login.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btn_login.ForeColor = Color.White;
            btn_login.Location = new Point(141, 346);
            btn_login.Name = "btn_login";
            btn_login.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btn_login.Size = new Size(159, 44);
            btn_login.TabIndex = 14;
            btn_login.Text = "Đăng nhập";
            btn_login.Click += btn_login_Click;
            // 
            // txt_pass
            // 
            txt_pass.BorderRadius = 8;
            txt_pass.CustomizableEdges = customizableEdges5;
            txt_pass.DefaultText = "";
            txt_pass.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txt_pass.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txt_pass.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txt_pass.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txt_pass.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txt_pass.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            txt_pass.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txt_pass.Location = new Point(141, 282);
            txt_pass.Margin = new Padding(3, 4, 3, 4);
            txt_pass.Name = "txt_pass";
            txt_pass.PasswordChar = '*';
            txt_pass.PlaceholderText = "Mật khẩu";
            txt_pass.SelectedText = "";
            txt_pass.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txt_pass.Size = new Size(340, 36);
            txt_pass.TabIndex = 13;
            txt_pass.TextChanged += txt_pass_TextChanged;
            // 
            // txt_email
            // 
            txt_email.BorderRadius = 8;
            txt_email.CustomizableEdges = customizableEdges7;
            txt_email.DefaultText = "";
            txt_email.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txt_email.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txt_email.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txt_email.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txt_email.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txt_email.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            txt_email.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txt_email.Location = new Point(141, 228);
            txt_email.Margin = new Padding(3, 4, 3, 4);
            txt_email.Name = "txt_email";
            txt_email.PasswordChar = '\0';
            txt_email.PlaceholderText = "Tên đăng nhập";
            txt_email.SelectedText = "";
            txt_email.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txt_email.Size = new Size(340, 36);
            txt_email.TabIndex = 12;
            txt_email.TextChanged += txt_email_TextChanged;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(176, 30);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(270, 95);
            pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox2.TabIndex = 10;
            pictureBox2.TabStop = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(634, 450);
            Controls.Add(btn_close);
            Controls.Add(open);
            Controls.Add(close);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(linkLabel1);
            Controls.Add(btn_login);
            Controls.Add(txt_pass);
            Controls.Add(txt_email);
            Controls.Add(pictureBox2);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            Load += LoginForm_Load;
            ((System.ComponentModel.ISupportInitialize)open).EndInit();
            ((System.ComponentModel.ISupportInitialize)close).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btn_close;
        private PictureBox open;
        private PictureBox close;
        private Label label2;
        private Label label1;
        private LinkLabel linkLabel1;
        private Guna.UI2.WinForms.Guna2Button btn_login;
        private Guna.UI2.WinForms.Guna2TextBox txt_pass;
        private Guna.UI2.WinForms.Guna2TextBox txt_email;
        private PictureBox pictureBox2;
    }
}