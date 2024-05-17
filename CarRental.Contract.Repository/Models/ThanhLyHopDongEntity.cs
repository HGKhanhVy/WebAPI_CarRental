using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Repository.Models
{
    [Table("ThanhLyHopDong")]
    public class ThanhLyHopDongEntity : Entity
    {
        // Khóa chính
        public string IDThanhLy { get; set; }

        // Khóa ngoại NhanVien
        public string IDNhanVien { get; set; }
        public virtual NhanVienEntity NhanViens { get; set; }

        // Khóa chính của hợp đồng Thuê - Gửi (thêm lúc tạo hợp đồng)
        public string TenThanhLy { get; set; }
        public DateTime NgayThanhLy { get; set; }
        public bool XacNhanCuaAdmin { get; set; }
        public bool XacNhanThamDinh { get; set; }

    }
}
