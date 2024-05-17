using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Repository.Models
{
    [Table("NhanVien")]
    public class NhanVienEntity : Entity
    {
        // Khóa chính
        public string IDNhanVien { get; set; }

        // Khóa ngoại ChucVu
        public string IDChucVu { get; set; }
        public virtual ChucVuEntity ChucVus { get; set; }

        // Khóa ngoại PhongBan
        public string IDPhongBan { get; set; }
        public virtual PhongBanEntity PhongBans { get; set; }

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

        public virtual ICollection<HopDongThueXeEntity>? HopDongThueXes { get; set; }
        public virtual ICollection<HopDongKyGuiEntity>? HopDongKyGuis { get; set; }
        public virtual ICollection<RoomEntity>? Rooms { get; set; }
        public virtual ICollection<ThamDinhXeEntity>? ThamDinhXes { get; set; }
        public virtual ICollection<ThanhLyHopDongEntity>? ThanhLyHopDongs { get; set; }
    }
}
