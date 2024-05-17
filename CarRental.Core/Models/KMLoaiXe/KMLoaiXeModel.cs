using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.Models.KMLoaiXe
{
    public class KMLoaiXeModel
    {
        // Khóa ngoại bảng KhuyenMai + là khóa chính
        public string IDKhuyenMai { get; set; }

        // Khóa ngoại bảng LoaiXe
        public string IDLoaiXe { get; set; }

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
