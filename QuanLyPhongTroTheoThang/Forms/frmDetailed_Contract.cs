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
                // Kiểm tra đầu vào cơ bản
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
                if (_contractId == 0) // THÊM MỚI
                {
                    contract = new Contract();
                    context.Contracts.Add(contract);

                    // Cập nhật phòng thành Đã thuê
                    var room = context.Rooms.Find(roomId);
                    if (room != null) room.Status = "Đã thuê";
                }
                else // SỬA
                {
                    contract = context.Contracts.Find(_contractId);
                    if (contract == null) return;

                    // Nếu đổi phòng: Phòng cũ thành Trống, phòng mới thành Đã thuê
                    if (contract.RoomID != roomId)
                    {
                        var oldRoom = context.Rooms.Find(contract.RoomID);
                        if (oldRoom != null) oldRoom.Status = "Trống";

                        var newRoom = context.Rooms.Find(roomId);
                        if (newRoom != null) newRoom.Status = "Đã thuê";
                    }
                }

                // Gán dữ liệu chung
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

                // Xử lý khi kết thúc hợp đồng
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

                // NẾU LÀ CHẾ ĐỘ XEM THÌ KHÓA TẤT CẢ LẠI
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
            }
        }

        private void LoadComboBoxes()
        {
            var rooms = context.Rooms.ToList();
            cmbRoom.DisplayMember = "RoomName";
            cmbRoom.ValueMember = "RoomID"; // Gán trước
            cmbRoom.DataSource = rooms;     // Gán DataSource sau
            cmbRoom.SelectedIndex = -1;

            var tenants = context.Tenants.ToList();
            cmbTenant.DisplayMember = "TenantName";
            cmbTenant.ValueMember = "TenantID"; // Gán trước
            cmbTenant.DataSource = tenants;     // Gán DataSource sau
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

                txtNotes.Text = contract.Notes; // Ô Ghi chú của bạn đang tên là textBox1
            }
        }

        private void DisableControls()
        {
            cmbRoom.Enabled = false;
            cmbTenant.Enabled = false;
            dtpStartDate.Enabled = false;
            dtpEndDate.Enabled = false;
            txtDeposit.ReadOnly = true;
            txtPrice.ReadOnly = true;
            txtElectricStart.ReadOnly = true;
            txtWaterStart.ReadOnly = true;
            nudPaymentDay.Enabled = false;
            cmbContractStatus.Enabled = false;
            nudNumberOfOccupants.Enabled = false;
            txtNotes.ReadOnly = true;

            btnLuu.Visible = false; // Ẩn nút Lưu
            btnHuyBo.Text = "Đóng"; // Đổi chữ nút Hủy thành Đóng cho hợp lý
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
            // Kiểm tra an toàn: Đảm bảo có giá trị và ép kiểu int thành công
            if (cmbRoom.SelectedValue != null && int.TryParse(cmbRoom.SelectedValue.ToString(), out int roomId))
            {
                // Chỉ điền giá lúc thêm mới hoặc khi người dùng chủ động bấm chọn
                if (_contractId == 0 || cmbRoom.Focused)
                {
                    var room = context.Rooms.Find(roomId);
                    if (room != null)
                    {
                        txtPrice.Text = room.Price.ToString("N0"); // Dùng "N0" để hiển thị dấu chấm ngăn cách hàng nghìn (VD: 1.500.000)
                    }
                }
            }
            else
            {
                txtPrice.Text = "0"; // Trả về 0 nếu chưa chọn phòng
            }
        }
    }
}
