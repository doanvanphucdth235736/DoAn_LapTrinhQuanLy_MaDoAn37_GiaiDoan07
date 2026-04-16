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

    public partial class frmMain : Form
    {
        QLPTDbContext context = new QLPTDbContext();

        private bool isExiting = false;
        public static string UsernameHienTai { get; set; }
        public static string TenNhanVienHienTai { get; set; }
        public frmMain()
        {
            InitializeComponent();
            this.FormClosing += frmMain_FormClosing;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            this.DoubleBuffered = true;

            this.Resize += (s, e) =>
            {
                this.Refresh();
            };
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ChuaDangNhap();
        }

        // --- HÀM HỖ TRỢ MỞ FORM CON ---
        private void OpenChildForm(Form childForm)
        {
            // Kiểm tra xem form này đã được mở trước đó chưa
            foreach (Form frm in this.MdiChildren)
            {
                // Nếu đã mở, thì kích hoạt (đưa lên mặt trước)
                if (frm.GetType() == childForm.GetType())
                {
                    frm.Activate();
                    return;
                }
            }

            // Nếu chưa mở, thiết lập frmMain làm cha và hiển thị
            childForm.MdiParent = this;
            childForm.Show();
        }
        // ------------------------------

        public void ChuaDangNhap()
        {
            mnuDangNhap.Enabled = true;
            mnuDangXuat.Enabled = false;
            mnuDoiMatKhau.Enabled = false;

            mnuQuanLy.Visible = false;
            mnuBaoCaoThongKe.Visible = false;

            lblTrangThai.Text = "Chưa đăng nhập.";
        }

        public void QuyenAdmin(string tenNguoiDung)
        {
            mnuDangNhap.Enabled = false;
            mnuDangXuat.Enabled = true;
            mnuDoiMatKhau.Enabled = true;

            mnuQuanLy.Visible = true;
            mnuNhanSu.Visible = true;
            mnuBaoCaoThongKe.Visible = true;

            lblTrangThai.Text = "Quản trị viên: " + tenNguoiDung;
            OpenChildForm(new frmRoom_Map());
        }

        public void QuyenStaff(string tenNguoiDung)
        {
            mnuDangNhap.Enabled = false;
            mnuDangXuat.Enabled = true;
            mnuDoiMatKhau.Enabled = true;

            mnuQuanLy.Visible = true;
            mnuNhanSu.Visible = false;

            mnuBaoCaoThongKe.Visible = false;

            lblTrangThai.Text = "Nhân viên: " + tenNguoiDung;
            OpenChildForm(new frmRoom_Map());
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }
            ChuaDangNhap();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            ThoatApp();
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmTenant());
        }

        private void mnuPhong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmRoom());
        }

        private void mnuHopDong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmContract());
        }

        private void mnuNhanSu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmUser());
        }

        private void mnuBill_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmBill());
        }
        // -------------------------------------------------

        private void mnuThongKeBill_Click(object sender, EventArgs e)
        {
            // OpenChildForm(new frmThongKeBill()); // Mở comment và sửa lại tên form khi bạn làm xong form này
        }

        private void mnuThongKeHopDong_Click(object sender, EventArgs e)
        {
            // OpenChildForm(new frmThongKeHopDong());
        }

        private void mnuHuongDanSuDung_Click(object sender, EventArgs e)
        {
        }

        private void mnuThongTinPhanMem_Click(object sender, EventArgs e)
        {
        }

        private void mnuDoiMatKhau_Click(object sender, EventArgs e)
        {
            frmChangePassword f = new frmChangePassword(UsernameHienTai);
            f.ShowDialog();
        }

        private void ThoatApp()
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn thoát?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                isExiting = true;
                Application.Exit();
            }
        }

        private void mnuDangNhap_Click(object sender, EventArgs e)
        {
            frmLogin f = new frmLogin(this);
            f.ShowDialog();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isExiting)
            {
                e.Cancel = true;
                ThoatApp();
            }
        }

        private void sơĐồPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}