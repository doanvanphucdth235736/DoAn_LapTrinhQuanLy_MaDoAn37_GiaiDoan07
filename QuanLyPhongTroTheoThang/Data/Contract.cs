using System;
using System.Collections.Generic;


namespace QuanLyPhongTroTheoThang.Data
{
    public class Contract
    {
        public int ContractID { get; set; }

        public int RoomID { get; set; }
        public int TenantID { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Deposit { get; set; }

        public int ElectricStart { get; set; }      
        public int WaterStart { get; set; }         
        public int PaymentDay { get; set; }         
        public string ContractStatus { get; set; }  
        public int NumberOfOccupants { get; set; }
        public string Notes { get; set; }

        public virtual Room Room { get; set; }
        public virtual Tenant Tenant { get; set; }
        public string CreatedBy { get; set; }

        public virtual ICollection<Bill> Bills { get; set; }
    }
}
