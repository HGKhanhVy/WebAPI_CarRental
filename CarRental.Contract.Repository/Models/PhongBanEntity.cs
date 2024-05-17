using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Repository.Models
{
    [Table("PhongBan")]
    public class PhongBanEntity : Entity
    {
        // Khóa chính
        public string IDPhongBan { get; set; }
        public string TenPhongBan { get; set; }
        public double PhanTramMuc1 { get; set; }
        public double PhanTramMuc2 { get; set; }
        public double PhanTramMuc3 { get; set; }
        public double PhanTramMuc4 { get; set; }
        public virtual ICollection<NhanVienEntity>? NhanViens { get; set; }
    }
}
