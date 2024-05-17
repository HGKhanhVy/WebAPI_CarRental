using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.Models.QuanLyChuyenKhoan
{
    public class QuanLyChuyenKhoanModel
    {
        public string IDQuanLyCK { get; set; }
        public string? NDChuyenKhoanKyGui { get; set; }
        public string? NDChuyenKhoanThue { get; set; }
        public string? NDChuyenKhoanCoc { get; set; }
    }
}
