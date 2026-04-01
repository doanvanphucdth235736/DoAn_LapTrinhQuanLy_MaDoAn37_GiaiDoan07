using System;
using System.Collections.Generic;

namespace QuanLyPhongTroTheoThang.Data
{
    public class Tenant
    {
        public int TenantID { get; set; }
        public string TenantName { get; set; }
        public string Phone { get; set; }
        public string CCCD { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
