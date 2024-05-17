using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Repository.Models
{
    [Table("KhuyenMai")]
    public class KhuyenMaiEntity : Entity
    {
        // Khóa chính
        public string IDKhuyenMai { get; set; }
        public string TenCTKM { get; set; }
        public DateTime ThoiGianBatDau { get; set; }
        public DateTime ThoiGianKetThuc { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }

        // Khóa ngoại 1-n
        public virtual ICollection<KMLoaiKHEntity>? KMLoaiKHs { get; set; }
        public virtual ICollection<KMLoaiXeEntity>? KMLoaiXes { get; set; }
        public virtual ICollection<KMVoucherEntity>? KMVouchers { get; set; }
        public virtual ICollection<KMTrenHoaDonEntity>? KMTrenHoaDons { get; set; }
    }
}
