using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyPhongTroTheoThang.Data; 

namespace QuanLyPhongTroTheoThang.Forms
{
    public partial class frmUser : Form
    {
        QLPTDbContext context = new QLPTDbContext();
        private bool isAdding = false;
        public frmUser()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            LoadPositions();
            LoadData();
            DisableControls();
        }

        private void LoadPositions()
        {
            cboPosition.Items.Clear();
            cboPosition.Items.AddRange(new string[] { "Chủ trọ", "Nhân viên" });
            cboPosition.SelectedIndex = 0;
        }

        private void LoadData()
        {
            var users = context.Users.Select(u => new
            {
                u.UserID,
                u.FullName,
                u.Position,
                u.Username,
                u.Password
            }).ToList();

            dgvUser.DataSource = users;

            // Định dạng tiêu đề cột
            dgvUser.Columns["UserID"].HeaderText = "ID";
            dgvUser.Columns["FullName"].HeaderText = "Họ và Tên";
            dgvUser.Columns["Position"].HeaderText = "Chức Vụ";
            dgvUser.Columns["Username"].HeaderText = "Tài Khoản";
            dgvUser.Columns["Password"].HeaderText = "Mật Khẩu";
            dgvUser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void DisableControls()
        {
            txtFullName.Enabled = false;
            cboPosition.Enabled = false;
            txtUserName.Enabled = false;
            txtPassword.Enabled = false;

            btnLuu.Enabled = false;
            btnHuyBo.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void EnableControls()
        {
            txtFullName.Enabled = true;
            cboPosition.Enabled = true;
            txtUserName.Enabled = true;
            txtPassword.Enabled = true;

            btnLuu.Enabled = true;
            btnHuyBo.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void ClearInputs()
        {
            txtFullName.Clear();
            txtUserName.Clear();
            txtPassword.Clear();
            cboPosition.SelectedIndex = 0;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdding = true;
            ClearInputs();
            EnableControls();
            txtFullName.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tài khoản và Mật khẩu!", "Thông báo");
                return;
            }

            try
            {
                if (isAdding)
                {
                    // Kiểm tra trùng username
                    if (context.Users.Any(u => u.Username == txtUserName.Text))
                    {
                        MessageBox.Show("Tên đăng nhập này đã tồn tại!", "Lỗi");
                        return;
                    }

                    var newUser = new User
                    {
                        FullName = txtFullName.Text,
                        Position = cboPosition.Text,
                        Username = txtUserName.Text,
                        Password = txtPassword.Text,
                        // Tự động phân quyền Role dựa trên chức vụ
                        Role = (cboPosition.Text == "Chủ trọ" || cboPosition.Text == "Quản lý") ? "Admin" : "Staff"
                    };
                    context.Users.Add(newUser);
                }
                else
                {
                    int id = (int)dgvUser.CurrentRow.Cells["UserID"].Value;
                    var user = context.Users.Find(id);
                    if (user != null)
                    {
                        user.FullName = txtFullName.Text;
                        user.Position = cboPosition.Text;
                        user.Password = txtPassword.Text;
                        user.Role = (cboPosition.Text == "Chủ trọ" || cboPosition.Text == "Quản lý") ? "Admin" : "Staff";
                    }
                }

                context.SaveChanges();
                MessageBox.Show("Lưu dữ liệu thành công!");
                LoadData();
                DisableControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvUser.CurrentRow == null) return;
            isAdding = false;
            EnableControls();
            txtUserName.Enabled = false;
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            DisableControls();
            dgvUser_SelectionChanged(null, null);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvUser.CurrentRow == null) return;

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân sự này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                int id = (int)dgvUser.CurrentRow.Cells["UserID"].Value;
                var user = context.Users.Find(id);
                if (user != null)
                {
                    context.Users.Remove(user);
                    context.SaveChanges();
                    LoadData();
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvUser_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUser.CurrentRow != null && !isAdding)
            {
                txtFullName.Text = dgvUser.CurrentRow.Cells["FullName"].Value?.ToString();
                cboPosition.Text = dgvUser.CurrentRow.Cells["Position"].Value?.ToString();
                txtUserName.Text = dgvUser.CurrentRow.Cells["Username"].Value?.ToString();
                txtPassword.Text = dgvUser.CurrentRow.Cells["Password"].Value?.ToString();
            }
        }
    }
}
