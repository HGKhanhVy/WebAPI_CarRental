using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.Models.TrangThaiBaoDuong
{
    public class TrangThaiBaoDuongModel
    {
        // Khóa chính
        public string IDTrangThaiBD { get; set; }

        // Khóa ngoại Xe
        public string IDXe { get; set; }

        public string NDBaoDuong { get; set; }
        public DateTime NgayBaoDuong { get; set; }
        public string HinhAnhHoaDonBD { get; set; }
    }
}
