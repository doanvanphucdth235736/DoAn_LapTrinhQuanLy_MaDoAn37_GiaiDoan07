namespace QuanLyPhongTroTheoThang.Forms
{
    partial class frmRoom_Map
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
            panelRooms = new Panel();
            SuspendLayout();
            // 
            // panelRooms
            // 
            panelRooms.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelRooms.AutoScroll = true;
            panelRooms.Location = new Point(0, 0);
            panelRooms.Name = "panelRooms";
            panelRooms.Size = new Size(800, 450);
            panelRooms.TabIndex = 0;
            // 
            // frmRoom_Map
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(800, 450);
            Controls.Add(panelRooms);
            Name = "frmRoom_Map";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sơ Đồ Phòng Trọ";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
        }

        #endregion

        private Panel panelRooms;
    }
}