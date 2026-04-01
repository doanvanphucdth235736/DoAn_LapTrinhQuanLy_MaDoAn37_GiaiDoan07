using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
using QuanLyPhongTroTheoThang.Data;

namespace QuanLyPhongTroTheoThang.Forms
{
    public partial class frmContract : Form
    {
        QLPTDbContext context = new QLPTDbContext();
        int selectedContractId = 0;

        public frmContract()
        {
            InitializeComponent();
        }

        private void frmContract_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadGrid();
        }

        private void SetupDataGridView()
        {
            dgvContract.AutoGenerateColumns = false;
            dgvContract.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvContract.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvContract.AllowUserToAddRows = false;
            dgvContract.Columns.Clear();

            dgvContract.Columns.Add(new DataGridViewTextBoxColumn { Name = "ContractID", HeaderText = "Mã HĐ", DataPropertyName = "ContractID", Width = 80 });
            dgvContract.Columns.Add(new DataGridViewTextBoxColumn { Name = "RoomName", HeaderText = "Phòng", DataPropertyName = "RoomName", Width = 100 });
            dgvContract.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenantName", HeaderText = "Khách Thuê", DataPropertyName = "TenantName", Width = 150 });
            dgvContract.Columns.Add(new DataGridViewTextBoxColumn { Name = "StartDate", HeaderText = "Từ Ngày", DataPropertyName = "StartDate", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvContract.Columns.Add(new DataGridViewTextBoxColumn { Name = "EndDate", HeaderText = "Đến Ngày", DataPropertyName = "EndDate", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvContract.Columns.Add(new DataGridViewTextBoxColumn { Name = "Price", HeaderText = "Giá Thuê", DataPropertyName = "Price", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
            dgvContract.Columns.Add(new DataGridViewTextBoxColumn { Name = "ContractStatus", HeaderText = "Trạng Thái", DataPropertyName = "ContractStatus" });
            DataGridViewButtonColumn btnViewCol = new DataGridViewButtonColumn();
            btnViewCol.Name = "btnView";
            btnViewCol.HeaderText = "Chi Tiết";
            btnViewCol.Text = "Xem";
            btnViewCol.UseColumnTextForButtonValue = true; 
            btnViewCol.Width = 60;
            dgvContract.Columns.Add(btnViewCol);
        }

        private void LoadGrid()
        {
            var contracts = context.Contracts
                .Include(c => c.Room)
                .Include(c => c.Tenant)
                .Select(c => new
                {
                    c.ContractID,
                    RoomName = c.Room.RoomName,
                    TenantName = c.Tenant.TenantName,
                    c.StartDate,
                    c.EndDate,
                    Price = c.Room.Price,
                    c.ContractStatus
                })
                .ToList();

            dgvContract.DataSource = contracts;
            dgvContract.ClearSelection();
            selectedContractId = 0;
        }

        private void dgvContract_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvContract.Rows[e.RowIndex];
                selectedContractId = Convert.ToInt32(row.Cells["ContractID"].Value);

                // KIỂM TRA: NẾU NGƯỜI DÙNG BẤM VÀO CỘT "btnView"
                if (dgvContract.Columns[e.ColumnIndex].Name == "btnView")
                {
                    // Mở form Chi tiết truyền vào isViewMode = true
                    frmDetailed_Contract frm = new frmDetailed_Contract(selectedContractId, true);
                    frm.ShowDialog();
                    // Xem xong thì không cần LoadGrid() lại vì không có gì thay đổi
                }
            }
        }

        private void btnLapHD_Click(object sender, EventArgs e)
        {
            // Truyền 0 hoặc không truyền để hiểu là tạo mới
            frmDetailed_Contract frm = new frmDetailed_Contract(0);
            frm.ShowDialog();
            LoadGrid(); // Load lại lưới sau khi thêm
        }

        private void btnInHD_Click(object sender, EventArgs e)
        {
            if (selectedContractId == 0)
            {
                MessageBox.Show("Vui lòng chọn hợp đồng cần in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // TODO: Code xuất file Word hoặc report in hợp đồng
            MessageBox.Show($"Đang tạo bản in cho hợp đồng ID: {selectedContractId}...");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedContractId == 0)
            {
                MessageBox.Show("Vui lòng chọn hợp đồng cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Truyền ID vào form chi tiết để Sửa
            frmDetailed_Contract frm = new frmDetailed_Contract(selectedContractId);
            frm.ShowDialog();
            LoadGrid(); // Load lại lưới sau khi sửa
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedContractId == 0)
            {
                MessageBox.Show("Vui lòng chọn hợp đồng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa hợp đồng này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var contract = context.Contracts.Find(selectedContractId);
                if (contract != null)
                {
                    context.Contracts.Remove(contract);
                    context.SaveChanges();
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGrid();
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            // Lấy từ khóa người dùng vừa nhập vào ô TextBox tự t

            string keyword = txtTimKiem.Text.Trim().ToLower();

            // Nếu ô tìm kiếm trống, load lại toàn bộ danh sách
            if (string.IsNullOrEmpty(keyword))
            {
                LoadGrid();
                return;
            }

            try
            {
                var filteredContracts = context.Contracts
                    .Include(c => c.Room)
                    .Include(c => c.Tenant)
                    .Where(c =>
                        (c.Room != null && c.Room.RoomName.ToLower().Contains(keyword)) ||
                        (c.Tenant != null && c.Tenant.TenantName.ToLower().Contains(keyword)) ||
                        c.ContractID.ToString().Contains(keyword)
                    )
                    .Select(c => new
                    {
                        c.ContractID,
                        RoomName = c.Room.RoomName,
                        TenantName = c.Tenant.TenantName,
                        c.StartDate,
                        c.EndDate,
                        Price = c.Room.Price,
                        c.ContractStatus
                    })
                    .ToList();

                dgvContract.DataSource = filteredContracts;
                dgvContract.ClearSelection();
                selectedContractId = 0;

                if (filteredContracts.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy hợp đồng nào phù hợp với từ khóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Xuất danh sách hợp đồng ra Excel";
            saveFileDialog.Filter = "Tập tin Excel *.xlsx|*.xlsx";
            saveFileDialog.FileName = "DanhSachHopDong_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();

                    // 1. Định nghĩa các cột cho file Excel
                    table.Columns.Add("Mã HĐ", typeof(int));
                    table.Columns.Add("Tên Phòng", typeof(string));
                    table.Columns.Add("Khách Thuê", typeof(string));
                    // Ép kiểu Ngày sang String để khi lên Excel giữ đúng định dạng dd/MM/yyyy
                    table.Columns.Add("Từ Ngày", typeof(string));
                    table.Columns.Add("Đến Ngày", typeof(string));
                    table.Columns.Add("Giá Thuê", typeof(decimal));
                    table.Columns.Add("Trạng Thái", typeof(string));

                    // 2. Lấy dữ liệu từ Database (Include để lấy được tên Phòng và tên Khách)
                    var contracts = context.Contracts
                        .Include(c => c.Room)
                        .Include(c => c.Tenant)
                        .ToList();

                    // 3. Đổ dữ liệu vào DataTable
                    foreach (var c in contracts)
                    {
                        table.Rows.Add(
                            c.ContractID,
                            c.Room?.RoomName,
                            c.Tenant?.TenantName,
                            c.StartDate.ToString("dd/MM/yyyy"), // Format ngày tháng
                            c.EndDate.ToString("dd/MM/yyyy"),   // Format ngày tháng
                            c.Room?.Price ?? 0,
                            c.ContractStatus
                        );
                    }

                    // 4. Lưu ra file Excel
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(table, "DanhSachHopDong");
                        sheet.Columns().AdjustToContents(); // Tự động căn chỉnh độ rộng cột cho đẹp
                        wb.SaveAs(saveFileDialog.FileName);

                        MessageBox.Show("Xuất dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
