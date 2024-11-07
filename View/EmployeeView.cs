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
using System.Xml.Linq;

namespace BankSystem.View
{
    public partial class EmployeeView : Form, IView
    {
        private EmployeeController controller;
        private EmployeeModel employee;
        private BindingList<EmployeeModel> employeeList;

        public EmployeeView()
        {
            InitializeComponent();
            controller = new EmployeeController();
            employee = new EmployeeModel();
            employeeList = new BindingList<EmployeeModel>(); // Khởi tạo BindingList
                                                             
            this.Load += new EventHandler(EmployeeView_Load);
        }

        public void GetDataFromText()
        {
            employee.id = txtid.Text.Trim();
            employee.password = txtpassword.Text.Trim();
            employee.role = txtrole.Text.Trim();
        }

        public void SetDataToText()
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow selectedRow = guna2DataGridView1.SelectedRows[0];

                // Tạo một đối tượng BranchModel từ dữ liệu của dòng đã chọn
                employee = new EmployeeModel
                {
                    id = selectedRow.Cells["id"].Value.ToString(),
                    password = selectedRow.Cells["password"].Value.ToString(),
                    role = selectedRow.Cells["role"].Value.ToString(),
                };

                // Cập nhật dữ liệu vào TextBox
                txtid.Text = employee.id;
                txtpassword.Text = employee.password;
                txtrole.Text = employee.role;

            }
        }

        private void EmployeeView_Load(object sender, EventArgs e)
        {
            LoadEmployees();
            ClearForm(); 
        }
        //Search theo ID
        public void SearchEmployeeById(string id)
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
            employeeList.Clear(); // Xóa danh sách hiện tại trước khi thêm mới

            foreach (var employee in controller.Items.Cast<EmployeeModel>())
            {
                employeeList.Add(employee); // Thêm mỗi nhân viên vào BindingList
            }

            guna2DataGridView1.DataSource = employeeList; // Gán BindingList làm nguồn dữ liệu
        }

        private void LoadEmployees()
        {
            try
            {
                if (controller.Load())
                {
                    var employeeData = controller.Items.Cast<EmployeeModel>().Select(employee => new
                    {
                        id = employee.id,
                        password = employee.password,
                        role = employee.role,

                    }).ToList();

                    guna2DataGridView1.DataSource = employeeData; 

                    // Đặt tên hiển thị cho các cột
                    guna2DataGridView1.Columns["id"].HeaderText = "Mã Nhân Viên";
                    guna2DataGridView1.Columns["password"].HeaderText = "Mật khẩu";
                    guna2DataGridView1.Columns["role"].HeaderText = "Vai trò";
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

        private void btn_search_Click(object sender, EventArgs e)
        {
            string id = txtsearch.Text; 
            SearchEmployeeById(id);
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            GetDataFromText();
                              
            if (employee.IsValidate()) 
            {
                try
                {
                    
                    if (controller.Create(employee))
                    {
                        MessageBox.Show("Nhân viên đã được thêm thành công!");
                        ClearForm();
                        LoadEmployees(); 
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra khi thêm nhân viên.");
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

            if (employee.IsValidate())
            {
                try
                {
                    if (controller.Update(employee))
                    {
                        MessageBox.Show("Nhân viên đã được cập nhật thành công!");
                        ClearForm();
                        LoadEmployees();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra khi cập nhật nhân viên.");
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

            if (employee.IsValidate())
            {
                try
                {

                   
                    if (controller.Delete(employee))
                    {
                        MessageBox.Show("Nhân viên đã được xóa thành công!");
                        ClearForm();
                        LoadEmployees();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra khi xóa nhân viên.");
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
            LoadEmployees(); // Gọi lại phương thức để tải lại danh sách chi nhánh

        }
        private void ClearForm()
        {
            txtid.Text = string.Empty;
            txtpassword.Text = string.Empty;
            txtrole.SelectedIndex = -1; // Xóa lựa chọn.
            txtrole.Text = string.Empty;

        }
    }
}
