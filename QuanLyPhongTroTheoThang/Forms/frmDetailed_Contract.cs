using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyPhongTroTheoThang.Data;

namespace QuanLyPhongTroTheoThang.Forms
{
    public partial class frmDetailed_Contract : Form
    {
        QLPTDbContext context = new QLPTDbContext();
        private int _contractId = 0;
        private bool _isViewMode = false;
        public frmDetailed_Contract(int contractId = 0, bool isViewMode = false)
        {
            InitializeComponent();
            _contractId = contractId;
            _isViewMode = isViewMode;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbRoom.SelectedValue == null || cmbTenant.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn đầy đủ Phòng và Khách thuê!", "Cảnh báo");
                    return;
                }

                int roomId = (int)cmbRoom.SelectedValue;
                decimal.TryParse(txtDeposit.Text, out decimal depositValue);
                int.TryParse(txtElectricStart.Text, out int electricStart);
                int.TryParse(txtWaterStart.Text, out int waterStart);

                Contract contract;
                if (_contractId == 0)
                {
                    contract = new Contract();
                    context.Contracts.Add(contract);

                    var room = context.Rooms.Find(roomId);
                    if (room != null) room.Status = "Đã thuê";
                }
                else 
                {
                    contract = context.Contracts.Find(_contractId);
                    if (contract == null) return;

                    if (contract.RoomID != roomId)
                    {
                        var oldRoom = context.Rooms.Find(contract.RoomID);
                        if (oldRoom != null) oldRoom.Status = "Trống";

                        var newRoom = context.Rooms.Find(roomId);
                        if (newRoom != null) newRoom.Status = "Đã thuê";
                    }
                }

                contract.RoomID = roomId;
                contract.TenantID = (int)cmbTenant.SelectedValue;
                contract.StartDate = dtpStartDate.Value;
                contract.EndDate = dtpEndDate.Value;
                contract.Deposit = depositValue;
                contract.ElectricStart = electricStart;
                contract.WaterStart = waterStart;
                contract.PaymentDay = (int)nudPaymentDay.Value;
                contract.ContractStatus = cmbContractStatus.Text;
                contract.NumberOfOccupants = (int)nudNumberOfOccupants.Value;
                contract.Notes = txtNotes.Text;

                contract.CreatedBy = txtNhanVienLap.Text;

                if (contract.ContractStatus == "Đã thanh lý" || contract.ContractStatus == "Đã hủy")
                {
                    var room = context.Rooms.Find(contract.RoomID);
                    if (room != null) room.Status = "Trống";
                }

                context.SaveChanges();
                MessageBox.Show("Lưu dữ liệu thành công!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void frmDetailed_Contract_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();

            if (_contractId > 0)
            {
                LoadContractData();

                if (_isViewMode)
                {
                    this.Text = "Xem Chi Tiết Hợp Đồng";
                    DisableControls();
                }
                else
                {
                    this.Text = "Sửa Thông Tin Hợp Đồng";
                }
            }
            else
            {
                this.Text = "Lập Hợp Đồng Mới";
                cmbContractStatus.Text = "Đang hiệu lực";
                txtNhanVienLap.Text = frmMain.TenNhanVienHienTai;
                if (this.Tag != null)
                {
                    cmbRoom.SelectedValue = Convert.ToInt32(this.Tag);
                }
            }
        }

        private void LoadComboBoxes()
        {
            var rooms = context.Rooms.ToList();
            cmbRoom.DisplayMember = "RoomName";
            cmbRoom.ValueMember = "RoomID"; 
            cmbRoom.DataSource = rooms;     
            cmbRoom.SelectedIndex = -1;

            var tenants = context.Tenants.ToList();
            cmbTenant.DisplayMember = "TenantName";
            cmbTenant.ValueMember = "TenantID"; 
            cmbTenant.DataSource = tenants;     
            cmbTenant.SelectedIndex = -1;

            // Load Trạng thái
            cmbContractStatus.Items.Clear();
            cmbContractStatus.Items.AddRange(new string[] { "Đang hiệu lực", "Sắp hết hạn", "Đã thanh lý", "Đã hủy" });
        }

        private void LoadContractData()
        {
            var contract = context.Contracts.Find(_contractId);
            if (contract != null)
            {
                cmbRoom.SelectedValue = contract.RoomID;
                cmbTenant.SelectedValue = contract.TenantID;
                dtpStartDate.Value = contract.StartDate;
                dtpEndDate.Value = contract.EndDate;
                txtDeposit.Text = contract.Deposit.ToString("0");
                txtPrice.Text = context.Rooms.Find(contract.RoomID)?.Price.ToString("0");
                txtElectricStart.Text = contract.ElectricStart.ToString();
                txtWaterStart.Text = contract.WaterStart.ToString();
                nudPaymentDay.Value = contract.PaymentDay > 0 ? contract.PaymentDay : 1;
                cmbContractStatus.Text = contract.ContractStatus;
                nudNumberOfOccupants.Value = contract.NumberOfOccupants > 0 ? contract.NumberOfOccupants : 1;

                txtNotes.Text = contract.Notes;

                txtNhanVienLap.Text = contract.CreatedBy;
            }
        }

        private void DisableControls()
        {
            cmbRoom.Enabled = false;
            cmbTenant.Enabled = false;
            dtpStartDate.Enabled = false;
            dtpEndDate.Enabled = false;
            txtDeposit.Enabled = false;
            txtPrice.Enabled = false;
            txtElectricStart.Enabled = false;
            txtWaterStart.Enabled = false;
            nudPaymentDay.Enabled = false;
            cmbContractStatus.Enabled = false;
            nudNumberOfOccupants.Enabled = false;
            txtNotes.Enabled = false;
            txtNhanVienLap.Enabled = false;

            btnLuu.Visible = false; 
            btnHuyBo.Text = "Đóng"; 
        }

        private void cmbTenant_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRoom.SelectedValue != null && int.TryParse(cmbRoom.SelectedValue.ToString(), out int roomId))
            {
                if (_contractId == 0 || cmbRoom.Focused)
                {
                    var room = context.Rooms.Find(roomId);
                    if (room != null)
                    {
                        txtPrice.Text = room.Price.ToString("N0"); 
                    }
                }
            }
            else
            {
                txtPrice.Text = "0";
            }
        }
    }
}
