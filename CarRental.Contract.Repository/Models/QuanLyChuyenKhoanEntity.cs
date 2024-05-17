using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Repository.Models
{
    [Table("QuanLyChuyenKhoan")]
    public class QuanLyChuyenKhoanEntity : Entity
    {
        // Khóa chính
        public string IDQuanLyCK { get; set; }
        public string? NDChuyenKhoanKyGui { get; set; }
        public string? NDChuyenKhoanThue { get; set; }
        public string? NDChuyenKhoanCoc { get; set; }
    }
}
