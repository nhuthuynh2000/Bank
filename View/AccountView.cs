using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BankSystem.Model;
using BankSystem.Controller;
using Guna.UI2.WinForms;
using System.Xml.Linq;

namespace BankSystem.View
{
    public partial class AccountView : Form, IView
    {
        private AccountController controller;
        private AccountModel account;
        private BindingList<AccountModel> accountList; 
        public DateTime selectedDate;

        public AccountView()
        {
            InitializeComponent();
            controller = new AccountController();
            account = new AccountModel();
            accountList = new BindingList<AccountModel>(); 
            txtdateopened.CustomFormat = "dd/MM/yyyy";
            txtdateopened.Format = DateTimePickerFormat.Custom;
            this.Load += new EventHandler(AccountView_Load);
        }

        public void GetDataFromText()
        {
            account.id = int.Parse(txtid.Text.Trim()); 
            account.customerid = txtcustomerid.Text.Trim();
            account.date_opened = txtdateopened.Value;
            account.balance = double.Parse(txtbalance.Text.Trim()); 
        }

        public void SetDataToText()
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
             
                DataGridViewRow selectedRow = guna2DataGridView1.SelectedRows[0];
                account = new AccountModel
                {
                    id = int.Parse(selectedRow.Cells["id"].Value.ToString()),
                    customerid = selectedRow.Cells["customerid"].Value.ToString(),
                   
                    date_opened = DateTime.ParseExact(selectedRow.Cells["date_opened"].Value.ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    balance = double.Parse(selectedRow.Cells["balance"].Value.ToString()) 
                };

                // Cập nhật dữ liệu vào TextBox
                txtid.Text = account.id.ToString(); 
                txtcustomerid.Text = account.customerid;
                txtdateopened.Value = account.date_opened;
                txtbalance.Text = account.balance.ToString("F2"); 
            }
        }

        // Search theo ID
        public void SearchAccountById(string id)
        {
            if (controller.Load(id))
            {
                UpdateDataGridView();
            }
            else
            {
                MessageBox.Show("Không tìm thấy tài khoản với ID đã cho.");
            }
        }

        public void UpdateDataGridView()
        {
            accountList.Clear(); // Xóa danh sách hiện tại trước khi thêm mới

            foreach (var account in controller.Items.Cast<AccountModel>())
            {
                accountList.Add(account); // Thêm mỗi tài khoản vào BindingList
            }

            guna2DataGridView1.DataSource = accountList; // Gán BindingList làm nguồn dữ liệu
        }

        private void LoadAccounts()
        {
            try
            {
                if (controller.Load())
                {
                    var accountData = controller.Items.Cast<AccountModel    >().Select(account => new
                    {
                        id = account.id,
                        customerid = account.customerid,
                        date_opened = account.date_opened.ToString("dd/MM/yyyy"), 
                        balance = account.balance
                    }).ToList();

                    guna2DataGridView1.DataSource = accountData; 

                    // Đặt tên hiển thị cho các cột
                    guna2DataGridView1.Columns["id"].HeaderText = "Mã Tài Khoản";
                    guna2DataGridView1.Columns["customerid"].HeaderText = "Mã Khách Hàng";
                    guna2DataGridView1.Columns["date_opened"].HeaderText = "Ngày Mở";
                    guna2DataGridView1.Columns["balance"].HeaderText = "Số Dư Tài Khoản";
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu để hiển thị.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi tải dữ liệu: {ex.Message}");
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SetDataToText(); // Hiển thị dữ liệu dòng được chọn
            }
        }

        private void AccountView_Load(object sender, EventArgs e)
        {
            LoadAccounts();
            ClearForm();
        }

        private void txtdateopened_ValueChanged(object sender, EventArgs e)
        {
            selectedDate = txtdateopened.Value;
        }

        private void txtdateopened_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                txtdateopened.CustomFormat = "";
            }
        }

        private void guna2DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                SetDataToText(); // Cập nhật dữ liệu trong TextBox khi chọn dòng mới
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            LoadAccounts();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            string id = txtsearch.Text; 
            SearchAccountById(id);
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            GetDataFromText();
            if (account.IsValidate()) 
            {
                try
                {
                    if (controller.Create(account))
                    {
                        MessageBox.Show("Tài khoản đã được thêm thành công!");
                        ClearForm();
                        LoadAccounts(); // Làm mới danh sách tài khoản
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra khi thêm tài khoản.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi xảy ra: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Dữ liệu không hợp lệ. Vui lòng kiểm tra lại.");
            }
            ClearForm();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            GetDataFromText();

            if (account.IsValidate())
            {
                try
                {
                    if (controller.Update(account))
                    {
                        MessageBox.Show("Tài khoản đã được cập nhật thành công!");
                        ClearForm();
                        LoadAccounts(); 
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra khi cập nhật tài khoản.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi xảy ra: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Dữ liệu không hợp lệ. Vui lòng kiểm tra lại.");
            }
            ClearForm();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            GetDataFromText();

            if (account.IsValidate()) 
            {
                try
                {
                    if (controller.Delete(account))
                    {
                        MessageBox.Show("Tài khoản đã được xóa thành công!");
                        ClearForm();
                        LoadAccounts(); 
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra khi xóa tài khoản.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi xảy ra: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Dữ liệu không hợp lệ. Vui lòng kiểm tra lại.");
            }
            ClearForm();
        }
        private void ClearForm()
        {
            txtid.Text = string.Empty;

            txtcustomerid.Text = string.Empty;

            txtdateopened.Value = DateTime.Now;

            txtbalance.Text = string.Empty;

        }
    }
}