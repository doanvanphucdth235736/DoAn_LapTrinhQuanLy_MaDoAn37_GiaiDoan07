namespace QuanLyPhongTroTheoThang.Forms
{
    partial class frmMain
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
            MenuStrip = new MenuStrip();
            mnuHeThong = new ToolStripMenuItem();
            mnuDangNhap = new ToolStripMenuItem();
            mnuDangXuat = new ToolStripMenuItem();
            mnuDoiMatKhau = new ToolStripMenuItem();
            mnuThoat = new ToolStripMenuItem();
            mnuQuanLy = new ToolStripMenuItem();
            mnuKhachHang = new ToolStripMenuItem();
            mnuPhong = new ToolStripMenuItem();
            mnuHopDong = new ToolStripMenuItem();
            mnuBill = new ToolStripMenuItem();
            mnuNhanSu = new ToolStripMenuItem();
            mnuBaoCaoThongKe = new ToolStripMenuItem();
            mnuThongKeBill = new ToolStripMenuItem();
            mnuThongKeHopDong = new ToolStripMenuItem();
            mnuTroGiup = new ToolStripMenuItem();
            mnuHuongDanSuDung = new ToolStripMenuItem();
            mnuThongTinPhanMem = new ToolStripMenuItem();
            StatusStrip = new StatusStrip();
            lblTrangThai = new ToolStripStatusLabel();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            lblLienKet = new ToolStripStatusLabel();
            MenuStrip.SuspendLayout();
            StatusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // MenuStrip
            // 
            MenuStrip.ImageScalingSize = new Size(20, 20);
            MenuStrip.Items.AddRange(new ToolStripItem[] { mnuHeThong, mnuQuanLy, mnuBaoCaoThongKe, mnuTroGiup });
            MenuStrip.Location = new Point(0, 0);
            MenuStrip.Name = "MenuStrip";
            MenuStrip.Size = new Size(800, 33);
            MenuStrip.TabIndex = 1;
            // 
            // mnuHeThong
            // 
            mnuHeThong.DropDownItems.AddRange(new ToolStripItem[] { mnuDangNhap, mnuDangXuat, mnuDoiMatKhau, mnuThoat });
            mnuHeThong.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            mnuHeThong.Name = "mnuHeThong";
            mnuHeThong.Size = new Size(104, 29);
            mnuHeThong.Text = "Hệ Thống";
            // 
            // mnuDangNhap
            // 
            mnuDangNhap.Name = "mnuDangNhap";
            mnuDangNhap.Size = new Size(333, 30);
            mnuDangNhap.Text = "Đăng nhập...";
            mnuDangNhap.Click += mnuDangNhap_Click;
            // 
            // mnuDangXuat
            // 
            mnuDangXuat.Name = "mnuDangXuat";
            mnuDangXuat.Size = new Size(333, 30);
            mnuDangXuat.Text = "Đăng Xuất";
            mnuDangXuat.Click += mnuDangXuat_Click;
            // 
            // mnuDoiMatKhau
            // 
            mnuDoiMatKhau.Name = "mnuDoiMatKhau";
            mnuDoiMatKhau.Size = new Size(333, 30);
            mnuDoiMatKhau.Text = "Đổi mật khẩu...";
            mnuDoiMatKhau.Click += mnuDoiMatKhau_Click;
            // 
            // mnuThoat
            // 
            mnuThoat.Name = "mnuThoat";
            mnuThoat.Size = new Size(333, 30);
            mnuThoat.Text = "Thoát (ShortcutKeys: Alt + F4)";
            mnuThoat.Click += mnuThoat_Click;
            // 
            // mnuQuanLy
            // 
            mnuQuanLy.DropDownItems.AddRange(new ToolStripItem[] { mnuKhachHang, mnuPhong, mnuHopDong, mnuBill, mnuNhanSu });
            mnuQuanLy.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            mnuQuanLy.Name = "mnuQuanLy";
            mnuQuanLy.Size = new Size(90, 29);
            mnuQuanLy.Text = "Quản Lý";
            // 
            // mnuKhachHang
            // 
            mnuKhachHang.Name = "mnuKhachHang";
            mnuKhachHang.Size = new Size(205, 30);
            mnuKhachHang.Text = "Khách Hàng...";
            mnuKhachHang.Click += mnuKhachHang_Click;
            // 
            // mnuPhong
            // 
            mnuPhong.Name = "mnuPhong";
            mnuPhong.Size = new Size(205, 30);
            mnuPhong.Text = "Phòng...";
            mnuPhong.Click += mnuPhong_Click;
            // 
            // mnuHopDong
            // 
            mnuHopDong.Name = "mnuHopDong";
            mnuHopDong.Size = new Size(205, 30);
            mnuHopDong.Text = "Hợp Đồng...";
            mnuHopDong.Click += mnuHopDong_Click;
            // 
            // mnuBill
            // 
            mnuBill.Name = "mnuBill";
            mnuBill.Size = new Size(205, 30);
            mnuBill.Text = "Hóa Đơn...";
            mnuBill.Click += mnuBill_Click;
            // 
            // mnuNhanSu
            // 
            mnuNhanSu.Name = "mnuNhanSu";
            mnuNhanSu.Size = new Size(205, 30);
            mnuNhanSu.Text = "Nhân Sự...";
            mnuNhanSu.Click += mnuNhanSu_Click;
            // 
            // mnuBaoCaoThongKe
            // 
            mnuBaoCaoThongKe.DropDownItems.AddRange(new ToolStripItem[] { mnuThongKeBill, mnuThongKeHopDong });
            mnuBaoCaoThongKe.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            mnuBaoCaoThongKe.Name = "mnuBaoCaoThongKe";
            mnuBaoCaoThongKe.Size = new Size(184, 29);
            mnuBaoCaoThongKe.Text = "Báo Cáo - Thống Kê";
            // 
            // mnuThongKeBill
            // 
            mnuThongKeBill.Name = "mnuThongKeBill";
            mnuThongKeBill.Size = new Size(269, 30);
            mnuThongKeBill.Text = "Thống kê hóa đơn...";
            mnuThongKeBill.Click += mnuThongKeBill_Click;
            // 
            // mnuThongKeHopDong
            // 
            mnuThongKeHopDong.Name = "mnuThongKeHopDong";
            mnuThongKeHopDong.Size = new Size(269, 30);
            mnuThongKeHopDong.Text = "Thống kê hợp đồng...";
            mnuThongKeHopDong.Click += mnuThongKeHopDong_Click;
            // 
            // mnuTroGiup
            // 
            mnuTroGiup.DropDownItems.AddRange(new ToolStripItem[] { mnuHuongDanSuDung, mnuThongTinPhanMem });
            mnuTroGiup.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            mnuTroGiup.Name = "mnuTroGiup";
            mnuTroGiup.Size = new Size(92, 29);
            mnuTroGiup.Text = "Trợ Giúp";
            // 
            // mnuHuongDanSuDung
            // 
            mnuHuongDanSuDung.Name = "mnuHuongDanSuDung";
            mnuHuongDanSuDung.Size = new Size(455, 30);
            mnuHuongDanSuDung.Text = "Hướng dẫn sử dụng (ShortcutKeys: Ctrl + F1)";
            mnuHuongDanSuDung.Click += mnuHuongDanSuDung_Click;
            // 
            // mnuThongTinPhanMem
            // 
            mnuThongTinPhanMem.Name = "mnuThongTinPhanMem";
            mnuThongTinPhanMem.Size = new Size(455, 30);
            mnuThongTinPhanMem.Text = "Thông tin phần mềm...";
            mnuThongTinPhanMem.Click += mnuThongTinPhanMem_Click;
            // 
            // StatusStrip
            // 
            StatusStrip.ImageScalingSize = new Size(20, 20);
            StatusStrip.Items.AddRange(new ToolStripItem[] { lblTrangThai, toolStripStatusLabel1, lblLienKet });
            StatusStrip.Location = new Point(0, 421);
            StatusStrip.Name = "StatusStrip";
            StatusStrip.Size = new Size(800, 29);
            StatusStrip.TabIndex = 2;
            StatusStrip.Text = "statusStrip1";
            // 
            // lblTrangThai
            // 
            lblTrangThai.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(142, 23);
            lblTrangThai.Text = "Chưa đăng nhập.";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(0, 23);
            // 
            // lblLienKet
            // 
            lblLienKet.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLienKet.IsLink = true;
            lblLienKet.Name = "lblLienKet";
            lblLienKet.Size = new Size(93, 23);
            lblLienKet.Text = "© 2026 FIT";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(StatusStrip);
            Controls.Add(MenuStrip);
            IsMdiContainer = true;
            MainMenuStrip = MenuStrip;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Trang Chủ";
            FormClosing += frmMain_FormClosing;
            Load += frmMain_Load;
            MenuStrip.ResumeLayout(false);
            MenuStrip.PerformLayout();
            StatusStrip.ResumeLayout(false);
            StatusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip MenuStrip;
        private ToolStripMenuItem mnuHeThong;
        private ToolStripMenuItem mnuQuanLy;
        private ToolStripMenuItem mnuBaoCaoThongKe;
        private ToolStripMenuItem mnuTroGiup;
        private StatusStrip StatusStrip;
        private ToolStripMenuItem mnuDangNhap;
        private ToolStripMenuItem mnuDangXuat;
        private ToolStripMenuItem mnuDoiMatKhau;
        private ToolStripMenuItem mnuThoat;
        private ToolStripMenuItem mnuKhachHang;
        private ToolStripMenuItem mnuPhong;
        private ToolStripMenuItem mnuHopDong;
        private ToolStripMenuItem mnuBill;
        private ToolStripMenuItem mnuNhanSu;
        private ToolStripMenuItem mnuThongKeBill;
        private ToolStripMenuItem mnuThongKeHopDong;
        private ToolStripMenuItem mnuHuongDanSuDung;
        private ToolStripMenuItem mnuThongTinPhanMem;
        private ToolStripStatusLabel lblTrangThai;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel lblLienKet;
    }
}