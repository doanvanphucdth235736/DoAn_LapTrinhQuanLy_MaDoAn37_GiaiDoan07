namespace QuanLyPhongTroTheoThang.Forms
{
    partial class frmDetailed_Contract
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
            groupBox1 = new GroupBox();
            txtNhanVienLap = new TextBox();
            label15 = new Label();
            txtNotes = new TextBox();
            label12 = new Label();
            nudNumberOfOccupants = new NumericUpDown();
            nudPaymentDay = new NumericUpDown();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            cmbContractStatus = new ComboBox();
            groupBox3 = new GroupBox();
            txtElectricStart = new TextBox();
            txtWaterStart = new TextBox();
            label7 = new Label();
            label8 = new Label();
            groupBox2 = new GroupBox();
            label6 = new Label();
            dtpEndDate = new DateTimePicker();
            label5 = new Label();
            dtpStartDate = new DateTimePicker();
            txtDeposit = new TextBox();
            txtPrice = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            cmbRoom = new ComboBox();
            cmbTenant = new ComboBox();
            btnHuyBo = new Button();
            btnLuu = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudNumberOfOccupants).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPaymentDay).BeginInit();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(txtNhanVienLap);
            groupBox1.Controls.Add(label15);
            groupBox1.Controls.Add(txtNotes);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(nudNumberOfOccupants);
            groupBox1.Controls.Add(nudPaymentDay);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(cmbContractStatus);
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(txtDeposit);
            groupBox1.Controls.Add(txtPrice);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(cmbRoom);
            groupBox1.Controls.Add(cmbTenant);
            groupBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(2, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(797, 343);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông Tin Hợp Đồng";
            // 
            // txtNhanVienLap
            // 
            txtNhanVienLap.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNhanVienLap.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNhanVienLap.Location = new Point(152, 261);
            txtNhanVienLap.Name = "txtNhanVienLap";
            txtNhanVienLap.ReadOnly = true;
            txtNhanVienLap.Size = new Size(277, 31);
            txtNhanVienLap.TabIndex = 38;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.Transparent;
            label15.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.Location = new Point(26, 264);
            label15.Name = "label15";
            label15.Size = new Size(124, 25);
            label15.TabIndex = 37;
            label15.Text = "Nhân viên lập:";
            // 
            // txtNotes
            // 
            txtNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtNotes.Location = new Point(107, 301);
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(679, 30);
            txtNotes.TabIndex = 36;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(23, 302);
            label12.Name = "label12";
            label12.Size = new Size(78, 25);
            label12.TabIndex = 35;
            label12.Text = "Ghi Chú:";
            // 
            // nudNumberOfOccupants
            // 
            nudNumberOfOccupants.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nudNumberOfOccupants.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudNumberOfOccupants.Location = new Point(636, 259);
            nudNumberOfOccupants.Name = "nudNumberOfOccupants";
            nudNumberOfOccupants.Size = new Size(150, 31);
            nudNumberOfOccupants.TabIndex = 34;
            // 
            // nudPaymentDay
            // 
            nudPaymentDay.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nudPaymentDay.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudPaymentDay.Location = new Point(636, 219);
            nudPaymentDay.Name = "nudPaymentDay";
            nudPaymentDay.Size = new Size(150, 31);
            nudPaymentDay.TabIndex = 33;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(444, 261);
            label11.Name = "label11";
            label11.Size = new Size(105, 25);
            label11.TabIndex = 32;
            label11.Text = "Số người ở:";
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(444, 221);
            label10.Name = "label10";
            label10.Size = new Size(187, 25);
            label10.TabIndex = 31;
            label10.Text = "Ngày đóng tiền(1-31):";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(23, 221);
            label9.Name = "label9";
            label9.Size = new Size(96, 25);
            label9.TabIndex = 30;
            label9.Text = "Trạng Thái:";
            // 
            // cmbContractStatus
            // 
            cmbContractStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbContractStatus.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbContractStatus.FormattingEnabled = true;
            cmbContractStatus.Location = new Point(135, 218);
            cmbContractStatus.Name = "cmbContractStatus";
            cmbContractStatus.Size = new Size(294, 33);
            cmbContractStatus.TabIndex = 29;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox3.Controls.Add(txtElectricStart);
            groupBox3.Controls.Add(txtWaterStart);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(label8);
            groupBox3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox3.Location = new Point(479, 104);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(307, 108);
            groupBox3.TabIndex = 28;
            groupBox3.TabStop = false;
            groupBox3.Text = "Chỉ Số Ban Đầu";
            // 
            // txtElectricStart
            // 
            txtElectricStart.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtElectricStart.Location = new Point(142, 63);
            txtElectricStart.Name = "txtElectricStart";
            txtElectricStart.Size = new Size(125, 27);
            txtElectricStart.TabIndex = 26;
            // 
            // txtWaterStart
            // 
            txtWaterStart.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtWaterStart.Location = new Point(142, 26);
            txtWaterStart.Name = "txtWaterStart";
            txtWaterStart.Size = new Size(125, 27);
            txtWaterStart.TabIndex = 25;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(53, 66);
            label7.Name = "label7";
            label7.Size = new Size(64, 20);
            label7.TabIndex = 24;
            label7.Text = "Số Điện:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(53, 33);
            label8.Name = "label8";
            label8.Size = new Size(69, 20);
            label8.TabIndex = 22;
            label8.Text = "Số Nước:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(dtpEndDate);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(dtpStartDate);
            groupBox2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(10, 104);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(463, 108);
            groupBox2.TabIndex = 27;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thời Hạn Hợp Đồng";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(76, 68);
            label6.Name = "label6";
            label6.Size = new Size(75, 20);
            label6.TabIndex = 24;
            label6.Text = "Đến ngày:";
            // 
            // dtpEndDate
            // 
            dtpEndDate.CalendarFont = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpEndDate.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpEndDate.Location = new Point(171, 61);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(220, 27);
            dtpEndDate.TabIndex = 23;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(76, 35);
            label5.Name = "label5";
            label5.Size = new Size(65, 20);
            label5.TabIndex = 22;
            label5.Text = "Từ ngày:";
            // 
            // dtpStartDate
            // 
            dtpStartDate.CalendarFont = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpStartDate.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpStartDate.Location = new Point(171, 28);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(220, 27);
            dtpStartDate.TabIndex = 20;
            // 
            // txtDeposit
            // 
            txtDeposit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtDeposit.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDeposit.Location = new Point(606, 65);
            txtDeposit.Name = "txtDeposit";
            txtDeposit.Size = new Size(180, 31);
            txtDeposit.TabIndex = 26;
            // 
            // txtPrice
            // 
            txtPrice.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtPrice.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPrice.Location = new Point(606, 26);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(180, 31);
            txtPrice.TabIndex = 25;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(444, 68);
            label3.Name = "label3";
            label3.Size = new Size(135, 25);
            label3.TabIndex = 24;
            label3.Text = "Tiền Cọc (VND):";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(444, 29);
            label4.Name = "label4";
            label4.Size = new Size(150, 25);
            label4.TabIndex = 23;
            label4.Text = "Giá Phòng (VND):";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(23, 68);
            label2.Name = "label2";
            label2.Size = new Size(68, 25);
            label2.TabIndex = 22;
            label2.Text = "Phòng:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(23, 29);
            label1.Name = "label1";
            label1.Size = new Size(106, 25);
            label1.TabIndex = 21;
            label1.Text = "Khách Thuê:";
            // 
            // cmbRoom
            // 
            cmbRoom.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbRoom.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbRoom.FormattingEnabled = true;
            cmbRoom.Location = new Point(135, 65);
            cmbRoom.Name = "cmbRoom";
            cmbRoom.Size = new Size(294, 33);
            cmbRoom.TabIndex = 19;
            cmbRoom.SelectedIndexChanged += cmbRoom_SelectedIndexChanged;
            // 
            // cmbTenant
            // 
            cmbTenant.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbTenant.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbTenant.FormattingEnabled = true;
            cmbTenant.Location = new Point(135, 26);
            cmbTenant.Name = "cmbTenant";
            cmbTenant.Size = new Size(294, 33);
            cmbTenant.TabIndex = 18;
            cmbTenant.SelectedIndexChanged += cmbTenant_SelectedIndexChanged;
            // 
            // btnHuyBo
            // 
            btnHuyBo.Anchor = AnchorStyles.Top;
            btnHuyBo.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHuyBo.Location = new Point(404, 351);
            btnHuyBo.Name = "btnHuyBo";
            btnHuyBo.Size = new Size(90, 29);
            btnHuyBo.TabIndex = 19;
            btnHuyBo.Text = "Hủy bỏ";
            btnHuyBo.UseVisualStyleBackColor = true;
            btnHuyBo.Click += btnHuyBo_Click;
            // 
            // btnLuu
            // 
            btnLuu.Anchor = AnchorStyles.Top;
            btnLuu.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLuu.Location = new Point(304, 351);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(90, 29);
            btnLuu.TabIndex = 18;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // frmDetailed_Contract
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 388);
            Controls.Add(btnHuyBo);
            Controls.Add(btnLuu);
            Controls.Add(groupBox1);
            Name = "frmDetailed_Contract";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hợp Đồng Chi Tiết";
            WindowState = FormWindowState.Maximized;
            Load += frmDetailed_Contract_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudNumberOfOccupants).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPaymentDay).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox1;
        private DateTimePicker dtpStartDate;
        private ComboBox cmbRoom;
        private ComboBox cmbTenant;
        private TextBox txtDeposit;
        private Label label1;
        private TextBox textBox2;
        private TextBox txtPrice;
        private Label label3;
        private Label label4;
        private Label label2;
        private GroupBox groupBox2;
        private Label label5;
        private Label label6;
        private DateTimePicker dtpEndDate;
        private GroupBox groupBox3;
        private TextBox txtElectricStart;
        private TextBox txtWaterStart;
        private Label label7;
        private Label label8;
        private NumericUpDown nudNumberOfOccupants;
        private NumericUpDown nudPaymentDay;
        private Label label11;
        private Label label10;
        private Label label9;
        private ComboBox cmbContractStatus;
        private TextBox txtNotes;
        private Label label12;
        private Button btnHuyBo;
        private Button btnLuu;
        private TextBox txtNhanVienLap;
        private Label label15;
    }
}