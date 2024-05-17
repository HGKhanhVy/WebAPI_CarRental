using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.Models.Xe
{
    public class XeModel
    {
        // Khóa chính
        public string IDXe { get; set; }

        // Khóa ngoại LoaiXe
        public string IDLoaiXe { get; set; }

        public string? TruyenDong { get; set; }
        public string? NhienLieu { get; set; }
        public string? NguyenLieuTieuHao { get; set; }
        public string TenXe { get; set; }
        public string BienSoXe { get; set; }
        public string HangXe { get; set; }
        public int NamSanXuat { get; set; }
        public int SoChoNgoi { get; set; }
        public double GiaThue { get; set; }
        public string? MoTa { get; set; }
    }
}
