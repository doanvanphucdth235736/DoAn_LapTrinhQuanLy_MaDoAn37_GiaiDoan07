using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongTroTheoThang.Data
{
    public class User
    {
        public int UserID { get; set; }
        public string FullName { get; set; }     
        public string Position { get; set; }    
        public string Username { get; set; }     
        public string Password { get; set; }    

        public string Role { get; set; }
    }
}
