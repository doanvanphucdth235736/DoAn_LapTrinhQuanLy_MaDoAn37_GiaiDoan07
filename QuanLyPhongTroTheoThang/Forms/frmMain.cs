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
        private Form frmKhachHang_Con = null;
        private Form frmPhong_Con = null;
        private Form frmHopDong_Con = null;
        private Form frmBill_Con = null;
        private Form frmNhanSu_Con = null;
        private Form frmThongKeBill_Con = null;
        private Form frmThongKeHopDong_Con = null;

        private bool isExiting = false;

        public frmMain()
        {
            InitializeComponent();
            this.FormClosing += frmMain_FormClosing;

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ChuaDangNhap();
        }
        public void ChuaDangNhap()
        {
            // Bật/tắt menu Hệ thống
            mnuDangNhap.Enabled = true;
            mnuDangXuat.Enabled = false;
            mnuDoiMatKhau.Enabled = false;

            // Ẩn hoàn toàn các menu nghiệp vụ
            mnuQuanLy.Visible = false;
            mnuBaoCaoThongKe.Visible = false;

            // Trợ giúp và Thoát luôn hiện (không cần code đổi trạng thái)

            // Cập nhật thanh trạng thái
            lblTrangThai.Text = "Chưa đăng nhập.";
        }

        public void QuyenAdmin(string tenNguoiDung)
        {
            mnuDangNhap.Enabled = false;
            mnuDangXuat.Enabled = true;
            mnuDoiMatKhau.Enabled = true;

            // Hiện full chức năng
            mnuQuanLy.Visible = true;
            mnuNhanSu.Visible = true; // Admin có quản lý nhân sự
            mnuBaoCaoThongKe.Visible = true;

            lblTrangThai.Text = "Quản trị viên: " + tenNguoiDung;
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
            if (frmKhachHang_Con == null || frmKhachHang_Con.IsDisposed)
            {
                frmKhachHang_Con = new frmTenant();
                frmKhachHang_Con.MdiParent = this;
                frmKhachHang_Con.Show();
            }
            else
            {
                frmKhachHang_Con.Activate();
            }
        }

        private void mnuPhong_Click(object sender, EventArgs e)
        {
            if (frmPhong_Con == null || frmPhong_Con.IsDisposed)
            {
                frmPhong_Con = new frmRoom();
                frmPhong_Con.MdiParent = this;
                frmPhong_Con.Show();
            }
            else frmPhong_Con.Activate();
        }

        private void mnuHopDong_Click(object sender, EventArgs e)
        {
            if (frmHopDong_Con == null || frmHopDong_Con.IsDisposed)
            {
                frmHopDong_Con = new frmContract();
                frmHopDong_Con.MdiParent = this;
                frmHopDong_Con.Show();
            }
            else frmHopDong_Con.Activate();
        }

        private void mnuNhanSu_Click(object sender, EventArgs e)
        {
            if (frmNhanSu_Con == null || frmNhanSu_Con.IsDisposed)
            {
                frmNhanSu_Con = new frmUser();
                frmNhanSu_Con.MdiParent = this;
                frmNhanSu_Con.Show();
            }
            else frmNhanSu_Con.Activate();
        }

        private void mnuBill_Click(object sender, EventArgs e)
        {
            if (frmBill_Con == null || frmBill_Con.IsDisposed)
            {
                frmBill_Con = new frmBill();
                frmBill_Con.MdiParent = this;
                frmBill_Con.Show();
            }
            else frmBill_Con.Activate();
        }

        private void mnuThongKeBill_Click(object sender, EventArgs e)
        {

        }

        private void mnuThongKeHopDong_Click(object sender, EventArgs e)
        {

        }

        private void mnuHuongDanSuDung_Click(object sender, EventArgs e)
        {

        }

        private void mnuThongTinPhanMem_Click(object sender, EventArgs e)
        {

        }

        private void mnuDoiMatKhau_Click(object sender, EventArgs e)
        {

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
                isExiting = true; // cho phép thoát thật
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
    }
}
