using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Repository.Models
{
    [Table("KMLoaiXe")]
    public class KMLoaiXeEntity : Entity
    {
        // Khóa ngoại bảng KhuyenMai + là khóa chính
        public string IDKhuyenMai { get; set; }
        public virtual KhuyenMaiEntity KhuyenMais { get; set; }

        // Khóa ngoại bảng LoaiXe
        public string IDLoaiXe { get; set; }
        public LoaiXeEntity LoaiXes { get; set; }

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
