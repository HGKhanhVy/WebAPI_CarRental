using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.Models.ThanhLyHopDong
{
    public class ThanhLyHopDongModel
    {
        // Khóa chính
        public string IDThanhLy { get; set; }

        // Khóa ngoại NhanVien
        public string IDNhanVien { get; set; }

        public string TenThanhLy { get; set; }
        public DateTime NgayThanhLy { get; set; }
        public bool XacNhanCuaAdmin { get; set; }
        public bool XacNhanThamDinh { get; set; }
    }
}
