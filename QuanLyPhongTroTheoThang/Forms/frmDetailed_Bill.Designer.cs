namespace QuanLyPhongTroTheoThang.Forms
{
    partial class frmDetailed_Bill
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
            label6 = new Label();
            label7 = new Label();
            label5 = new Label();
            cboContract = new ComboBox();
            txtRoomName = new TextBox();
            label4 = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            groupBox2 = new GroupBox();
            lblWaterUsed = new Label();
            lblElectricUsed = new Label();
            nudWaterNew = new NumericUpDown();
            nudWaterOld = new NumericUpDown();
            nudElectricNew = new NumericUpDown();
            nudElectricOld = new NumericUpDown();
            label10 = new Label();
            label9 = new Label();
            groupBox3 = new GroupBox();
            groupBox1 = new GroupBox();
            txtNhanVienLap = new TextBox();
            label15 = new Label();
            txtRoomPrice = new TextBox();
            label14 = new Label();
            dtpMonth = new DateTimePicker();
            chkStatus = new CheckBox();
            label11 = new Label();
            txtTenantName = new TextBox();
            label8 = new Label();
            btnHuyBo = new Button();
            btnLuu = new Button();
            groupBox4 = new GroupBox();
            label13 = new Label();
            txtTotal = new TextBox();
            label12 = new Label();
            txtNotes = new TextBox();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudWaterNew).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudWaterOld).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudElectricNew).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudElectricOld).BeginInit();
            groupBox1.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(589, 52);
            label6.Name = "label6";
            label6.Size = new Size(67, 23);
            label6.TabIndex = 25;
            label6.Text = "Số mới:";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(427, 52);
            label7.Name = "label7";
            label7.Size = new Size(56, 23);
            label7.TabIndex = 23;
            label7.Text = "Số cũ:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(199, 52);
            label5.Name = "label5";
            label5.Size = new Size(67, 23);
            label5.TabIndex = 21;
            label5.Text = "Số mới:";
            // 
            // cboContract
            // 
            cboContract.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboContract.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboContract.FormattingEnabled = true;
            cboContract.Location = new Point(136, 26);
            cboContract.Name = "cboContract";
            cboContract.Size = new Size(359, 33);
            cboContract.TabIndex = 18;
            cboContract.SelectedIndexChanged += cboContract_SelectedIndexChanged;
            // 
            // txtRoomName
            // 
            txtRoomName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtRoomName.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRoomName.Location = new Point(136, 63);
            txtRoomName.Name = "txtRoomName";
            txtRoomName.Size = new Size(359, 31);
            txtRoomName.TabIndex = 17;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(29, 26);
            label4.Name = "label4";
            label4.Size = new Size(78, 25);
            label4.TabIndex = 16;
            label4.Text = "Ghi Chú:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(10, 66);
            label1.Name = "label1";
            label1.Size = new Size(68, 25);
            label1.TabIndex = 0;
            label1.Text = "Phòng:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(10, 103);
            label2.Name = "label2";
            label2.Size = new Size(106, 25);
            label2.TabIndex = 1;
            label2.Text = "Khách Thuê:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(43, 52);
            label3.Name = "label3";
            label3.Size = new Size(56, 23);
            label3.TabIndex = 2;
            label3.Text = "Số cũ:";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(lblWaterUsed);
            groupBox2.Controls.Add(lblElectricUsed);
            groupBox2.Controls.Add(nudWaterNew);
            groupBox2.Controls.Add(nudWaterOld);
            groupBox2.Controls.Add(nudElectricNew);
            groupBox2.Controls.Add(nudElectricOld);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(groupBox3);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label5);
            groupBox2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(2, 199);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(797, 100);
            groupBox2.TabIndex = 19;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông Tin Điện Nước";
            // 
            // lblWaterUsed
            // 
            lblWaterUsed.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblWaterUsed.AutoSize = true;
            lblWaterUsed.Location = new Point(535, 23);
            lblWaterUsed.Name = "lblWaterUsed";
            lblWaterUsed.Size = new Size(121, 23);
            lblWaterUsed.TabIndex = 34;
            lblWaterUsed.Text = "Sử dụng: 0 m3";
            // 
            // lblElectricUsed
            // 
            lblElectricUsed.AutoSize = true;
            lblElectricUsed.Location = new Point(149, 23);
            lblElectricUsed.Name = "lblElectricUsed";
            lblElectricUsed.Size = new Size(131, 23);
            lblElectricUsed.TabIndex = 33;
            lblElectricUsed.Text = "Sử dụng: 0 kWh";
            // 
            // nudWaterNew
            // 
            nudWaterNew.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nudWaterNew.Location = new Point(656, 50);
            nudWaterNew.Name = "nudWaterNew";
            nudWaterNew.Size = new Size(77, 30);
            nudWaterNew.TabIndex = 32;
            // 
            // nudWaterOld
            // 
            nudWaterOld.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nudWaterOld.Location = new Point(481, 50);
            nudWaterOld.Name = "nudWaterOld";
            nudWaterOld.Size = new Size(77, 30);
            nudWaterOld.TabIndex = 31;
            // 
            // nudElectricNew
            // 
            nudElectricNew.Location = new Point(264, 50);
            nudElectricNew.Name = "nudElectricNew";
            nudElectricNew.Size = new Size(77, 30);
            nudElectricNew.TabIndex = 30;
            // 
            // nudElectricOld
            // 
            nudElectricOld.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            nudElectricOld.Location = new Point(97, 50);
            nudElectricOld.Name = "nudElectricOld";
            nudElectricOld.Size = new Size(77, 30);
            nudElectricOld.TabIndex = 29;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(405, 23);
            label10.Name = "label10";
            label10.Size = new Size(67, 25);
            label10.TabIndex = 28;
            label10.Text = "NƯỚC:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(26, 23);
            label9.Name = "label9";
            label9.Size = new Size(56, 25);
            label9.TabIndex = 27;
            label9.Text = "ĐIỆN:";
            // 
            // groupBox3
            // 
            groupBox3.Location = new Point(0, 137);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(797, 99);
            groupBox3.TabIndex = 22;
            groupBox3.TabStop = false;
            groupBox3.Text = "Thông Tin Điện Nước";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(txtNhanVienLap);
            groupBox1.Controls.Add(label15);
            groupBox1.Controls.Add(txtRoomPrice);
            groupBox1.Controls.Add(label14);
            groupBox1.Controls.Add(dtpMonth);
            groupBox1.Controls.Add(chkStatus);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(txtTenantName);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(cboContract);
            groupBox1.Controls.Add(txtRoomName);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(2, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(797, 191);
            groupBox1.TabIndex = 18;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông Tin Chung";
            // 
            // txtNhanVienLap
            // 
            txtNhanVienLap.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNhanVienLap.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNhanVienLap.Location = new Point(136, 137);
            txtNhanVienLap.Name = "txtNhanVienLap";
            txtNhanVienLap.ReadOnly = true;
            txtNhanVienLap.Size = new Size(359, 31);
            txtNhanVienLap.TabIndex = 27;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.Transparent;
            label15.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.Location = new Point(10, 140);
            label15.Name = "label15";
            label15.Size = new Size(124, 25);
            label15.TabIndex = 26;
            label15.Text = "Nhân viên lập:";
            // 
            // txtRoomPrice
            // 
            txtRoomPrice.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtRoomPrice.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRoomPrice.Location = new Point(611, 23);
            txtRoomPrice.Name = "txtRoomPrice";
            txtRoomPrice.Size = new Size(157, 31);
            txtRoomPrice.TabIndex = 25;
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.Location = new Point(507, 26);
            label14.Name = "label14";
            label14.Size = new Size(98, 25);
            label14.TabIndex = 24;
            label14.Text = "Giá Phòng:";
            // 
            // dtpMonth
            // 
            dtpMonth.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpMonth.CalendarFont = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpMonth.CustomFormat = "MM/yyyy";
            dtpMonth.Format = DateTimePickerFormat.Custom;
            dtpMonth.Location = new Point(609, 62);
            dtpMonth.Name = "dtpMonth";
            dtpMonth.ShowUpDown = true;
            dtpMonth.Size = new Size(135, 30);
            dtpMonth.TabIndex = 23;
            dtpMonth.Value = new DateTime(2026, 3, 31, 0, 0, 0, 0);
            // 
            // chkStatus
            // 
            chkStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            chkStatus.AutoSize = true;
            chkStatus.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chkStatus.Location = new Point(571, 99);
            chkStatus.Name = "chkStatus";
            chkStatus.Size = new Size(162, 29);
            chkStatus.TabIndex = 22;
            chkStatus.Text = "Đã Thanh Toán";
            chkStatus.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(524, 64);
            label11.Name = "label11";
            label11.Size = new Size(65, 25);
            label11.TabIndex = 21;
            label11.Text = "Tháng:";
            // 
            // txtTenantName
            // 
            txtTenantName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTenantName.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTenantName.Location = new Point(136, 100);
            txtTenantName.Name = "txtTenantName";
            txtTenantName.Size = new Size(359, 31);
            txtTenantName.TabIndex = 20;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(10, 29);
            label8.Name = "label8";
            label8.Size = new Size(101, 25);
            label8.TabIndex = 19;
            label8.Text = "Hợp Đồng:";
            // 
            // btnHuyBo
            // 
            btnHuyBo.Anchor = AnchorStyles.Top;
            btnHuyBo.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHuyBo.Location = new Point(407, 427);
            btnHuyBo.Name = "btnHuyBo";
            btnHuyBo.Size = new Size(90, 29);
            btnHuyBo.TabIndex = 21;
            btnHuyBo.Text = "Hủy bỏ";
            btnHuyBo.UseVisualStyleBackColor = true;
            btnHuyBo.Click += btnHuyBo_Click;
            // 
            // btnLuu
            // 
            btnLuu.Anchor = AnchorStyles.Top;
            btnLuu.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLuu.Location = new Point(307, 427);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(90, 29);
            btnLuu.TabIndex = 20;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // groupBox4
            // 
            groupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox4.Controls.Add(label13);
            groupBox4.Controls.Add(txtTotal);
            groupBox4.Controls.Add(label12);
            groupBox4.Controls.Add(txtNotes);
            groupBox4.Controls.Add(label4);
            groupBox4.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox4.Location = new Point(2, 305);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(797, 116);
            groupBox4.TabIndex = 22;
            groupBox4.TabStop = false;
            groupBox4.Text = "Thanh Toán và Ghi Chú";
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 8F);
            label13.Location = new Point(554, 87);
            label13.Name = "label13";
            label13.Size = new Size(97, 19);
            label13.TabIndex = 20;
            label13.Text = "Tự động tính...";
            // 
            // txtTotal
            // 
            txtTotal.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            txtTotal.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTotal.Location = new Point(456, 37);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(312, 47);
            txtTotal.TabIndex = 19;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top;
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(554, 9);
            label12.Name = "label12";
            label12.Size = new Size(91, 25);
            label12.TabIndex = 18;
            label12.Text = "Tổng tiền:";
            // 
            // txtNotes
            // 
            txtNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtNotes.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNotes.Location = new Point(26, 54);
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(410, 31);
            txtNotes.TabIndex = 17;
            // 
            // frmDetailed_Bill
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 472);
            Controls.Add(groupBox4);
            Controls.Add(btnHuyBo);
            Controls.Add(btnLuu);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "frmDetailed_Bill";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hóa Đơn Chi Tiết";
            WindowState = FormWindowState.Maximized;
            Load += frmDetailed_Bill_Load;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudWaterNew).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudWaterOld).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudElectricNew).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudElectricOld).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label6;
        private Label label7;
        private Label label5;
        private ComboBox cboContract;
        private TextBox txtRoomName;
        private Label label4;
        private Label label1;
        private Label label2;
        private Label label3;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private Button btnHuyBo;
        private Button btnLuu;
        private GroupBox groupBox3;
        private Label label8;
        private GroupBox groupBox4;
        private TextBox txtTenantName;
        private Label label10;
        private Label label9;
        private DateTimePicker dtpMonth;
        private CheckBox chkStatus;
        private Label label11;
        private NumericUpDown nudElectricOld;
        private NumericUpDown nudWaterNew;
        private NumericUpDown nudWaterOld;
        private NumericUpDown nudElectricNew;
        private TextBox txtTotal;
        private Label label12;
        private TextBox txtNotes;
        private Label label13;
        private Label lblElectricUsed;
        private Label lblWaterUsed;
        private TextBox txtRoomPrice;
        private Label label14;
        private TextBox txtNhanVienLap;
        private Label label15;
    }
}