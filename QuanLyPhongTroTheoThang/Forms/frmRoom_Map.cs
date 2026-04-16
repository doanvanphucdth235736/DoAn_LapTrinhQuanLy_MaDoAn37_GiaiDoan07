using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Drawing.Charts;

namespace QuanLyPhongTroTheoThang.Forms
{
    public partial class frmRoom_Map : Form
    {
        QLPTDbContext context = new QLPTDbContext();
        public frmRoom_Map()
        {
            InitializeComponent();
            this.Load += frmRoom_Map_Load;
            this.panelRooms.SizeChanged += PanelRooms_SizeChanged;
        }

        private void frmRoom_Map_Load(object sender, EventArgs e)
        {
            LoadRoomMap();
        }

        private void LoadRoomMap()
        {
            panelRooms.Controls.Clear();
            var rooms = context.Rooms.ToList();

            int totalColumns = 5;
            int spacing = 15; // Bạn có thể tăng giảm tùy ý (ví dụ 10 hoặc 15)

            int panelWidth = panelRooms.ClientSize.Width;
            int cardWidth = (panelWidth - (spacing * (totalColumns + 1))) / totalColumns;
            int cardHeight = 200; // Cho cao lên 200

            int x = spacing, y = spacing;
            int col = 0;

            foreach (var r in rooms)
            {
                Panel p = CreateRoomPanel(r.RoomID, r.RoomName, r.Price, r.Status, cardWidth, cardHeight);

                p.Location = new Point(x, y);

                panelRooms.Controls.Add(p);

                col++;
                if (col >= totalColumns)
                {
                    col = 0;
                    x = spacing;
                    y += cardHeight + spacing;
                }
                else
                {
                    x += cardWidth + spacing;
                }
            }
        }

        private Panel CreateRoomPanel(int id, string name, decimal price, string status, int width, int height)
        {
            Panel p = new Panel();
            p.Width = width;
            p.Height = height;
            p.BorderStyle = BorderStyle.None;
            p.Cursor = Cursors.Hand;

            if (status == "Trống")
                p.BackColor = Color.FromArgb(212, 237, 218);
            else if (status == "Đã đặt trước")
                p.BackColor = Color.FromArgb(255, 243, 205);
            else
                p.BackColor = Color.FromArgb(248, 215, 218);

            Label lblName = new Label();
            lblName.Text = "🏠 " + name;
            lblName.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblName.Location = new Point(15, 15);
            lblName.AutoSize = true;

            Label lblPrice = new Label();
            lblPrice.Text = "💰 " + price.ToString("N0");
            lblPrice.Font = new Font("Segoe UI", 10);
            lblPrice.Location = new Point(15, 60);
            lblPrice.AutoSize = true;

            Label lblStatus = new Label();
            lblStatus.Text = status;
            lblStatus.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblStatus.Location = new Point(15, 100);
            lblStatus.AutoSize = true;

            p.Controls.Add(lblName);
            p.Controls.Add(lblPrice);
            p.Controls.Add(lblStatus);

            p.Tag = id;

            SetRoundedRegion(p, 20);

            Color originalColor = p.BackColor;

            p.MouseEnter += (s, e) => { p.BackColor = ControlPaint.Light(originalColor); };
            p.MouseLeave += (s, e) => { p.BackColor = originalColor; };

            p.Click += Room_Click;
            lblName.Click += Room_Click;
            lblPrice.Click += Room_Click;
            lblStatus.Click += Room_Click;

            ToolTip tt = new ToolTip();
            tt.SetToolTip(p, $"Phòng: {name}\nGiá: {price:N0}\nTrạng thái: {status}");

            return p;
        }

        private void SetRoundedRegion(Control control, int radius)
        {
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, control.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();

            control.Region = new Region(path);
        }

        private void Room_Click(object sender, EventArgs e)
        {
            Control ctrl = sender as Control;
            Panel p = ctrl as Panel ?? ctrl.Parent as Panel;

            int roomId = Convert.ToInt32(p.Tag);
            var room = context.Rooms.Find(roomId);

            ContextMenuStrip menu = new ContextMenuStrip();

            if (room.Status == "Trống")
            {
                menu.Items.Add("Đăng ký hợp đồng", null, (s, ev) =>
                {
                    frmDetailed_Contract f = new frmDetailed_Contract(0, false);
                    f.Tag = roomId;
                    f.ShowDialog();
                    LoadRoomMap();
                });

                // CHỨC NĂNG MỚI: ĐẶT TRƯỚC
                menu.Items.Add("Đặt trước phòng", null, (s, ev) =>
                {
                    room.Status = "Đã đặt trước";
                    context.SaveChanges();
                    LoadRoomMap(); // Load lại để đổi màu sang vàng
                });
            }
            else if (room.Status == "Đã đặt trước") // Đổi "Đã cọc" thành "Đã đặt trước"
            {
                menu.Items.Add("Xem hợp đồng", null, (s, ev) =>
                {
                    var activeContract = context.Contracts
                        .Where(c => c.RoomID == roomId && c.ContractStatus != "Đã thanh lý" && c.ContractStatus != "Đã hủy")
                        .OrderByDescending(c => c.ContractID)
                        .FirstOrDefault();

                    if (activeContract != null)
                    {
                        frmDetailed_Contract f = new frmDetailed_Contract(activeContract.ContractID, true);
                        f.ShowDialog();
                        LoadRoomMap();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy hợp đồng đang hiệu lực!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                });

                // Tùy chọn: Hủy đặt trước nếu khách đổi ý
                menu.Items.Add("Hủy đặt trước", null, (s, ev) =>
                {
                    room.Status = "Trống";
                    context.SaveChanges();
                    LoadRoomMap();
                });
            }
            else // Trường hợp phòng "Đã thuê"
            {
                menu.Items.Add("Xem hợp đồng", null, (s, ev) =>
                {
                    var activeContract = context.Contracts
                        .Where(c => c.RoomID == roomId && c.ContractStatus != "Đã thanh lý" && c.ContractStatus != "Đã hủy")
                        .OrderByDescending(c => c.ContractID)
                        .FirstOrDefault();

                    if (activeContract != null)
                    {
                        frmDetailed_Contract f = new frmDetailed_Contract(activeContract.ContractID, true);
                        f.ShowDialog();
                        LoadRoomMap();
                    }
                });

                // CHỨC NĂNG MỚI: LẬP HÓA ĐƠN
                menu.Items.Add("Lập hóa đơn", null, (s, ev) =>
                {
                    frmDetailed_Bill f = new frmDetailed_Bill();
                    f.Tag = roomId; // Mượn Tag để truyền mã phòng sang form Bill
                    f.ShowDialog();
                });

                // CHỨC NĂNG MỚI: XEM HÓA ĐƠN (Truyền tên phòng vào)
                menu.Items.Add("Xem danh sách hóa đơn", null, (s, ev) =>
                {
                    // Chuyền tên phòng vào form frmBill
                    frmBill f = new frmBill(room.RoomName);
                    f.ShowDialog();
                });
            }

            menu.Show(Cursor.Position);
        }
        

        private void PanelRooms_SizeChanged(object sender, EventArgs e)
        {
            // Kiểm tra tránh lỗi khi form đang thu nhỏ (Minimize)
            if (panelRooms.ClientSize.Width > 0)
            {
                LoadRoomMap();
            }
        }
    }
    
}
