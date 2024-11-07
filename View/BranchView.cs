using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankSystem.Model;
using BankSystem.Controller;
using System.Xml.Linq;


namespace BankSystem.View
{
    public partial class BranchView : Form, IView
    {
        private BranchController controller;
        private BranchModel branch;
        private BindingList<BranchModel> branchList; // Thêm BindingList


        public BranchView()
        {
            InitializeComponent();
            controller = new BranchController();
            branch = new BranchModel();
            branchList = new BindingList<BranchModel>();
           
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SetDataToText(); // Hiển thị dữ liệu row được chọn
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        
        private void guna2DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                SetDataToText(); // Cập nhật dữ liệu trong TextBox khi chọn dòng mới
            }

        }

      

        public void GetDataFromText()
        {
            branch.id = txtid.Text.Trim();
            branch.name = txtname.Text.Trim();
            branch.city = txtcity.Text.Trim();
            branch.house_no = txthouseno.Text.Trim(); 
           
        }
        public void SetDataToText()
        {


            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = guna2DataGridView1.SelectedRows[0];

                branch = new BranchModel
                {
                    id = selectedRow.Cells["id"].Value.ToString(),
                    name = selectedRow.Cells["name"].Value.ToString(),
                    house_no = selectedRow.Cells["house_no"].Value.ToString(),
                    city = selectedRow.Cells["city"].Value.ToString(),

                };

                // Cập nhật dữ liệu vào TextBox
                txtid.Text = branch.id;
                txtname.Text = branch.name;
                txtcity.Text = branch.city;
                txthouseno.Text = branch.house_no;
                

            }

        }

        private void BranchView_Load(object sender, EventArgs e)
        {
            LoadBranches();
            ClearForm();
        }

        public void UpdateDataGridView()
        {
            branchList.Clear(); // Xóa danh sách hiện tại trước khi thêm mới

            foreach (var branch in controller.Items.Cast<BranchModel>())
            {
                branchList.Add(branch); // Thêm mỗi chi nhánh vào BindingList
            }

            guna2DataGridView1.DataSource = branchList; // Gán BindingList làm nguồn dữ liệu
        }

        private void LoadBranches()
        {
            try
            {
                if (controller.Load())
                {
                    var branchData = controller.Items.Cast<BranchModel>().Select(branch => new
                    {
                        id = branch.id,
                        name = branch.name,
                        house_no = branch.house_no,
                        city = branch.city
                    }).ToList();

                    guna2DataGridView1.DataSource = branchData;
                    // Đặt tên hiển thị cho các cột
                    guna2DataGridView1.Columns["id"].HeaderText = "Mã Chi Nhánh";
                    guna2DataGridView1.Columns["name"].HeaderText = "Tên Chi Nhánh";
                    guna2DataGridView1.Columns["house_no"].HeaderText = "Địa chỉ";
                    guna2DataGridView1.Columns["city"].HeaderText = "Thành Phố";
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

        private void btn_create_Click(object sender, EventArgs e)
        {
            GetDataFromText(); 
                             
            if (branch.IsValidate()) 
            {
                try
                {
                    
                    if (controller.Create(branch))
                    {
                        MessageBox.Show("Chi nhánh đã được thêm thành công!");
                        ClearForm();
                        LoadBranches(); 
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra khi thêm chi nhánh.");
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

            if (branch.IsValidate()) 
            {
                try
                {

                    // Gọi hàm Delete với đối tượng BranchModel
                    if (controller.Delete(branch))
                    {
                        MessageBox.Show("Chi nhánh đã được xóa thành công!");
                        ClearForm();
                        LoadBranches(); 
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra khi xóa chi nhánh.");
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
    ClearForm() ;
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            GetDataFromText();

            if (branch.IsValidate())
            {
                try
                {
                    if (controller.Update(branch))
                    {
                        MessageBox.Show("Chi nhánh đã được cập nhật thành công!");
                        ClearForm();
                        LoadBranches(); 
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra khi cập nhật chi nhánh.");
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
   
            txthouseno.Text = string.Empty;
   
            txtcity.Text = string.Empty;
    
        }


        public void SearchBranchById(string id)
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


        private void btn_search_Click(object sender, EventArgs e)
        {

            string id = txtsearch.Text;
            SearchBranchById(id);
        }
        private void btn_back_Click(object sender, EventArgs e)
        {

            LoadBranches(); 
        }
    }

}
