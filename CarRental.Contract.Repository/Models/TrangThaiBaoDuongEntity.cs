using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Repository.Models
{
    [Table("TrangThaiBaoDuong")]
    public class TrangThaiBaoDuongEntity : Entity
    {
        // Khóa chính
        public string IDTrangThaiBD { get; set; }

        // Khóa ngoại Xe
        public string IDXe { get; set; }
        public virtual XeEntity Xes { get; set; }

        public string NDBaoDuong { get; set; }
        public DateTime NgayBaoDuong { get; set; }
        public string HinhAnhHoaDonBD { get; set; }
    }
}
