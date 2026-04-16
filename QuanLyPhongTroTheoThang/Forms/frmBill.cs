using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using System.IO;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace QuanLyPhongTroTheoThang.Forms
{
    public partial class frmBill : Form
    {
        QLPTDbContext context = new QLPTDbContext();
        private string _filterRoomName = "";

        public frmBill(string filterRoomName = "")
        {
            InitializeComponent();
            _filterRoomName = filterRoomName;
        }

        private void frmBill_Load(object sender, EventArgs e)
        {
            LoadGridBill();
            SetupGridAppearance();

            if (!string.IsNullOrEmpty(_filterRoomName))
            {
                txtTimKiem.Text = _filterRoomName;
                btnTimKiem_Click(null, null); 
            }
        }

        private void LoadGridBill()
        {
            try
            {
                var billList = context.Bills
                    .Include(b => b.Contract).ThenInclude(c => c.Room)
                    .Include(b => b.Contract).ThenInclude(c => c.Tenant)
                    .Select(b => new
                    {
                        b.BillID,
                        Phong = b.Contract.Room.RoomName,
                        KhachHang = b.Contract.Tenant.TenantName,
                        Thang = b.Month.ToString("MM/yyyy"),
                        TongTien = b.Total,
                        TrangThai = b.Status ? "Đã thanh toán" : "Chưa thanh toán"
                    })
                    .OrderByDescending(x => x.BillID) // Hóa đơn mới nhất lên đầu
                    .ToList();

                dgvBill.DataSource = billList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách hóa đơn: " + ex.Message);
            }
        }
        private void SetupGridAppearance()
        {
            if (dgvBill.Columns.Count > 0)
            {
                dgvBill.Columns["BillID"].HeaderText = "Mã Hóa Đơn";
                dgvBill.Columns["BillID"].Width = 70;
                dgvBill.Columns["Phong"].HeaderText = "Phòng";
                dgvBill.Columns["KhachHang"].HeaderText = "Khách Thuê";
                dgvBill.Columns["Thang"].HeaderText = "Tháng/Năm";
                dgvBill.Columns["TongTien"].HeaderText = "Tổng Tiền (VNĐ)";
                dgvBill.Columns["TongTien"].DefaultCellStyle.Format = "N0";
                dgvBill.Columns["TrangThai"].HeaderText = "Trạng Thái";
                if (!dgvBill.Columns.Contains("btnChiTiet"))
                {
                    DataGridViewLinkColumn linkCol = new DataGridViewLinkColumn();
                    linkCol.Name = "btnChiTiet";           
                    linkCol.HeaderText = "Chi Tiết";
                    linkCol.Text = "Xem";                  
                    linkCol.UseColumnTextForLinkValue = true; 

                    linkCol.LinkBehavior = LinkBehavior.HoverUnderline; 
                    linkCol.LinkColor = Color.FromArgb(0, 102, 255);      
                    linkCol.ActiveLinkColor = Color.Red;                

                    linkCol.Width = 80;
                    dgvBill.Columns.Add(linkCol);

                    dgvBill.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                dgvBill.Columns["btnChiTiet"].DisplayIndex = dgvBill.Columns.Count - 1;
                dgvBill.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvBill.MultiSelect = false;
                dgvBill.ReadOnly = true;
            }
        }

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            frmDetailed_Bill f = new frmDetailed_Bill();
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadGridBill(); // Tải lại danh sách sau khi lưu thành công
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvBill.SelectedRows.Count > 0)
            {
                // Lấy ID hóa đơn từ dòng đang chọn
                int billId = (int)dgvBill.SelectedRows[0].Cells["BillID"].Value;

                // Mở form chi tiết ở chế độ sửa (truyền ID vào)
                frmDetailed_Bill f = new frmDetailed_Bill(billId);
                if (f.ShowDialog() == DialogResult.OK)
                {
                    LoadGridBill();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn trong danh sách để sửa!", "Thông báo");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvBill.SelectedRows.Count > 0)
            {
                int billId = (int)dgvBill.SelectedRows[0].Cells["BillID"].Value;
                string roomName = dgvBill.SelectedRows[0].Cells["Phong"].Value.ToString();

                var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa hóa đơn của phòng {roomName}?",
                                            "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    var billToDelete = context.Bills.Find(billId);
                    if (billToDelete != null)
                    {
                        context.Bills.Remove(billToDelete);
                        context.SaveChanges();
                        LoadGridBill();
                    }
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Xuất danh sách hóa đơn ra Excel";
            saveFileDialog.Filter = "Tập tin Excel *.xlsx|*.xlsx";
            saveFileDialog.FileName = "BaoCaoHoaDon_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();
                    // Định nghĩa các cột cho bảng Excel
                    table.Columns.Add("Mã HĐ", typeof(int));
                    table.Columns.Add("Phòng", typeof(string));
                    table.Columns.Add("Khách Thuê", typeof(string));
                    table.Columns.Add("Tháng/Năm", typeof(string));
                    table.Columns.Add("Tổng Tiền (VNĐ)", typeof(decimal));
                    table.Columns.Add("Trạng Thái", typeof(string));

                    // Lấy dữ liệu kèm thông tin liên quan
                    var bills = context.Bills
                        .Include(b => b.Contract).ThenInclude(c => c.Room)
                        .Include(b => b.Contract).ThenInclude(c => c.Tenant)
                        .ToList();

                    foreach (var b in bills)
                    {
                        table.Rows.Add(
                            b.BillID,
                            b.Contract?.Room?.RoomName,
                            b.Contract?.Tenant?.TenantName,
                            b.Month.ToString("MM/yyyy"),
                            b.Total,
                            b.Status ? "Đã thanh toán" : "Chưa thanh toán"
                        );
                    }

                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(table, "HoaDon");
                        // Định dạng tiền tệ cho cột Tổng Tiền trong Excel
                        sheet.Column(5).Style.NumberFormat.Format = "#,##0";
                        sheet.Columns().AdjustToContents();

                        wb.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Xuất báo cáo hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnInHD_Click(object sender, EventArgs e)
        {
            if (dgvBill.CurrentRow != null)
            {
                int billId = Convert.ToInt32(dgvBill.CurrentRow.Cells["BillID"].Value);

                frmPrintPreview frm = new frmPrintPreview();

                
                frm.LoadHoaDon(billId);

                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn trong danh sách để in!");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(keyword))
            {
                LoadGridBill();
                return;
            }

            try
            {
                var filteredBills = context.Bills
                    .Include(b => b.Contract).ThenInclude(c => c.Room)
                    .Include(b => b.Contract).ThenInclude(c => c.Tenant)
                    .Where(b =>
                        b.BillID.ToString().Contains(keyword) ||
                        (b.Contract != null && b.Contract.Room != null && b.Contract.Room.RoomName.ToLower().Contains(keyword)) ||
                        (b.Contract != null && b.Contract.Tenant != null && b.Contract.Tenant.TenantName.ToLower().Contains(keyword))
                    )
                    .Select(b => new
                    {
                        b.BillID,
                        Phong = b.Contract.Room.RoomName,
                        KhachHang = b.Contract.Tenant.TenantName,
                        Thang = b.Month.ToString("MM/yyyy"),
                        TongTien = b.Total,
                        TrangThai = b.Status ? "Đã thanh toán" : "Chưa thanh toán"
                    })
                    .OrderByDescending(x => x.BillID)
                    .ToList();

                dgvBill.DataSource = null;
                dgvBill.DataSource = filteredBills;

                SetupGridAppearance();

                if (filteredBills.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn nào phù hợp với từ khóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvBill.Columns[e.ColumnIndex].Name == "btnChiTiet")
            {
                int billId = (int)dgvBill.Rows[e.RowIndex].Cells["BillID"].Value;

                frmDetailed_Bill f = new frmDetailed_Bill(billId, true);
                f.ShowDialog();
            }
        }
    }
}
