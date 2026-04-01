using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using QuanLyPhongTroTheoThang.Data;

namespace QuanLyPhongTroTheoThang.Forms
{
    public partial class frmDetailed_Bill : Form
    {
        QLPTDbContext context = new QLPTDbContext();
        private int? _billId;

        private bool _isInitializing = true;
        private bool _isViewOnly;
        public frmDetailed_Bill(int? billId = null, bool isViewOnly = false)
        {
            InitializeComponent();
            _billId = billId;
            _isViewOnly = isViewOnly;
        }

        private void frmDetailed_Bill_Load(object sender, EventArgs e)
        {
            _isInitializing = true;

            nudElectricOld.Maximum = 9999999;
            nudElectricNew.Maximum = 9999999;
            nudWaterOld.Maximum = 9999999;
            nudWaterNew.Maximum = 9999999;

            LoadContracts();
            SetupEventHandlers();

            if (_billId.HasValue)
            {
                if (_isViewOnly)
                {
                    this.Text = "Xem Chi Tiết Hóa Đơn";
                    LockControls(); 
                }
                else
                {
                    this.Text = "Sửa Chi Tiết Hóa Đơn";
                }
                LoadBillDetails();
            }
            else
            {
                this.Text = "Lập Hóa Đơn Mới";
                dtpMonth.Value = DateTime.Now;
            }

            _isInitializing = false;
        }

        private void LockControls()
        {
            cboContract.Enabled = false;
            dtpMonth.Enabled = false;
            nudElectricOld.Enabled = false;
            nudElectricNew.Enabled = false;
            nudWaterOld.Enabled = false;
            nudWaterNew.Enabled = false;
            chkStatus.Enabled = false;
            txtNotes.ReadOnly = true;
            txtRoomName.ReadOnly = true;
            txtTenantName.ReadOnly = true;
            txtRoomPrice.ReadOnly = true;
            txtTotal.ReadOnly = true;

            btnLuu.Visible = false;
            btnHuyBo.Text = "Đóng";
        }

        private void SetupEventHandlers()
        {
            nudElectricOld.ValueChanged += (s, ev) => CalculateTotal();
            nudElectricNew.ValueChanged += (s, ev) => CalculateTotal();
            nudWaterOld.ValueChanged += (s, ev) => CalculateTotal();
            nudWaterNew.ValueChanged += (s, ev) => CalculateTotal();

            // MỚI THÊM: Gắn sự kiện khi đổi hợp đồng
            cboContract.SelectedIndexChanged += cboContract_SelectedIndexChanged;
        }

        private void LoadContracts()
        {
            var contracts = context.Contracts
                .Select(c => new
        {
                    c.ContractID,
                    // Thay đổi: Do đã có TextBox tên phòng và khách riêng,
                    // ComboBox giờ chỉ cần hiển thị một thông tin đại diện, ví dụ "Hợp đồng số #ID"
                    DisplayText = "Hợp đồng #" + c.ContractID
                })
                .ToList();

            cboContract.DataSource = contracts;
            cboContract.DisplayMember = "DisplayText";
            cboContract.ValueMember = "ContractID";
            cboContract.SelectedIndex = -1;
        }

        private void LoadBillDetails()
        {
            var bill = context.Bills.Find(_billId.Value);
            if (bill != null)
            {
                // Khi gán giá trị này, CboContract_SelectedIndexChanged sẽ tự động chạy (do event đã được kích hoạt).
                // Tuy nhiên nhờ có biến _isInitializing = true, dữ liệu Điện/Nước cũ sẽ không bị ghi đè.
                cboContract.SelectedValue = bill.ContractID;

                dtpMonth.Value = bill.Month;
                nudElectricOld.Value = bill.ElectricOld;
                nudElectricNew.Value = bill.ElectricNew;
                nudWaterOld.Value = bill.WaterOld;
                nudWaterNew.Value = bill.WaterNew;
                txtTotal.Text = bill.Total.ToString("N0");
                chkStatus.Checked = bill.Status;
                txtNotes.Text = bill.Notes ?? "";
            }
        }

        private void CalculateTotal()
        {
            if (cboContract.SelectedValue == null) return;

            if (cboContract.SelectedValue == null ||
                !int.TryParse(cboContract.SelectedValue.ToString(), out int contractId))
                return;

            // Sử dụng contractId đã lấy được an toàn
            var contract = context.Contracts
                .Include(c => c.Room)
                .FirstOrDefault(c => c.ContractID == contractId);

            if (contract != null)
            {
                decimal electricUsed = nudElectricNew.Value - nudElectricOld.Value;
                decimal waterUsed = nudWaterNew.Value - nudWaterOld.Value;

                electricUsed = Math.Max(0, electricUsed);
                waterUsed = Math.Max(0, waterUsed);

                lblElectricUsed.Text = $"Sử dụng: {electricUsed} kWh";
                lblWaterUsed.Text = $"Sử dụng: {waterUsed} m3";

                decimal roomPrice = contract.Room.Price;
                decimal electricPrice = 3500; 
                decimal waterPrice = 15000;

                decimal electricCost = electricUsed * electricPrice;
                decimal waterCost = waterUsed * waterPrice;

                decimal total = roomPrice + electricCost + waterCost;

                txtTotal.Text = total.ToString("N0");
            }
        }

        private void cboContract_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateTotal();

            // Nếu người dùng chọn một hợp đồng hợp lệ
            if (cboContract.SelectedValue != null && int.TryParse(cboContract.SelectedValue.ToString(), out int contractId))
            {
                var contract = context.Contracts
                    .Include(c => c.Room)
                    .Include(c => c.Tenant)
                    .FirstOrDefault(c => c.ContractID == contractId);

                if (contract != null)
                {
                    // 1. Tự động hiển thị Tên Phòng và Tên Khách
                    if (txtRoomName != null) txtRoomName.Text = contract.Room.RoomName;
                    if (txtTenantName != null) txtTenantName.Text = contract.Tenant.TenantName;

                    if (txtRoomPrice != null) txtRoomPrice.Text = contract.Room.Price.ToString("N0");

                    // 2. Lấy chỉ số cũ (CHỈ THỰC HIỆN KHI KHÔNG PHẢI LÀ ĐANG LOAD FORM SỬA)
                    if (!_isInitializing)
                    {
                        // Tìm hóa đơn gần nhất của hợp đồng này (sắp xếp theo tháng giảm dần)
                        var lastBill = context.Bills
                            .Where(b => b.ContractID == contractId)
                            .OrderByDescending(b => b.Month)
                            .FirstOrDefault();

                        if (lastBill != null)
                        {
                            // Đã có hóa đơn trước đó -> Lấy số "Mới" của tháng trước làm số "Cũ" tháng này
                            nudElectricOld.Value = lastBill.ElectricNew;
                            nudWaterOld.Value = lastBill.WaterNew;
                        }
                        else
                        {
                            // Chưa có hóa đơn nào -> Lấy số khởi tạo ghi trong Hợp đồng
                            nudElectricOld.Value = contract.ElectricStart;
                            nudWaterOld.Value = contract.WaterStart;
                        }
                    }
                }
            }
            else
            {
                // Xóa trống nếu không chọn hợp đồng
                if (txtRoomName != null) txtRoomName.Clear();
                if (txtTenantName != null) txtTenantName.Clear();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Validate sơ bộ
            if (cboContract.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn hợp đồng/phòng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nudElectricNew.Value < nudElectricOld.Value || nudWaterNew.Value < nudWaterOld.Value)
            {
                MessageBox.Show("Chỉ số mới không được nhỏ hơn chỉ số cũ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal.TryParse(txtTotal.Text, out decimal totalAmount);

            if (_billId.HasValue)
            {
                var bill = context.Bills.Find(_billId.Value);
                if (bill != null)
                {
                    // Cập nhật các trường còn thiếu
                    bill.Month = dtpMonth.Value;
                    bill.ElectricOld = (int)nudElectricOld.Value;
                    bill.ElectricNew = (int)nudElectricNew.Value;
                    bill.WaterOld = (int)nudWaterOld.Value;
                    bill.WaterNew = (int)nudWaterNew.Value;

                    // QUAN TRỌNG: Nếu bạn đã thêm RoomPrice vào class Bill như tôi hướng dẫn trước đó
                    // decimal.TryParse(txtPriceRoom.Text, out decimal rPrice);
                    // bill.RoomPrice = rPrice; 

                    bill.Total = totalAmount;
                    bill.Status = chkStatus.Checked;
                    bill.Notes = txtNotes.Text;
                }
            }
            else
            {
                var newBill = new Bill
                {
                    ContractID = (int)cboContract.SelectedValue,
                    Month = dtpMonth.Value,
                    ElectricOld = (int)nudElectricOld.Value,
                    ElectricNew = (int)nudElectricNew.Value,
                    WaterOld = (int)nudWaterOld.Value,
                    WaterNew = (int)nudWaterNew.Value,
                    Total = totalAmount,
                    Status = chkStatus.Checked,
                    Notes = txtNotes.Text
                };
                context.Bills.Add(newBill);
            }

            try
            {
                context.SaveChanges();
                MessageBox.Show("Lưu hóa đơn thành công!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();       
        }
    }
}
