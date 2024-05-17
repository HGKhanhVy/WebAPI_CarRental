using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Repository.Models
{
    [Table("HopDongThueXe")]
    public class HopDongThueXeEntity : Entity
    {
        // Khóa chính
        public string IDHopDongThueXe { get; set; }
        public string SoHopDong { get; set; }

        // Khóa ngoại KhachHang
        public string IDKhachHang { get; set; }
        public virtual KhachHangEntity KhachHangs { get; set; }

        // Khóa ngoại NhanVien
        public string IDNhanVien { get; set; }
        public virtual NhanVienEntity NhanViens { get; set; }

        // Khóa ngoại Xe 1-1
        public string IDXe { get; set; }
        public XeEntity Xes { get; set; }

        public DateTime NgayLap { get; set; }
        public double GiaThue { get; set; }
        public double SoTienCoc { get; set; }
        public double TongThanhTienDuKien { get; set; }
        public double TongThanhTienDuKienSauKM { get; set; }
        public double TienThanhToanTheoDot { get; set; }
        public double TienThanhToanTheoDotChuaKM { get; set; }
        public string PhuongThucThanhToan { get; set; }
        public string DinhKyThanhToan { get; set; }
        public int ThoiDiemThanhToan { get; set; }
        public DateTime NgayHieuLuc { get; set; }
        public DateTime NgayHetHan { get; set; }
        public bool XacNhan { get; set; }
        public string HinhAnhHopDong { get; set; }

        // Cho tick chọn (lấy từ các bảng khuyến mãi => lấy khóa chính lưu vào)
        public string? IDKMLoaiKH { get; set; }
        public string? IDKMLoaiXe { get; set; }
        public string? IDKMVoucher { get; set; }
        public string? IDKMTrenHoaDon { get; set; }

        public string? TenKMLoaiKH { get; set; }
        public string? TenKMLoaiXe { get; set; }
        public string? TenKMVoucher { get; set; }
        public string? VoucherCode { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }

        public virtual ICollection<HoaDonThueXeEntity>? HoaDonThueXes { get; set; }
    }
}
