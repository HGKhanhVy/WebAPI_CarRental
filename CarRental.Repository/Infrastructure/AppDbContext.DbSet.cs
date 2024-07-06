using Microsoft.EntityFrameworkCore;
using CarRental.Contract.Repository.Models;

namespace CarRental.Repository.Infrastructure
{
    public sealed partial class AppDbContext
    {
        public DbSet<ChucVuEntity> ChucVu { get; set; }
        public DbSet<HoaDonKyGuiEntity> HoaDonKyGui { get; set; }
        public DbSet<HoaDonThueXeEntity> HoaDonThueXe { get; set; }
        public DbSet<HopDongKyGuiEntity> HopDongKyGui { get; set; }
        public DbSet<HopDongThueXeEntity> HopDongThueXe { get; set; }
        public DbSet<KhachHangEntity> KhachHang { get; set; }
        public DbSet<KhuyenMaiEntity> KhuyenMai { get; set; }
        public DbSet<KMLoaiKHEntity> KMLoaiKH { get; set; }
        public DbSet<KMLoaiXeEntity> KMLoaiXe { get; set; }
        public DbSet<KMTrenHoaDonEntity> KMTrenHoaDon { get; set; }
        public DbSet<KMVoucherEntity> KMVoucher { get; set; }
        public DbSet<LichXeEntity> LichXe { get; set; }
        public DbSet<LoaiKhachHangEntity> LoaiKhachHang { get; set; }
        public DbSet<LoaiXeEntity> LoaiXe { get; set; }
        public DbSet<NhanVienEntity> NhanVien { get; set; }
        public DbSet<PhongBanEntity> PhongBan { get; set; }
        public DbSet<ThamDinhXeEntity> ThamDinhXe { get; set; }
        public DbSet<ThanhLyHopDongEntity> ThanhLyHopDong { get; set; }
        public DbSet<TienNghiEntity> TienNghi { get; set; }
        public DbSet<TrangThaiBaoDuongEntity> TrangThaiBaoDuong { get; set; }
        public DbSet<XeEntity> Xe { get; set; }
        public DbSet<XeTienNghiEntity> XeTienNghi { get; set; }
        public DbSet<TinTucEntity> TinTuc { get; set; }
    }
}
