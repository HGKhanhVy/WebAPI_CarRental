using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Repository.Models
{
    [Table("ChucVu")]
    public class ChucVuEntity : Entity
    {
        // Khóa chính
        public string IDChucVu { get; set; }
        public string TenChucVu { get; set; }
        public double MucLuongTheoChucVu { get; set; }
        public double PhanTramMuc1 { get; set; }
        public virtual ICollection<NhanVienEntity>? NhanViens { get; set; }
    }
}
