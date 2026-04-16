namespace QuanLyPhongTroTheoThang.Forms
{
    partial class frmBill
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
            dgvBill = new DataGridView();
            btnThoat = new Button();
            groupBox2 = new GroupBox();
            btnXuat = new Button();
            btnTimKiem = new Button();
            btnInHD = new Button();
            btnSua = new Button();
            btnThemHD = new Button();
            btnXoa = new Button();
            txtTimKiem = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvBill).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // dgvBill
            // 
            dgvBill.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBill.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBill.Location = new Point(0, 26);
            dgvBill.Name = "dgvBill";
            dgvBill.RowHeadersVisible = false;
            dgvBill.RowHeadersWidth = 51;
            dgvBill.Size = new Size(1052, 258);
            dgvBill.TabIndex = 0;
            dgvBill.CellContentClick += dgvBill_CellContentClick;
            // 
            // btnThoat
            // 
            btnThoat.Anchor = AnchorStyles.Bottom;
            btnThoat.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThoat.Location = new Point(553, 303);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(94, 29);
            btnThoat.TabIndex = 39;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(dgvBill);
            groupBox2.Location = new Point(2, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1051, 290);
            groupBox2.TabIndex = 32;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh Sách Hóa Đơn";
            // 
            // btnXuat
            // 
            btnXuat.Anchor = AnchorStyles.Bottom;
            btnXuat.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXuat.Location = new Point(905, 303);
            btnXuat.Name = "btnXuat";
            btnXuat.Size = new Size(121, 29);
            btnXuat.TabIndex = 37;
            btnXuat.Text = "Xuất Excel...";
            btnXuat.UseVisualStyleBackColor = true;
            btnXuat.Click += btnXuat_Click;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Anchor = AnchorStyles.Bottom;
            btnTimKiem.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTimKiem.Location = new Point(805, 303);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(94, 29);
            btnTimKiem.TabIndex = 38;
            btnTimKiem.Text = "Tìm Kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // btnInHD
            // 
            btnInHD.Anchor = AnchorStyles.Bottom;
            btnInHD.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnInHD.Location = new Point(212, 303);
            btnInHD.Name = "btnInHD";
            btnInHD.Size = new Size(135, 29);
            btnInHD.TabIndex = 33;
            btnInHD.Text = "In Hóa Đơn...";
            btnInHD.UseVisualStyleBackColor = true;
            btnInHD.Click += btnInHD_Click;
            // 
            // btnSua
            // 
            btnSua.Anchor = AnchorStyles.Bottom;
            btnSua.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSua.Location = new Point(353, 303);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 34;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnThemHD
            // 
            btnThemHD.AllowDrop = true;
            btnThemHD.Anchor = AnchorStyles.Bottom;
            btnThemHD.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThemHD.ForeColor = Color.Blue;
            btnThemHD.Location = new Point(24, 303);
            btnThemHD.Name = "btnThemHD";
            btnThemHD.Size = new Size(182, 29);
            btnThemHD.TabIndex = 36;
            btnThemHD.Text = "Lập Hóa Đơn Mới...";
            btnThemHD.UseVisualStyleBackColor = true;
            btnThemHD.Click += btnThemHD_Click;
            // 
            // btnXoa
            // 
            btnXoa.Anchor = AnchorStyles.Bottom;
            btnXoa.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXoa.Location = new Point(453, 303);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 35;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Anchor = AnchorStyles.Bottom;
            txtTimKiem.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTimKiem.Location = new Point(653, 303);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(145, 30);
            txtTimKiem.TabIndex = 40;
            // 
            // frmBill
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1054, 344);
            Controls.Add(txtTimKiem);
            Controls.Add(btnThoat);
            Controls.Add(groupBox2);
            Controls.Add(btnXuat);
            Controls.Add(btnTimKiem);
            Controls.Add(btnInHD);
            Controls.Add(btnSua);
            Controls.Add(btnThemHD);
            Controls.Add(btnXoa);
            Name = "frmBill";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Hóa Đơn";
            WindowState = FormWindowState.Maximized;
            Load += frmBill_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBill).EndInit();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvBill;
        private Button btnThoat;
        private GroupBox groupBox2;
        private Button btnXuat;
        private Button btnTimKiem;
        private Button btnInHD;
        private Button btnSua;
        private Button btnThemHD;
        private Button btnXoa;
        private TextBox txtTimKiem;
    }
}