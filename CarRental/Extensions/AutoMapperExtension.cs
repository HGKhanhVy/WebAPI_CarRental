using CarRental.Mapper;

namespace CarRental.WebApi.Extensions
{
    public static class AutoMapperExtension
    {
        public static IServiceCollection AddAutoMapperServices(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile(new ChucVuProfile());
                cfg.AddProfile(new HoaDonKyGuiProfile());
                cfg.AddProfile(new HoaDonThueXeProfile());
                cfg.AddProfile(new HopDongKyGuiProfile());
                cfg.AddProfile(new HopDongThueXeProfile());
                cfg.AddProfile(new KhachHangProfile());
                cfg.AddProfile(new KhuyenMaiProfile());
                cfg.AddProfile(new KMLoaiKHProfile());
                cfg.AddProfile(new KMLoaiXeProfile());
                cfg.AddProfile(new KMTrenHoaDonProfile());
                cfg.AddProfile(new KMVoucherProfile());
                cfg.AddProfile(new LichXeProfile());
                cfg.AddProfile(new LoaiKhachHangProfile());
                cfg.AddProfile(new LoaiXeProfile());
                cfg.AddProfile(new NhanVienProfile());
                cfg.AddProfile(new PhongBanProfile());
                cfg.AddProfile(new ThamDinhXeProfile());
                cfg.AddProfile(new ThanhLyHopDongProfile());
                cfg.AddProfile(new TienNghiProfile());
                cfg.AddProfile(new TrangThaiBaoDuongProfile());
                cfg.AddProfile(new XeProfile());
                cfg.AddProfile(new XeTienNghiProfile());
                cfg.AddProfile(new TinTucProfile());
            });
            return services;
        }
    }
}
