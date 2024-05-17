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
        public DbSet<NhacHenEntity> NhacHen { get; set; }
        public DbSet<NhanVienEntity> NhanVien { get; set; }
        public DbSet<PermissionDetailEntity> PermissionDetail { get; set; }
        public DbSet<PermissionEntity> Permission { get; set; }
        public DbSet<PhongBanEntity> PhongBan { get; set; }
        public DbSet<QuanLyChuyenKhoanEntity> QuanLyChuyenKhoan { get; set; }
        public DbSet<RoomEntity> Room { get; set; }
        public DbSet<SoDienThoaiEntity> SoDienThoai { get; set; }
        public DbSet<ThamDinhXeEntity> ThamDinhXe { get; set; }
        public DbSet<ThanhLyHopDongEntity> ThanhLyHopDong { get; set; }
        public DbSet<TienNghiEntity> TienNghi { get; set; }
        public DbSet<TrangThaiBaoDuongEntity> TrangThaiBaoDuong { get; set; }
        public DbSet<UserPermissionEntity> UserPermission { get; set; }
        public DbSet<UserEntity> User { get; set; }
        public DbSet<XeEntity> Xe { get; set; }
        public DbSet<XeTienNghiEntity> XeTienNghi { get; set; }
        public DbSet<RefreshTokenEntity> RefreshToken { get; set; }
        public DbSet<AccessTokenEntity> AccessToken { get; set; }
    }
}
