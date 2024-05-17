using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Repository.Models
{
    [Table("Room")]
    public class RoomEntity : Entity
    {
        // Khóa chính
        public string IDRoom { get; set; }

        // Khóa ngoại NhanVien
        public string IDNhanVien { get; set; }
        public virtual NhanVienEntity NhanViens { get; set; }

        // Khóa ngoại KhachHang
        public string IDKhachHang { get; set; }
        public virtual KhachHangEntity KhachHangs { get; set; }
        public DateTime ThoiGianRoom { get; set; }
    }
}
