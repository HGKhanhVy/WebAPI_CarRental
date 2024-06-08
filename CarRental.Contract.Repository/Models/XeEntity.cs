using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Repository.Models
{
    [Table("Xe")]
    public class XeEntity : Entity
    {
        // Khóa chính
        public string IDXe { get; set; }

        // Khóa ngoại LoaiXe
        public string IDLoaiXe { get; set; }
        public virtual LoaiXeEntity LoaiXes { get; set; }

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
        public string? HinhAnh1 { get; set; }
        public string? HinhAnh2 { get; set; }
        public string? HinhAnh3 { get; set; }
        public string? HinhAnh4 { get; set; }

        public HopDongKyGuiEntity HopDongKyGuis { get; set; }
        public HopDongThueXeEntity HopDongThueXes { get; set; }
        public virtual ICollection<LichXeEntity>? LichXes { get; set; }
        public virtual ICollection<XeTienNghiEntity>? XeTienNghis { get; set; }
        public virtual ICollection<TrangThaiBaoDuongEntity>? TrangThaiBaoDuongs { get; set; }
    }
}
