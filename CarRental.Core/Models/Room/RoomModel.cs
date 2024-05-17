using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.Models.Room
{
    public class RoomModel
    {
        // Khóa chính
        public string IDRoom { get; set; }

        // Khóa ngoại NhanVien
        public string IDNhanVien { get; set; }

        // Khóa ngoại KhachHang
        public string IDKhachHang { get; set; }
        public DateTime ThoiGianRoom { get; set; }
    }
}
