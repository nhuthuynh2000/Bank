using BankSystem.Controller;
using BankSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BankSystem.View
{
    public partial class CustomerView : Form, IView
    {
        private CustomerController controller;
        private CustomerModel customer;
        private BindingList<CustomerModel> customerList; // Thêm BindingList
    
        public CustomerView()
        {
            InitializeComponent();
            controller = new CustomerController();
            customer = new CustomerModel();
            customerList = new BindingList<CustomerModel>(); // Khởi tạo BindingList
                                                             // Gán sự kiện Load
            this.Load += new EventHandler(CustomerView_Load);
        }

        public void GetDataFromText()
        {
            customer.id = txtid.Text.Trim();
            customer.name = txtname.Text.Trim();
            customer.phone = txtphone.Text.Trim();
            customer.email = txtemail.Text.Trim();
            customer.house_no = txthouseno.Text.Trim(); 
            customer.city = txtcity.Text.Trim();
            customer.pin = txtpin.Text.Trim();
        }

        public void SetDataToText()
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow selectedRow = guna2DataGridView1.SelectedRows[0];

                // Tạo một đối tượng BranchModel từ dữ liệu của dòng đã chọn
                customer = new CustomerModel
                {
                    id = selectedRow.Cells["id"].Value.ToString(),
                    name = selectedRow.Cells["name"].Value.ToString(),
                    phone = selectedRow.Cells["phone"].Value.ToString(),
                    email = selectedRow.Cells["email"].Value.ToString(),
                    house_no = selectedRow.Cells["house_no"].Value.ToString(),
                    city = selectedRow.Cells["city"].Value.ToString(),
                    pin = selectedRow.Cells["pin"].Value.ToString(),

                };

                // Cập nhật dữ liệu vào TextBox
                txtid.Text = customer.id;
                txtname.Text = customer.name;
                txtphone.Text = customer.phone;
                txtemail.Text = customer.email;
                txthouseno.Text = customer.house_no;
                txtcity.Text = customer.city;
                txtpin.Text = customer.pin;

            }
        }
        //Search theo ID
        public void SearchCustomerById(string id)
        {

            if (controller.Load(id))
            {
                UpdateDataGridView();
            }
            else
            {
                MessageBox.Show("Không tìm thấy chi nhánh với ID đã cho.");
            }
        }

        public void UpdateDataGridView()
        {
            customerList.Clear(); // Xóa danh sách hiện tại trước khi thêm mới

            foreach (var customer in controller.Items.Cast<CustomerModel>())
            {
                customerList.Add(customer); // Thêm mỗi chi nhánh vào BindingList
            }

            guna2DataGridView1.DataSource = customerList; // Gán BindingList làm nguồn dữ liệu
        }
        private void LoadCustomers()
        {
            try
            {
                if (controller.Load())
                {
                    var customerData = controller.Items.Cast<CustomerModel>().Select(customer => new
                    {
                        id = customer.id,
                        name = customer.name,
                        phone = customer.phone,
                        email = customer.email,
                        house_no = customer.house_no,
                        city = customer.city,
                        pin = customer.pin
                    }).ToList();

                    guna2DataGridView1.DataSource = customerData; // Gán danh sách mới

                    // Đặt tên hiển thị cho các cột
                    guna2DataGridView1.Columns["id"].HeaderText = "Mã Chi Nhánh";
                    guna2DataGridView1.Columns["name"].HeaderText = "Tên Chi Nhánh";
                    guna2DataGridView1.Columns["phone"].HeaderText = "Số điện thoại";
                    guna2DataGridView1.Columns["email"].HeaderText = "Email";
                    guna2DataGridView1.Columns["house_no"].HeaderText = "Số Nhà";
                    guna2DataGridView1.Columns["city"].HeaderText = "Thành Phố";
                    guna2DataGridView1.Columns["pin"].HeaderText = "Pin";

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
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CustomerView_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            ClearForm();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SetDataToText(); // Hiển thị dữ liệu row được chọn
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
            LoadCustomers();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            string id = txtsearch.Text; 
            SearchCustomerById(id);
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            GetDataFromText();
            if (customer.IsValidate()) 
            {
                try
                {
                    
                    if (controller.Create(customer))
                    {
                        MessageBox.Show("Khách hàng đã được thêm thành công!");
                        ClearForm();
                        LoadCustomers(); 
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra khi thêm khách hàng.");
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

            if (customer.IsValidate())
            {
                try
                {
                    if (controller.Update(customer))
                    {
                        MessageBox.Show("Khách hàng đã được cập nhật thành công!");
                        ClearForm();
                        LoadCustomers(); 
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra khi cập nhật khách hàng.");
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

            if (customer.IsValidate()) 
            {
                try
                {

                    if (controller.Delete(customer))
                    {
                        MessageBox.Show("Khách hàng đã được xóa thành công!");
                        ClearForm();
                        LoadCustomers(); 
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra khi xóa khách hàng.");
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
            txtname.Text = string.Empty;
            txtemail.Text = string.Empty;
            txthouseno.Text = string.Empty; 
            txtpin.Text = string.Empty;
            txtphone.Text = string.Empty;
            txtcity.Text = string.Empty;
           
        }
    }
}
