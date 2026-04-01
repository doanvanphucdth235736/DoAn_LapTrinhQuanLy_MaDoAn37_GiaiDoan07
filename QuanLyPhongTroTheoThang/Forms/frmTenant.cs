using System;
using QuanLyPhongTroTheoThang.Data;
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

namespace QuanLyPhongTroTheoThang.Forms
{
    public partial class frmTenant : Form
    {
        QLPTDbContext context = new QLPTDbContext();
        bool isAddMode = false;
        bool isPopulating = false;
        bool isEditing = false;

        int selectedTenantId = 0;

        public frmTenant()
        {
            InitializeComponent();
        }

        private void frmTenant_Load(object sender, EventArgs e)
        {
            dgvTenant.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTenant.AutoGenerateColumns = false;

            dgvTenant.Columns.Clear();

            dgvTenant.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "TenantID",
                HeaderText = "Mã Khách Hàng",
                DataPropertyName = "TenantID",
                Width = 50,
                ReadOnly = true
            });

            dgvTenant.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "TenantName",
                HeaderText = "Tên khách",
                DataPropertyName = "TenantName"
            });

            dgvTenant.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Phone",
                HeaderText = "SĐT",
                DataPropertyName = "Phone"
            });

            dgvTenant.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "CCCD",
                HeaderText = "CCCD",
                DataPropertyName = "CCCD"
            });

            dgvTenant.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTenant.ClearSelection();

            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;

            LoadGrid();
        }

        private void LoadGrid()
        {
            dgvTenant.DataSource = context.Tenants
                .Select(t => new
                {
                    t.TenantID,
                    t.TenantName,
                    t.Phone,
                    t.CCCD
                })
                .ToList();
        }

        private void dgvTenant_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                isPopulating = true;

                var row = dgvTenant.Rows[e.RowIndex];

                selectedTenantId = Convert.ToInt32(row.Cells["TenantID"].Value);

                txtTenantName.Text = row.Cells["TenantName"].Value?.ToString() ?? "";
                txtPhone.Text = row.Cells["Phone"].Value?.ToString() ?? "";
                txtCCCD.Text = row.Cells["CCCD"].Value?.ToString() ?? "";

                isPopulating = false;

                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnLuu.Enabled = false;

                isAddMode = false;
            }
        }


        private void SearchTenant()
        {
            var query = context.Tenants.AsQueryable();

            if (!string.IsNullOrWhiteSpace(txtTenantName.Text))
            {
                query = query.Where(t => t.TenantName.Contains(txtTenantName.Text));
            }

            if (!string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                query = query.Where(t => t.Phone.Contains(txtPhone.Text));
            }

            if (!string.IsNullOrWhiteSpace(txtCCCD.Text))
            {
                query = query.Where(t => t.CCCD.Contains(txtCCCD.Text));
            }

            dgvTenant.DataSource = query
                .Select(t => new
                {
                    t.TenantID,
                    t.TenantName,
                    t.Phone,
                    t.CCCD
                })
                .ToList();
            dgvTenant.Refresh();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (isPopulating || isEditing) return;
            SearchTenant();
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            if (isPopulating || isEditing) return;
            SearchTenant();
        }

        private void txtCCCD_TextChanged(object sender, EventArgs e)
        {
            if (isPopulating || isEditing) return;
            SearchTenant();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAddMode = true;

            txtTenantName.Clear();
            txtPhone.Clear();
            txtCCCD.Clear();

            selectedTenantId = 0;

            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedTenantId == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng!");
                return;
            }

            isAddMode = false;
            isEditing = true;

            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenantName.Text == "" || txtPhone.Text == "" || txtCCCD.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            if (isAddMode)
            {
                Tenant tenant = new Tenant()
                {
                    TenantName = txtTenantName.Text,
                    Phone = txtPhone.Text,
                    CCCD = txtCCCD.Text
                };

                context.Tenants.Add(tenant);
                MessageBox.Show("Thêm thành công!");
            }
            else
            {
                Tenant tenant = context.Tenants.Find(selectedTenantId);

                if (tenant != null)
                {
                    tenant.TenantName = txtTenantName.Text;
                    tenant.Phone = txtPhone.Text;
                    tenant.CCCD = txtCCCD.Text;

                    MessageBox.Show("Cập nhật thành công!");
                }
            }

            context.SaveChanges();
            LoadGrid();
            isEditing = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedTenantId == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng!");
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc muốn xóa không?",
                                         "Xác nhận",
                                         MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                var tenant = context.Tenants.Find(selectedTenantId);

                if (tenant != null)
                {
                    context.Tenants.Remove(tenant);
                    context.SaveChanges();

                    LoadGrid();
                    btnHuyBo_Click(null, null);
                }
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            txtTenantName.Clear();
            txtPhone.Clear();
            txtCCCD.Clear();

            selectedTenantId = 0;
            isEditing = false;

            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
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
                            if (firstRow) // Đọc dòng tiêu đề
                            {
                                readRange = string.Format("{0}:{1}", 1, row.LastCellUsed().Address.ColumnNumber);
                                foreach (IXLCell cell in row.Cells(readRange))
                                {
                                    table.Columns.Add(cell.Value.ToString().Trim());
                                }
                                firstRow = false;
                            }
                            else // Đọc các dòng dữ liệu
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

                    // Đưa dữ liệu từ DataTable vào Database
                    if (table.Rows.Count > 0)
                    {
                        int countSuccess = 0;
                        foreach (DataRow r in table.Rows)
                        {
                            // Bỏ qua nếu cột Tên khách bị rỗng (tránh lưu dữ liệu rác)
                            if (string.IsNullOrWhiteSpace(r["Tên khách"]?.ToString())) continue;

                            Tenant newTenant = new Tenant();
                            newTenant.TenantName = r["Tên khách"].ToString();
                            newTenant.Phone = r["SĐT"]?.ToString() ?? "";
                            newTenant.CCCD = r["CCCD"]?.ToString() ?? "";

                            context.Tenants.Add(newTenant);
                            countSuccess++;
                        }

                        context.SaveChanges();
                        MessageBox.Show($"Đã nhập thành công {countSuccess} khách hàng mới.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadGrid(); // Làm mới DataGridView
                    }
                    else
                    {
                        MessageBox.Show("Tập tin Excel không có dữ liệu.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    // Bẫy lỗi chi tiết nếu vi phạm Database
                    string error = ex.Message;
                    if (ex.InnerException != null)
                        error += "\nChi tiết: " + ex.InnerException.InnerException?.Message;

                    MessageBox.Show("Lỗi nhập dữ liệu: " + error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Xuất danh sách khách hàng ra Excel";
            saveFileDialog.Filter = "Tập tin Excel *.xlsx|*.xlsx";
            saveFileDialog.FileName = "DanhSachKhachHang_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();

                    // Định nghĩa các cột cho file Excel
                    table.Columns.Add("Mã khách hàng", typeof(int));
                    table.Columns.Add("Tên khách", typeof(string));
                    table.Columns.Add("SĐT", typeof(string));
                    table.Columns.Add("CCCD", typeof(string));

                    // Lấy danh sách từ cơ sở dữ liệu
                    var tenants = context.Tenants.ToList();

                    foreach (var t in tenants)
                    {
                        table.Rows.Add(t.TenantID, t.TenantName, t.Phone, t.CCCD);
                    }

                    // Ghi ra file Excel
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(table, "KhachHang");
                        sheet.Columns().AdjustToContents(); // Tự động căn chỉnh độ rộng cột
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

