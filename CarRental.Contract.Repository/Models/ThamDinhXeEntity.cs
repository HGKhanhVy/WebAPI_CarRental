using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Repository.Models
{
    [Table("ThamDinhXe")]
    public class ThamDinhXeEntity : Entity
    {
        // Khóa chính
        public string IDThamDinh { get; set; }

        // Khóa ngoại NhanVien
        public string IDNhanVien { get; set; }
        public virtual NhanVienEntity NhanViens { get; set; }

        // Khóa chính của hợp đồng Thuê - Gửi (thêm lúc tạo hợp đồng)
        public string TenThamDinh { get; set; }

        // Truy vấn từ khóa chính của hợp đồng Thuê - Gửi (TenThamDinh)
        public string IDXe { get; set; }
        public string IDKhachHang { get; set; }

        public DateTime NgayThamDinh { get; set; }
        public string BienBanThamDinh { get; set; }
        public string NoiDungHoSoXe { get; set; }
        public string TinhTrangNgoaiThat { get; set; }
        public string TinhTrangNoiThat { get; set; }
        public string HeThongDongCo { get; set; }
        public string HeThongTreo { get; set; }
        public string HeThongPhanh { get; set; }
    }
}
