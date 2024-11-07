namespace BankSystem.View
{
    partial class TransactionView
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionView));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panel2 = new Panel();
            txtid = new Guna.UI2.WinForms.Guna2ComboBox();
            btn_print = new Guna.UI2.WinForms.Guna2Button();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2DataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            id = new DataGridViewTextBoxColumn();
            from_account_id = new DataGridViewTextBoxColumn();
            branch_id = new DataGridViewTextBoxColumn();
            date_of_trans = new DataGridViewTextBoxColumn();
            amount = new DataGridViewTextBoxColumn();
            to_account_id = new DataGridViewTextBoxColumn();
            employee_id = new DataGridViewTextBoxColumn();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)guna2DataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(txtid);
            panel2.Controls.Add(btn_print);
            panel2.Controls.Add(guna2HtmlLabel2);
            panel2.Controls.Add(guna2HtmlLabel1);
            panel2.Location = new Point(131, 173);
            panel2.Name = "panel2";
            panel2.Size = new Size(1276, 195);
            panel2.TabIndex = 19;
            // 
            // txtid
            // 
            txtid.BackColor = Color.Transparent;
            txtid.CustomizableEdges = customizableEdges1;
            txtid.DrawMode = DrawMode.OwnerDrawFixed;
            txtid.DropDownStyle = ComboBoxStyle.DropDownList;
            txtid.FocusedColor = Color.FromArgb(94, 148, 255);
            txtid.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtid.Font = new Font("Segoe UI", 10F);
            txtid.ForeColor = Color.FromArgb(68, 88, 112);
            txtid.ItemHeight = 30;
            txtid.Location = new Point(942, 74);
            txtid.Name = "txtid";
            txtid.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtid.Size = new Size(315, 36);
            txtid.TabIndex = 25;
            // 
            // btn_print
            // 
            btn_print.BorderRadius = 8;
            btn_print.BorderThickness = 1;
            btn_print.CustomizableEdges = customizableEdges3;
            btn_print.DisabledState.BorderColor = Color.DarkGray;
            btn_print.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_print.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_print.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_print.FillColor = Color.FromArgb(224, 224, 224);
            btn_print.Font = new Font("Calibri", 12F, FontStyle.Bold);
            btn_print.ForeColor = Color.Black;
            btn_print.Image = (Image)resources.GetObject("btn_print.Image");
            btn_print.Location = new Point(1161, 129);
            btn_print.Name = "btn_print";
            btn_print.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btn_print.Size = new Size(84, 38);
            btn_print.TabIndex = 24;
            btn_print.Text = "In";
            btn_print.Click += btn_print_Click;
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Calibri", 12F);
            guna2HtmlLabel2.Location = new Point(807, 84);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(110, 26);
            guna2HtmlLabel2.TabIndex = 10;
            guna2HtmlLabel2.Text = "Mã giao dịch";
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Calibri", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.Location = new Point(558, 23);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(230, 35);
            guna2HtmlLabel1.TabIndex = 9;
            guna2HtmlLabel1.Text = "QUẢN LÝ GIAO DỊCH";
            // 
            // guna2DataGridView1
            // 
            guna2DataGridView1.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            guna2DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            guna2DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            guna2DataGridView1.ColumnHeadersHeight = 50;
            guna2DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            guna2DataGridView1.Columns.AddRange(new DataGridViewColumn[] { id, from_account_id, branch_id, date_of_trans, amount, to_account_id, employee_id });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            guna2DataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            guna2DataGridView1.GridColor = Color.FromArgb(231, 229, 255);
            guna2DataGridView1.Location = new Point(131, 391);
            guna2DataGridView1.MultiSelect = false;
            guna2DataGridView1.Name = "guna2DataGridView1";
            guna2DataGridView1.RowHeadersVisible = false;
            guna2DataGridView1.RowHeadersWidth = 51;
            guna2DataGridView1.Size = new Size(1276, 325);
            guna2DataGridView1.TabIndex = 21;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.Font = null;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            guna2DataGridView1.ThemeStyle.BackColor = Color.White;
            guna2DataGridView1.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            guna2DataGridView1.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(0, 192, 0);
            guna2DataGridView1.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            guna2DataGridView1.ThemeStyle.HeaderStyle.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2DataGridView1.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            guna2DataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 50;
            guna2DataGridView1.ThemeStyle.ReadOnly = false;
            guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = Color.White;
            guna2DataGridView1.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            guna2DataGridView1.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            guna2DataGridView1.ThemeStyle.RowsStyle.Height = 29;
            guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            guna2DataGridView1.CellContentClick += guna2DataGridView1_CellContentClick;
            guna2DataGridView1.SelectionChanged += guna2DataGridView1_SelectionChanged;
            // 
            // id
            // 
            id.DataPropertyName = "id";
            id.HeaderText = "Mã giao dịch";
            id.MinimumWidth = 6;
            id.Name = "id";
            // 
            // from_account_id
            // 
            from_account_id.DataPropertyName = "from_account_id";
            from_account_id.HeaderText = "Số tài khoản chuyển tiền";
            from_account_id.MinimumWidth = 6;
            from_account_id.Name = "from_account_id";
            // 
            // branch_id
            // 
            branch_id.DataPropertyName = "branch_id";
            branch_id.HeaderText = "Mã chi nhánh";
            branch_id.MinimumWidth = 6;
            branch_id.Name = "branch_id";
            // 
            // date_of_trans
            // 
            date_of_trans.DataPropertyName = "date_of_trans";
            date_of_trans.HeaderText = "Ngày giao dịch";
            date_of_trans.MinimumWidth = 6;
            date_of_trans.Name = "date_of_trans";
            // 
            // amount
            // 
            amount.DataPropertyName = "amount";
            amount.HeaderText = "Số tiền";
            amount.MinimumWidth = 6;
            amount.Name = "amount";
            // 
            // to_account_id
            // 
            to_account_id.DataPropertyName = "to_account_id";
            to_account_id.HeaderText = "Số tài khoản nhận tiền";
            to_account_id.MinimumWidth = 6;
            to_account_id.Name = "to_account_id";
            // 
            // employee_id
            // 
            employee_id.DataPropertyName = "employee_id";
            employee_id.HeaderText = "Mã nhân viên";
            employee_id.MinimumWidth = 6;
            employee_id.Name = "employee_id";
            // 
            // TransactionView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1524, 840);
            Controls.Add(guna2DataGridView1);
            Controls.Add(panel2);
            Name = "TransactionView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TransactionView";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)guna2DataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn from_account_id;
        private DataGridViewTextBoxColumn branch_id;
        private DataGridViewTextBoxColumn date_of_trans;
        private DataGridViewTextBoxColumn amount;
        private DataGridViewTextBoxColumn to_account_id;
        private DataGridViewTextBoxColumn employee_id;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2Button btn_print;
        private Guna.UI2.WinForms.Guna2ComboBox txtid;
        //private Guna.UI2.WinForms.Guna2DateTimePicker guna2DateTimePicker1;
    }
}