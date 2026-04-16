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


            ConfigureUI();


            if (_billId.HasValue)
            {
                LoadBillDetails();
            }

            _isInitializing = false;
        }

        private void ConfigureUI()
        {

            txtRoomName.Enabled = false;
            txtTenantName.Enabled = false;
            txtTotal.Enabled = false;

            if (_billId.HasValue)
            {
                cboContract.Enabled = false;

                if (_isViewOnly)
                {
                    this.Text = "Xem Chi Tiết Hóa Đơn";

                    dtpMonth.Enabled = false;
                    nudElectricOld.Enabled = false;
                    nudElectricNew.Enabled = false;
                    nudWaterOld.Enabled = false;
                    nudWaterNew.Enabled = false;
                    chkStatus.Enabled = false;
                    txtNotes.Enabled = false;
                    txtRoomPrice.Enabled = false;

                    btnLuu.Visible = false;
                    btnHuyBo.Text = "Đóng";
                }
                else
                {
                    this.Text = "Sửa Chi Tiết Hóa Đơn";
                }
            }
            else
            {
                this.Text = "Lập Hóa Đơn Mới";

                cboContract.Enabled = true;
                dtpMonth.Value = DateTime.Now;
                txtNhanVienLap.Text = frmMain.TenNhanVienHienTai;

                if (this.Tag != null)
                {
                    int roomId = Convert.ToInt32(this.Tag);

                    var activeContract = context.Contracts
                        .Where(c => c.RoomID == roomId && c.ContractStatus != "Đã thanh lý" && c.ContractStatus != "Đã hủy")
                        .OrderByDescending(c => c.ContractID)
                        .FirstOrDefault();

                    if (activeContract != null)
                    {
                        cboContract.SelectedValue = activeContract.ContractID;
                        cboContract.Enabled = false;
                    }
                }
            }
        }

        private void SetupEventHandlers()
        {
            nudElectricOld.ValueChanged += (s, ev) => CalculateTotal();
            nudElectricNew.ValueChanged += (s, ev) => CalculateTotal();
            nudWaterOld.ValueChanged += (s, ev) => CalculateTotal();
            nudWaterNew.ValueChanged += (s, ev) => CalculateTotal();

            cboContract.SelectedIndexChanged += cboContract_SelectedIndexChanged;
        }

        private void LoadContracts()
        {
            var contracts = context.Contracts
                .Select(c => new
        {
                    c.ContractID,

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

                cboContract.SelectedValue = bill.ContractID;

                dtpMonth.Value = bill.Month;
                nudElectricOld.Value = bill.ElectricOld;
                nudElectricNew.Value = bill.ElectricNew;
                nudWaterOld.Value = bill.WaterOld;
                nudWaterNew.Value = bill.WaterNew;
                txtTotal.Text = bill.Total.ToString("N0");
                chkStatus.Checked = bill.Status;
                txtNotes.Text = bill.Notes ?? "";
                txtNhanVienLap.Text = bill.CreatedBy;
            }
        }

        private void CalculateTotal()
        {
            if (cboContract.SelectedValue == null) return;

            if (cboContract.SelectedValue == null ||
                !int.TryParse(cboContract.SelectedValue.ToString(), out int contractId))
                return;

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

            if (cboContract.SelectedValue != null && int.TryParse(cboContract.SelectedValue.ToString(), out int contractId))
            {
                var contract = context.Contracts
                    .Include(c => c.Room)
                    .Include(c => c.Tenant)
                    .FirstOrDefault(c => c.ContractID == contractId);

                if (contract != null)
                {
                    if (txtRoomName != null) txtRoomName.Text = contract.Room.RoomName;
                    if (txtTenantName != null) txtTenantName.Text = contract.Tenant.TenantName;

                    if (txtRoomPrice != null) txtRoomPrice.Text = contract.Room.Price.ToString("N0");

                    if (!_isInitializing)
                    {
                        var lastBill = context.Bills
                            .Where(b => b.ContractID == contractId)
                            .OrderByDescending(b => b.Month)
                            .FirstOrDefault();

                        if (lastBill != null)
                        {
                            nudElectricOld.Value = lastBill.ElectricNew;
                            nudWaterOld.Value = lastBill.WaterNew;
                        }
                        else
                        {
                            nudElectricOld.Value = contract.ElectricStart;
                            nudWaterOld.Value = contract.WaterStart;
                        }
                    }
                }
            }
            else
            {
                if (txtRoomName != null) txtRoomName.Clear();
                if (txtTenantName != null) txtTenantName.Clear();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
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
                    bill.Month = dtpMonth.Value;
                    bill.ElectricOld = (int)nudElectricOld.Value;
                    bill.ElectricNew = (int)nudElectricNew.Value;
                    bill.WaterOld = (int)nudWaterOld.Value;
                    bill.WaterNew = (int)nudWaterNew.Value;

                    bill.Total = totalAmount;
                    bill.Status = chkStatus.Checked;
                    bill.Notes = txtNotes.Text;
                }
            }
            else
            {
                decimal.TryParse(txtRoomPrice.Text, out decimal roomPrice);
                var newBill = new Bill
                {
                    ContractID = (int)cboContract.SelectedValue,
                    Month = dtpMonth.Value,
                    RoomPrice = roomPrice,
                    ElectricOld = (int)nudElectricOld.Value,
                    ElectricNew = (int)nudElectricNew.Value,
                    WaterOld = (int)nudWaterOld.Value,
                    WaterNew = (int)nudWaterNew.Value,
                    Total = totalAmount,
                    Status = chkStatus.Checked,
                    Notes = txtNotes.Text,
                    CreatedBy = txtNhanVienLap.Text
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
