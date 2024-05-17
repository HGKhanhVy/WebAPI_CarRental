using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Repository.Models
{
    [Table("HoaDonThueXe")]
    public class HoaDonThueXeEntity : Entity
    {
        // Khóa chính
        public string IDHoaDonThueXe { get; set; }

        // Khóa ngoại HopDongThueXe
        public string IDHopDongThueXe { get; set; }
        public virtual HopDongThueXeEntity HopDongThueXes { get; set; }

        public string SoHoaDon { get; set; } // tự tăng theo cấu trúc

        // Truy vấn từ bảng HopDongThueXe
        public string IDKhachHang { get; set; }
        public string IDNhanVien { get; set; }

        public DateTime NgayLap { get; set; }
        public double TongThanhToan { get; set; }
        public double TongThanhToanChuaKM { get; set; }
        public string TrangThaiThanhToan { get; set; }
        public string HinhThucThanhToan { get; set; }
        public string HinhAnhThanhToan { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
