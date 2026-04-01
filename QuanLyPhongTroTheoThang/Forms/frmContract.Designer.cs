
namespace QuanLyPhongTroTheoThang.Forms
{
    partial class frmContract
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
            groupBox2 = new GroupBox();
            dgvContract = new DataGridView();
            btnThoat = new Button();
            btnTimKiem = new Button();
            btnXuat = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnInHD = new Button();
            btnLapHD = new Button();
            txtTimKiem = new TextBox();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvContract).BeginInit();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(dgvContract);
            groupBox2.Location = new Point(2, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1052, 290);
            groupBox2.TabIndex = 15;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh Sách Hợp Đồng";
            // 
            // dgvContract
            // 
            dgvContract.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvContract.Dock = DockStyle.Fill;
            dgvContract.Location = new Point(3, 23);
            dgvContract.Name = "dgvContract";
            dgvContract.RowHeadersVisible = false;
            dgvContract.RowHeadersWidth = 51;
            dgvContract.Size = new Size(1046, 264);
            dgvContract.TabIndex = 0;
            dgvContract.CellClick += dgvContract_CellClick;
            // 
            // btnThoat
            // 
            btnThoat.Anchor = AnchorStyles.Bottom;
            btnThoat.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThoat.Location = new Point(556, 303);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(94, 29);
            btnThoat.TabIndex = 31;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Anchor = AnchorStyles.Bottom;
            btnTimKiem.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTimKiem.Location = new Point(809, 303);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(94, 29);
            btnTimKiem.TabIndex = 30;
            btnTimKiem.Text = "Tìm Kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // btnXuat
            // 
            btnXuat.Anchor = AnchorStyles.Bottom;
            btnXuat.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXuat.Location = new Point(909, 303);
            btnXuat.Name = "btnXuat";
            btnXuat.Size = new Size(121, 29);
            btnXuat.TabIndex = 29;
            btnXuat.Text = "Xuất Excel...";
            btnXuat.UseVisualStyleBackColor = true;
            btnXuat.Click += btnXuat_Click;
            // 
            // btnXoa
            // 
            btnXoa.Anchor = AnchorStyles.Bottom;
            btnXoa.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXoa.Location = new Point(456, 303);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 26;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Anchor = AnchorStyles.Bottom;
            btnSua.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSua.Location = new Point(356, 303);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 25;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnInHD
            // 
            btnInHD.Anchor = AnchorStyles.Bottom;
            btnInHD.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnInHD.Location = new Point(215, 303);
            btnInHD.Name = "btnInHD";
            btnInHD.Size = new Size(135, 29);
            btnInHD.TabIndex = 24;
            btnInHD.Text = "In Hợp Đồng...";
            btnInHD.UseVisualStyleBackColor = true;
            btnInHD.Click += btnInHD_Click;
            // 
            // btnLapHD
            // 
            btnLapHD.AllowDrop = true;
            btnLapHD.Anchor = AnchorStyles.Bottom;
            btnLapHD.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLapHD.ForeColor = Color.Blue;
            btnLapHD.Location = new Point(27, 303);
            btnLapHD.Name = "btnLapHD";
            btnLapHD.Size = new Size(182, 29);
            btnLapHD.TabIndex = 32;
            btnLapHD.Text = "Lập Hợp Đồng Mới...";
            btnLapHD.UseVisualStyleBackColor = true;
            btnLapHD.Click += btnLapHD_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTimKiem.Location = new Point(656, 303);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(145, 30);
            txtTimKiem.TabIndex = 33;
            // 
            // frmContract
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1054, 344);
            Controls.Add(txtTimKiem);
            Controls.Add(btnLapHD);
            Controls.Add(btnThoat);
            Controls.Add(groupBox2);
            Controls.Add(btnXuat);
            Controls.Add(btnTimKiem);
            Controls.Add(btnInHD);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Name = "frmContract";
            Text = "Quản Lý Hợp Đồng";
            Load += frmContract_Load;
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvContract).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void NtnNhap_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private GroupBox groupBox2;
        private DataGridView dgvContract;
        private Button btnThoat;
        private Button btnTimKiem;
        private Button btnXuat;
        private Button btnXoa;
        private Button btnSua;
        private Button btnInHD;
        private Button btnLapHD;
        private TextBox txtTimKiem;
    }
}