using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Repository.Models
{
    [Table("LoaiKhachHang")]
    public class LoaiKhachHangEntity : Entity
    {
        // Khóa chính
        public string IDLoaiKH { get; set; }
        public string TenLoaiKH { get; set; }

        public KMLoaiKHEntity KMLoaiKHs { get; set; }
        public virtual ICollection<KhachHangEntity>? KhachHangs { get; set; }
    }
}
