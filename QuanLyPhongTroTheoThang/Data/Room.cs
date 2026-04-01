using System.Collections.Generic;

namespace QuanLyPhongTroTheoThang.Data
{
    public class Room
    {
        public int RoomID { get; set; }
        public string RoomName { get; set; }
        public decimal Price { get; set; }

        public string  Status { get; set; }

        public string ImagePath { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
    }
}