namespace QuanLyPhongTroTheoThang.Forms
{
    partial class frmChangePassword
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtMatKhauCu = new TextBox();
            txtMatKhauMoi = new TextBox();
            txtXacNhan = new TextBox();
            btnHuy = new Button();
            btnXacNhan = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(16, 15);
            label1.Name = "label1";
            label1.Size = new Size(113, 25);
            label1.TabIndex = 6;
            label1.Text = "Mật khẩu củ:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(16, 52);
            label2.Name = "label2";
            label2.Size = new Size(126, 25);
            label2.TabIndex = 7;
            label2.Text = "Mật khẩu mới:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(16, 92);
            label3.Name = "label3";
            label3.Size = new Size(225, 25);
            label3.TabIndex = 8;
            label3.Text = "Xác nhận lại mật khẩu mới:";
            // 
            // txtMatKhauCu
            // 
            txtMatKhauCu.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMatKhauCu.Location = new Point(247, 12);
            txtMatKhauCu.Name = "txtMatKhauCu";
            txtMatKhauCu.Size = new Size(512, 31);
            txtMatKhauCu.TabIndex = 9;
            // 
            // txtMatKhauMoi
            // 
            txtMatKhauMoi.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMatKhauMoi.Location = new Point(247, 49);
            txtMatKhauMoi.Name = "txtMatKhauMoi";
            txtMatKhauMoi.Size = new Size(512, 31);
            txtMatKhauMoi.TabIndex = 10;
            // 
            // txtXacNhan
            // 
            txtXacNhan.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtXacNhan.Location = new Point(247, 89);
            txtXacNhan.Name = "txtXacNhan";
            txtXacNhan.Size = new Size(512, 31);
            txtXacNhan.TabIndex = 11;
            // 
            // btnHuy
            // 
            btnHuy.Anchor = AnchorStyles.Top;
            btnHuy.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHuy.Location = new Point(502, 142);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(129, 35);
            btnHuy.TabIndex = 15;
            btnHuy.Text = "Hủy bỏ";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += btnHuy_Click;
            // 
            // btnXacNhan
            // 
            btnXacNhan.Anchor = AnchorStyles.Top;
            btnXacNhan.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXacNhan.Location = new Point(342, 142);
            btnXacNhan.Name = "btnXacNhan";
            btnXacNhan.Size = new Size(129, 35);
            btnXacNhan.TabIndex = 14;
            btnXacNhan.Text = "Xác nhận";
            btnXacNhan.UseVisualStyleBackColor = true;
            btnXacNhan.Click += btnXacNhan_Click;
            // 
            // frmChangePassword
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(792, 207);
            Controls.Add(btnHuy);
            Controls.Add(btnXacNhan);
            Controls.Add(txtXacNhan);
            Controls.Add(txtMatKhauMoi);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(txtMatKhauCu);
            Name = "frmChangePassword";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thay Đổi Mật Khẩu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtMatKhauCu;
        private TextBox txtMatKhauMoi;
        private TextBox txtXacNhan;
        private Button btnHuy;
        private Button btnXacNhan;
    }
}