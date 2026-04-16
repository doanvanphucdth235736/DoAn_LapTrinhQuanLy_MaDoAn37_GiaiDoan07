using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.Data.Entity;
using DocumentFormat.OpenXml.Drawing;
using QuanLyPhongTroTheoThang.Data;

namespace QuanLyPhongTroTheoThang.Forms
{
    public partial class frmRoom : Form
    {
        QLPTDbContext context = new QLPTDbContext();
        bool isAddMode = false;
        int selectedRoomId;
        string selectedImagePath = "";

        bool isPopulating = false;
        bool isEditing = false;
        public frmRoom()
        {
            InitializeComponent();
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            isAddMode = true;

            txtRoomName.Clear();
            txtPrice.Clear();
            cmbStatus.SelectedIndex = -1;

            selectedImagePath = "";
            picRoomImage.Image = null;

            selectedRoomId = 0;

            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtRoomName.Text == "" || txtPrice.Text == "" || cmbStatus.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Giá phòng phải là số!");
                return;
            }

            if (price <= 0)
            {
                MessageBox.Show("Giá phòng phải > 0!");
                return;
            }

            if (isAddMode)
            {
                Room room = new Room()
                {
                    RoomName = txtRoomName.Text,
                    Price = price,
                    Status = cmbStatus.Text,
                    ImagePath = selectedImagePath
                };

                context.Rooms.Add(room);
                MessageBox.Show("Thêm thành công!");
            }
            else
            {
                Room room = context.Rooms.Find(selectedRoomId);

                if (room != null)
                {
                    room.RoomName = txtRoomName.Text;
                    room.Price = price;
                    room.Status = cmbStatus.Text;
                    room.ImagePath = selectedImagePath;

                    MessageBox.Show("Cập nhật thành công!");
                }
            }

            context.SaveChanges();
            LoadGrid();
            isEditing = false;
        }

        private void frmRoom_Load(object sender, EventArgs e)
        {
            dgvRoom.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvRoom.AutoGenerateColumns = false;

            dgvRoom.EnableHeadersVisualStyles = false;

            dgvRoom.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control;

            dgvRoom.ColumnHeadersDefaultCellStyle.SelectionBackColor = SystemColors.Control;

            dgvRoom.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvRoom.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;

            dgvRoom.Columns.Clear();

            dgvRoom.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "RoomID",
                HeaderText = "Mã phòng",
                DataPropertyName = "RoomID",
                Visible = true
            });

            dgvRoom.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "RoomName",
                HeaderText = "Tên phòng",
                DataPropertyName = "RoomName"
            });

            dgvRoom.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Price",
                HeaderText = "Giá phòng",
                DataPropertyName = "Price",
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "N0"
                }
            });

            dgvRoom.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Status",
                HeaderText = "Trạng thái",
                DataPropertyName = "Status"
            });

            dgvRoom.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "ImagePath",
                DataPropertyName = "ImagePath",
                Visible = false 
            });

            DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            imgCol.Name = "RoomImage";
            imgCol.HeaderText = "Ảnh";
            imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom; 
            dgvRoom.Columns.Add(imgCol);
            // UI khác
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;

            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Trống");
            cmbStatus.Items.Add("Đã thuê");
            cmbStatus.Items.Add("Đã đặt trước");

            dgvRoom.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRoom.ClearSelection();

            dgvRoom.CellFormatting += dgvRoom_CellFormatting;

            LoadGrid(); // gọi sau khi đã tạo cột
        }

        private void LoadGrid()
        {
            dgvRoom.DataSource = context.Rooms
                .Select(r => new
                {
                    r.RoomID,
                    r.RoomName,
                    r.Price,
                    r.Status,
                    r.ImagePath
                })
                .ToList();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedRoomId == 0)
            {
                MessageBox.Show("Vui lòng chọn phòng!");
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc muốn xóa không?",
                                         "Xác nhận",
                                         MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                Room room = context.Rooms.Find(selectedRoomId);

                if (room != null)
                {
                    context.Rooms.Remove(room);
                    context.SaveChanges();

                    LoadGrid();

                    btnHuyBo_Click(null, null);
                }
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            txtRoomName.Clear();
            txtPrice.Clear();
            cmbStatus.SelectedIndex = -1;

            selectedRoomId = 0;
            isEditing = false;

            selectedImagePath = "";
            picRoomImage.Image = null;

            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;

            isEditing = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvRoom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                isPopulating = true;

                var row = dgvRoom.Rows[e.RowIndex];

                selectedRoomId = Convert.ToInt32(row.Cells["RoomID"].Value);

                txtRoomName.Text = row.Cells["RoomName"].Value?.ToString() ?? "";
                txtPrice.Text = row.Cells["Price"].Value?.ToString() ?? "";
                cmbStatus.Text = row.Cells["Status"].Value?.ToString() ?? "";
                selectedImagePath = row.Cells["ImagePath"].Value?.ToString() ?? "";

                if (!string.IsNullOrEmpty(selectedImagePath) && System.IO.File.Exists(selectedImagePath))
                {
                    using (var stream = new System.IO.FileStream(selectedImagePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                    {
                        picRoomImage.Image = Image.FromStream(stream);
                    }
                }
                else
                {
                    picRoomImage.Image = null; 
                }

                isPopulating = false;

                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnLuu.Enabled = false;
                isAddMode = false;
            }
        }

        private void SearchRoom()
        {
            var query = context.Rooms.AsQueryable();

            if (!string.IsNullOrWhiteSpace(txtRoomName.Text))
            {
                query = query.Where(r => r.RoomName.Contains(txtRoomName.Text));
            }

            if (decimal.TryParse(txtPrice.Text, out decimal price))
            {
                query = query.Where(r => r.Price == price);
            }

            if (!string.IsNullOrWhiteSpace(cmbStatus.Text))
            {
                query = query.Where(r => r.Status == cmbStatus.Text);
            }

            dgvRoom.DataSource = query
                .Select(r => new
                {
                    r.RoomID,
                    r.RoomName,
                    r.Price,
                    r.Status
                })
                .ToList();
            dgvRoom.Refresh();
        }

        private void NtnNhap_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn tập tin Excel để nhập dữ liệu";
            openFileDialog.Filter = "Tập tin Excel *.xlsx|*.xlsx|Tất cả các tệp *.*|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();
                    using (XLWorkbook workbook = new XLWorkbook(openFileDialog.FileName))
                    {
                        IXLWorksheet worksheet = workbook.Worksheet(1);
                        bool firstRow = true;
                        string readRange = "1:1";

                        foreach (IXLRow row in worksheet.RowsUsed())
                        {
                            if (firstRow) // Đọc tiêu đề cột
                            {
                                readRange = string.Format("{0}:{1}", 1, row.LastCellUsed().Address.ColumnNumber);
                                foreach (IXLCell cell in row.Cells(readRange))
                                {
                                    table.Columns.Add(cell.Value.ToString());
                                }
                                firstRow = false;
                            }
                            else // Đọc nội dung từng dòng
                            {
                                table.Rows.Add();
                                int cellIndex = 0;
                                foreach (IXLCell cell in row.Cells(readRange))
                                {
                                    table.Rows[table.Rows.Count - 1][cellIndex] = cell.Value.ToString();
                                    cellIndex++;
                                }
                            }
                        }
                    }

                    // Sau khi đọc xong vào DataTable, lưu vào Database
                    // Thay thế đoạn lưu dữ liệu cũ bằng đoạn này:
                    if (table.Rows.Count > 0)
                    {
                        try
                        {
                            foreach (DataRow r in table.Rows)
                            {
                                // Kiểm tra dữ liệu rỗng trước khi xử lý
                                if (string.IsNullOrEmpty(r["Tên phòng"]?.ToString())) continue;

                                Room newRoom = new Room();
                                newRoom.RoomName = r["Tên phòng"].ToString();

                                // Xử lý giá phòng (loại bỏ các ký tự không phải số nếu cần)
                                string priceStr = r["Giá phòng"].ToString().Replace(".", "").Replace(",", "");
                                if (decimal.TryParse(priceStr, out decimal price))
                                    newRoom.Price = price;
                                else
                                    newRoom.Price = 0;

                                newRoom.Status = r["Trạng thái"]?.ToString() ?? "Trống";
                                newRoom.ImagePath = ""; // Gán giá trị mặc định để tránh lỗi NULL nếu DB yêu cầu

                                context.Rooms.Add(newRoom);
                            }
                            context.SaveChanges(); //
                            MessageBox.Show("Nhập thành công!");
                            LoadGrid();
                        }
                        catch (System.Data.Entity.Validation.DbEntityValidationException ex) 
                        {
                            foreach (var eve in ex.EntityValidationErrors)
                            {
                                MessageBox.Show($"Thực thể {eve.Entry.Entity.GetType().Name} bị lỗi validation.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string error = ex.Message;
                    if (ex.InnerException != null)
                        error += "\nChi tiết: " + ex.InnerException.InnerException?.Message;

                    MessageBox.Show("Lỗi lưu Database: " + error, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); //
                }
             
            }
        }


        private void btnXuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog(); // [cite: 206]
            saveFileDialog.Title = "Xuất danh sách phòng ra Excel";
            saveFileDialog.Filter = "Tập tin Excel *.xlsx|*.xlsx"; // [cite: 207]
            saveFileDialog.FileName = "DanhSachPhong_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK) // [cite: 209]
            {
                try
                {
                    DataTable table = new DataTable(); // [cite: 213]
                    table.Columns.Add("Mã phòng", typeof(int));
                    table.Columns.Add("Tên phòng", typeof(string));
                    table.Columns.Add("Giá phòng", typeof(decimal));
                    table.Columns.Add("Trạng thái", typeof(string));

                    var rooms = context.Rooms.ToList();

                    foreach (var r in rooms) // [cite: 223]
                    {
                        table.Rows.Add(r.RoomID, r.RoomName, r.Price, r.Status); // [cite: 224]
                    }

                    using (XLWorkbook wb = new XLWorkbook()) // [cite: 225]
                    {
                        var sheet = wb.Worksheets.Add(table, "DanhSachPhong"); // [cite: 227]
                        sheet.Columns().AdjustToContents(); // Tự căn chỉnh độ rộng cột [cite: 228]
                        wb.SaveAs(saveFileDialog.FileName); // [cite: 229]

                        MessageBox.Show("Xuất dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); // [cite: 230]
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); // [cite: 235]
                }
            }
        }

        private void txtRoomName_TextChanged(object sender, EventArgs e)
        {
            if (isPopulating || isEditing) return;
            SearchRoom();
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            if (isPopulating || isEditing) return;
            SearchRoom();
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isPopulating || isEditing) return;
            SearchRoom();
        }

        private void dgvRoom_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvRoom.Columns[e.ColumnIndex].Name == "Status" && e.Value != null)
            {
                string status = e.Value.ToString();

                if (status == "Đã thuê")
                    e.CellStyle.ForeColor = Color.Red;
                else if (status == "Đã đặt trước")
                    e.CellStyle.ForeColor = Color.Orange;
                else
                    e.CellStyle.ForeColor = Color.Green;
            }
            if (dgvRoom.Columns[e.ColumnIndex].Name == "RoomImage" && e.RowIndex >= 0)
            {
                var imagePathValue = dgvRoom.Rows[e.RowIndex].Cells["ImagePath"].Value;

                if (imagePathValue != null)
                {
                    string imagePath = imagePathValue.ToString();

                    if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
                    {
                        try
                        {
                            using (var stream = new System.IO.FileStream(imagePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                            {
                                e.Value = Image.FromStream(stream);
                            }
                        }
                        catch
                        {
                            e.Value = null;
                        }
                    }
                }
            }
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {

            if (selectedRoomId == 0)
            {
                MessageBox.Show("Vui lòng chọn phòng!");
                return;
            }

            isAddMode = false;
            isEditing = true;

            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";

            if (open.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = open.FileName;
                using (var stream = new System.IO.FileStream(selectedImagePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    picRoomImage.Image = Image.FromStream(stream);
                }
            }
        }
    }
}
