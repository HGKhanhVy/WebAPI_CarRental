using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.Models.NhanVien
{
    public class NhanVienModel
    {
        // Khóa chính
        public string IDNhanVien { get; set; }

        // Khóa ngoại ChucVu
        public string IDChucVu { get; set; }

        // Khóa ngoại PhongBan
        public string IDPhongBan { get; set; }

        public string HoTen { get; set; }
        public string NgaySinh { get; set; }
        public string CCCD { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public DateTime NgayVaoLam { get; set; }
        public DateTime? NgayNghiViec { get; set; } // Dùng khi xóa nhân viên
        public double HeSoLuong { get; set; }
        public string SoTaiKhoan { get; set; }
        public string NganHang { get; set; }
        public string ChiNhanhNganHang { get; set; }
    }
}
