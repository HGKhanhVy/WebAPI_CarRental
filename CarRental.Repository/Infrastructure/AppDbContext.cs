using Invedia.DI.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using CarRental.Contract.Repository.Infrastructure;
using CarRental.Repository.Base;
using System.Reflection;
using CarRental.Core.Utils;
using CarRental.Core.Configs;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using CarRental.Contract.Repository.Models;

namespace CarRental.Repository.Infrastructure
{
    [ScopedDependency(ServiceType = typeof(IDbContext))]
    public sealed partial class AppDbContext : BaseDbContext
    {
        public static readonly ILoggerFactory LoggerFactory = Microsoft.Extensions.Logging.LoggerFactory.Create(
            builder =>
            {
                builder
                    .AddFilter((category, level) =>
                        category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information)
                    .AddConsole();
            });

        public readonly int CommandTimeoutInSecond = 20 * 60;

        public AppDbContext() : base()
        {
            Database.SetCommandTimeout(CommandTimeoutInSecond);
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.SetCommandTimeout(CommandTimeoutInSecond);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                /*  var configuration = new ConfigurationBuilder()
                      .SetBasePath(Directory.GetCurrentDirectory())
                      .AddJsonFile("appsettings.Development.json")
                      .Build();
                  var connectionString = configuration.GetConnectionString("DefaultConnection");*/
                // data source = KHANHVY\SQLEXPRESS; initial catalog = DB_WeddingRestaurant; user id = sa; password =<< YourPassword >>
                var connectionString = SystemHelper.AppDb;
                connectionString = "Data Source=KHANHVY;initial Catalog=DB_CarRental;user=sa;pwd=123;Trusted_Connection=True;Trust Server Certificate=True; Integrated Security=false";

                optionsBuilder.UseSqlServer(connectionString, sqlServerOptionsAction =>
                {
                    sqlServerOptionsAction.MigrationsAssembly(
                        typeof(AppDbContext).GetTypeInfo().Assembly.GetName().Name);

                    sqlServerOptionsAction.MigrationsHistoryTable("Migration");
                });
                optionsBuilder.UseLoggerFactory(LoggerFactory);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Xóa theo quan hệ cha con: .OnDelete(DeleteBehavior.Cascade)

            // ChucVu
            modelBuilder.Entity<ChucVuEntity>()
                .HasKey(d => d.IDChucVu);

            // HoaDonKyGui
            modelBuilder.Entity<HoaDonKyGuiEntity>()
                .HasKey(e => new { e.IDHoaDonKyGui });
            modelBuilder.Entity<HoaDonKyGuiEntity>()
                .HasOne(c => c.HopDongKyGuis)
                .WithMany(t => t.HoaDonKyGuis)
                .HasForeignKey(c => c.IDHopDongKyGui)
                .OnDelete(DeleteBehavior.Cascade);

            // HoaDonThueXe
            modelBuilder.Entity<HoaDonThueXeEntity>()
                .HasKey(e => new { e.IDHoaDonThueXe });
            modelBuilder.Entity<HoaDonThueXeEntity>()
                .HasOne(c => c.HopDongThueXes)
                .WithMany(t => t.HoaDonThueXes)
                .HasForeignKey(c => c.IDHopDongThueXe)
                .OnDelete(DeleteBehavior.Cascade);

            // HopDongKyGui
            modelBuilder.Entity<HopDongKyGuiEntity>()
                .HasKey(e => new { e.IDHopDongKyGui });
            modelBuilder.Entity<HopDongKyGuiEntity>()
                .HasOne(c => c.KhachHangs)
                .WithMany(t => t.HopDongKyGuis)
                .HasForeignKey(c => c.IDKhachHang)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<HopDongKyGuiEntity>()
                .HasOne(c => c.NhanViens)
                .WithMany(t => t.HopDongKyGuis)
                .HasForeignKey(c => c.IDNhanVien)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<HopDongKyGuiEntity>()
                .HasOne(c => c.Xes)
                .WithMany(t => t.HopDongKyGuis)
                .HasForeignKey(c => c.IDXe)
                .OnDelete(DeleteBehavior.Cascade);

            // HopDongThueXe
            modelBuilder.Entity<HopDongThueXeEntity>()
                .HasKey(e => new { e.IDHopDongThueXe });
            modelBuilder.Entity<HopDongThueXeEntity>()
                .HasOne(c => c.KhachHangs)
                .WithMany(t => t.HopDongThueXes)
                .HasForeignKey(c => c.IDKhachHang)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<HopDongThueXeEntity>()
                .HasOne(c => c.NhanViens)
                .WithMany(t => t.HopDongThueXes)
                .HasForeignKey(c => c.IDNhanVien)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<HopDongThueXeEntity>()
                .HasOne(c => c.Xes)
                .WithMany(t => t.HopDongThueXes)
                .HasForeignKey(c => c.IDXe)
                .OnDelete(DeleteBehavior.Cascade);

            // KhachHang
            modelBuilder.Entity<KhachHangEntity>()
                .HasKey(e => new { e.IDKhachHang });
            modelBuilder.Entity<KhachHangEntity>()
                .HasOne(c => c.LoaiKhachHangs)
                .WithMany(t => t.KhachHangs)
                .HasForeignKey(c => c.IDLoaiKH)
                .OnDelete(DeleteBehavior.Cascade);

            // KhuyenMai
            modelBuilder.Entity<KhuyenMaiEntity>()
                .HasKey(e => new { e.IDKhuyenMai });

            // KMLoaiKH
            modelBuilder.Entity<KMLoaiKHEntity>()
                .HasKey(e => new { e.IDKhuyenMai });
            modelBuilder.Entity<KMLoaiKHEntity>()
                .HasOne(c => c.KhuyenMais)
                .WithMany(t => t.KMLoaiKHs)
                .HasForeignKey(c => c.IDKhuyenMai)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<KMLoaiKHEntity>()
                .HasOne(c => c.LoaiKhachHangs)
                .WithMany(t => t.KMLoaiKHs)
                .HasForeignKey(c => c.IDLoaiKH)
                .OnDelete(DeleteBehavior.Cascade);

            // KMLoaiXe
            modelBuilder.Entity<KMLoaiXeEntity>()
                .HasKey(e => new { e.IDKhuyenMai });
            modelBuilder.Entity<KMLoaiXeEntity>()
                .HasOne(c => c.KhuyenMais)
                .WithMany(t => t.KMLoaiXes)
                .HasForeignKey(c => c.IDKhuyenMai)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<KMLoaiXeEntity>()
                .HasOne(c => c.LoaiXes)
                .WithMany(t => t.KMLoaiXes)
                .HasForeignKey(c => c.IDLoaiXe)
                .OnDelete(DeleteBehavior.Cascade);

            // KMTrenHoaDon
            modelBuilder.Entity<KMTrenHoaDonEntity>()
                .HasKey(e => new { e.IDKhuyenMai });
            modelBuilder.Entity<KMTrenHoaDonEntity>()
                .HasOne(c => c.KhuyenMais)
                .WithMany(t => t.KMTrenHoaDons)
                .HasForeignKey(c => c.IDKhuyenMai)
                .OnDelete(DeleteBehavior.Cascade);

            // KMVoucher
            modelBuilder.Entity<KMVoucherEntity>()
               .HasKey(e => new { e.IDKhuyenMai });
            modelBuilder.Entity<KMVoucherEntity>()
                .HasOne(c => c.KhuyenMais)
                .WithMany(t => t.KMVouchers)
                .HasForeignKey(c => c.IDKhuyenMai)
                .OnDelete(DeleteBehavior.Cascade);

            // LichXe
            modelBuilder.Entity<LichXeEntity>()
               .HasKey(e => new { e.IDLichXe });
            modelBuilder.Entity<LichXeEntity>()
                .HasOne(c => c.Xes)
                .WithMany(t => t.LichXes)
                .HasForeignKey(c => c.IDXe)
                .OnDelete(DeleteBehavior.Cascade);

            // LoaiKhachHang
            modelBuilder.Entity<LoaiKhachHangEntity>()
               .HasKey(e => new { e.IDLoaiKH });

            // LoaiXe
            modelBuilder.Entity<LoaiXeEntity>()
               .HasKey(e => new { e.IDLoaiXe });

            // NhanVien
            modelBuilder.Entity<NhanVienEntity>()
               .HasKey(e => new { e.IDNhanVien });
            modelBuilder.Entity<NhanVienEntity>()
                .HasOne(c => c.ChucVus)
                .WithMany(t => t.NhanViens)
                .HasForeignKey(c => c.IDChucVu)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<NhanVienEntity>()
                .HasOne(c => c.PhongBans)
                .WithMany(t => t.NhanViens)
                .HasForeignKey(c => c.IDPhongBan)
                .OnDelete(DeleteBehavior.Cascade);

            // PhongBan
            modelBuilder.Entity<PhongBanEntity>()
               .HasKey(e => new { e.IDPhongBan });

            // ThamDinhXe
            modelBuilder.Entity<ThamDinhXeEntity>()
               .HasKey(e => new { e.IDThamDinh });
            modelBuilder.Entity<ThamDinhXeEntity>()
                .HasOne(c => c.NhanViens)
                .WithMany(t => t.ThamDinhXes)
                .HasForeignKey(c => c.IDNhanVien)
                .OnDelete(DeleteBehavior.Cascade);

            // ThanhLyHopDong
            modelBuilder.Entity<ThanhLyHopDongEntity>()
               .HasKey(e => new { e.IDThanhLy });
            modelBuilder.Entity<ThanhLyHopDongEntity>()
                .HasOne(c => c.NhanViens)
                .WithMany(t => t.ThanhLyHopDongs)
                .HasForeignKey(c => c.IDNhanVien)
                .OnDelete(DeleteBehavior.Cascade);

            // TienNghi
            modelBuilder.Entity<TienNghiEntity>()
               .HasKey(e => new { e.IDTienNghi });

            // TrangThaiBaoDuong
            modelBuilder.Entity<TrangThaiBaoDuongEntity>()
               .HasKey(e => new { e.IDTrangThaiBD });
            modelBuilder.Entity<TrangThaiBaoDuongEntity>()
                .HasOne(c => c.Xes)
                .WithMany(t => t.TrangThaiBaoDuongs)
                .HasForeignKey(c => c.IDXe)
                .OnDelete(DeleteBehavior.Cascade);

            // Xe
            modelBuilder.Entity<XeEntity>()
               .HasKey(e => new { e.IDXe });
            modelBuilder.Entity<XeEntity>()
                .HasOne(c => c.LoaiXes)
                .WithMany(t => t.Xes)
                .HasForeignKey(c => c.IDLoaiXe)
                .OnDelete(DeleteBehavior.Cascade);

            // XeTienNghi
            modelBuilder.Entity<XeTienNghiEntity>()
               .HasKey(e => new { e.IDXe, e.IDTienNghi });
            modelBuilder.Entity<XeTienNghiEntity>()
                .HasOne(c => c.Xes)
                .WithMany(t => t.XeTienNghis)
                .HasForeignKey(c => c.IDXe)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<XeTienNghiEntity>()
               .HasOne(c => c.TienNghis)
               .WithMany(t => t.XeTienNghis)
               .HasForeignKey(c => c.IDTienNghi)
               .OnDelete(DeleteBehavior.Cascade);

            // TinTuc
            modelBuilder.Entity<TinTucEntity>()
               .HasKey(e => new { e.IDTinTuc });
        }
    }
}
