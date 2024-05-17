using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Repository.Models
{
    [Table("KMLoaiKH")]
    public class KMLoaiKHEntity : Entity
    {
        // Khóa ngoại bảng KhuyenMai + là khóa chính
        public string IDKhuyenMai { get; set; }
        public virtual KhuyenMaiEntity KhuyenMais { get; set; } 

        // Khóa ngoại bảng LoaiKhachHang
        public string IDLoaiKH { get; set; }
        public LoaiKhachHangEntity LoaiKhachHangs { get; set; }

        public double? TyLePhanTram { get; set; }
        public double? SoTien { get; set; }
        public double SoTienToiDaDuocGiam { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateAt { get; set; }
        public string? DeleteBy { get; set; }
        public DateTime? DeleteAt { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
