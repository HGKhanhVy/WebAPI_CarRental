using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.Models.HopDongKyGui
{
    public class HopDongKyGuiCreate
    {
        // Khóa chính
        public string IDHopDongKyGui { get; set; }
        public string SoHopDong { get; set; }

        // Khóa ngoại KhachHang
        public string IDKhachHang { get; set; }

        // Khóa ngoại NhanVien
        public string IDNhanVien { get; set; }


        // Khóa ngoại Xe 1-1
        public string IDXe { get; set; }

        public DateTime NgayLap { get; set; }
        public double PhanTramHoaHong { get; set; }
        public string PhuongThucThanhToan { get; set; }
        public string DinhKyThanhToan { get; set; }
        public int ThoiDiemThanhToan { get; set; }
        public DateTime NgayHieuLuc { get; set; }
        public DateTime NgayHetHan { get; set; }
        public bool XacNhan { get; set; }
        public string HinhAnhHopDong { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }

        //Xe
        public string IDLoaiXe { get; set; }

        public string? TruyenDong { get; set; }
        public string? NhienLieu { get; set; }
        public string? NguyenLieuTieuHao { get; set; }
        public string TenXe { get; set; }
        public string BienSoXe { get; set; }
        public string HangXe { get; set; }
        public int NamSanXuat { get; set; }
        public int SoChoNgoi { get; set; }
        public double GiaThue { get; set; }
        public string? MoTa { get; set; }
        public string? HinhAnh1 { get; set; }
        public string? HinhAnh2 { get; set; }
        public string? HinhAnh3 { get; set; }
        public string? HinhAnh4 { get; set; }

        public string[] IDTienNghi { get; set; }
    }
}
