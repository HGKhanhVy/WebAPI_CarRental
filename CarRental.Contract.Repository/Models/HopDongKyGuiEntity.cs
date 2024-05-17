using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Repository.Models
{
    [Table("HopDongKyGui")]
    public class HopDongKyGuiEntity : Entity
    {
        // Khóa chính
        public string IDHopDongKyGui { get; set; }
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

        public virtual ICollection<HoaDonKyGuiEntity>? HoaDonKyGuis { get; set; }
    }
}
