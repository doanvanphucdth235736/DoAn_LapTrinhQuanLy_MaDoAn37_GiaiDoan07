using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyPhongTroTheoThang.Forms
{
    public partial class frmChangePassword : Form
    {
        QLPTDbContext context = new QLPTDbContext();

        private string _usernameHienTai;
        public frmChangePassword(string username)
        {
            InitializeComponent();
            _usernameHienTai = username;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string passCu = txtMatKhauCu.Text.Trim();
            string passMoi = txtMatKhauMoi.Text.Trim();
            string passXacNhan = txtXacNhan.Text.Trim();

            if (string.IsNullOrEmpty(passCu) || string.IsNullOrEmpty(passMoi) || string.IsNullOrEmpty(passXacNhan))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (passMoi != passXacNhan)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận không khớp nhau!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var user = context.Users.FirstOrDefault(u => u.Username == _usernameHienTai);

            if (user == null)
            {
                MessageBox.Show("Lỗi: Không tìm thấy thông tin tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (user.Password != passCu)
            {
                MessageBox.Show("Mật khẩu cũ không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            user.Password = passMoi;

            try
            {
                context.SaveChanges();
                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
