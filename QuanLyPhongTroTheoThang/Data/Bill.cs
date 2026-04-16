using System;

namespace QuanLyPhongTroTheoThang.Data
{
    public class Bill
    {
        public int BillID { get; set; }

        public int ContractID { get; set; } 
        public DateTime Month { get; set; }

        public int ElectricOld { get; set; }
        public int ElectricNew { get; set; }

        public int WaterOld { get; set; }
        public int WaterNew { get; set; }

        public decimal Total { get; set; }
        public bool Status { get; set; }
        public string Notes { get; set; }
        public decimal RoomPrice { get; set; }
        public string CreatedBy { get; set; }

        public virtual Contract Contract { get; set; }
    }
}
