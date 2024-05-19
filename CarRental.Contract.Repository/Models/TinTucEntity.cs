using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Repository.Models
{
    [Table("TinTuc")]
    public class TinTucEntity : Entity
    {
        // Khóa chính
        public string IDTinTuc { get; set; }
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public string HinhAnh { get; set; }
        public string NguoiTao { get; set; }
        public DateTime NgayTao { get; set; }
    }
}
