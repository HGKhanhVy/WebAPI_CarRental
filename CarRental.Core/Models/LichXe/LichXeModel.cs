using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.Models.LichXe
{
    public class LichXeModel
    {
        // Khóa chính
        public string IDLichXe { get; set; }

        // Khóa ngoại Xe
        public string IDXe { get; set; }

        public DateTime ThoiGianBatDau { get; set; }
        public DateTime ThoiGianKetThuc { get; set; }
    }
}
