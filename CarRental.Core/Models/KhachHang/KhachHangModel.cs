using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.Models.KhachHang
{
    public class KhachHangModel
    {
        // Khóa chính
        public string IDKhachHang { get; set; }

        // Khóa ngoại LoaiKhachHang
        public string IDLoaiKH { get; set; }

        public string HoTen { get; set; }
        public string NgaySinh { get; set; }
        public string CCCD { get; set; }
        public string GPLX { get; set; }
        public string SoPassPort { get; set; }
        public string DiaChiThuongTru { get; set; }
        public string DiaChiHienTai { get; set; }
        public string SoDienThoai { get; set; }
        public string? SoDienThoaiDuPhong { get; set; }
        public string? SoDienThoaiNguoiThamChieu { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public string SoTaiKhoan { get; set; }
        public string NganHang { get; set; }
        public string ChiNhanhNganHang { get; set; }
    }
}
