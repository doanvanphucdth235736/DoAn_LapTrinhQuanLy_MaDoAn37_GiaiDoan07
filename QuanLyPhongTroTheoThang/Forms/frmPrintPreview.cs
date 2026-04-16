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
using Microsoft.Reporting.WinForms;

namespace QuanLyPhongTroTheoThang.Forms
{
    public partial class frmPrintPreview : Form
    {
        public ReportViewer reportViewer1;
        public frmPrintPreview()
        {
            InitializeComponent();

            reportViewer1 = new ReportViewer();
            reportViewer1.Dock = DockStyle.Fill; // Cho nó tràn viền
            this.Controls.Add(reportViewer1);
        }

        private void frmPrintPreview_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

        public void LoadHoaDon(int billId)
        {
            using (var db = new QLPTDbContext())
            {
                var bill = db.Bills
                    .Include(b => b.Contract).ThenInclude(c => c.Room)
                    .Include(b => b.Contract).ThenInclude(c => c.Tenant)
                    .FirstOrDefault(b => b.BillID == billId);

                if (bill == null) return;

                DataTable dt = new DataTable();
                dt.Columns.Add("RoomName");
                dt.Columns.Add("TenantName");
                dt.Columns.Add("Thang");
                dt.Columns.Add("TienPhong"); // Kiểm tra xem trên RDLC ô này có ghi là [TienPhong] không
                dt.Columns.Add("ChiSoDien");
                dt.Columns.Add("TongTienDien");
                dt.Columns.Add("ChiSoNuoc"); // Thêm cột nước
                dt.Columns.Add("TongTienNuoc"); // Thêm cột tiền nước
                dt.Columns.Add("TongCong");
                dt.Columns.Add("GhiChu"); // Thêm cột ghi chú
                dt.Columns.Add("NguoiLap");

                // Đổ dữ liệu thật cẩn thận
                dt.Rows.Add(
                    bill.Contract.Room.RoomName,
                    bill.Contract.Tenant.TenantName,
                    bill.Month.ToString("MM/yyyy"),
                    bill.RoomPrice.ToString("N0"), // Lấy giá phòng từ database
                    $"Mới: {bill.ElectricNew} - Cũ: {bill.ElectricOld}",
                    ((bill.ElectricNew - bill.ElectricOld) * 3500).ToString("N0"),
                    $"Mới: {bill.WaterNew} - Cũ: {bill.WaterOld}", // Chỉ số nước
                    ((bill.WaterNew - bill.WaterOld) * 15000).ToString("N0"), // Tiền nước (giả sử 15k)
                    bill.Total.ToString("N0"),
                    bill.Notes ?? "", // Nhét ghi chú vào đây
                    bill.CreatedBy
                                );

                
                this.reportViewer1.LocalReport.ReportPath = @"Reports\rptHoaDon.rdlc";

                this.reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                this.reportViewer1.LocalReport.DataSources.Add(rds);

                this.reportViewer1.RefreshReport();
            }
        }
    }
}
