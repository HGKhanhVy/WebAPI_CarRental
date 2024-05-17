namespace CarRental.Core.Constants
{
    public static class WebApiEndpoint
    {
        public const string AreaName = "api";

        public static class ChucVu
        {
            private const string BaseEndpoint = "~/" + AreaName + "/chuc-vu";
            public const string GetChucVu = BaseEndpoint + "/get-single" + "/{IDChucVu}";
            public const string GetAllChucVu = BaseEndpoint + "/get-all";
            public const string AddChucVu = BaseEndpoint + "/add";
            public const string UpdateChucVu = BaseEndpoint + "/update" + "/{IDChucVu}";
            public const string DeleteChucVu = BaseEndpoint + "/delete" + "/{IDChucVu}";
            public const string CountChucVu = BaseEndpoint + "/count-chuc-vu";
        }

        public static class HoaDonKyGui
        {
            private const string BaseEndpoint = "~/" + AreaName + "/hoadon-kygui";
            public const string GetHoaDonKyGui = BaseEndpoint + "/get-single" + "/{IDHoaDonKyGui}";
            public const string GetAllHoaDonKyGui = BaseEndpoint + "/get-all";
            public const string AddHoaDonKyGui = BaseEndpoint + "/add";
            public const string UpdateHoaDonKyGui = BaseEndpoint + "/update" + "/{IDHoaDonKyGui}";
            public const string DeleteHoaDonKyGui = BaseEndpoint + "/delete" + "/{IDHoaDonKyGui}";
            public const string CountHoaDonKyGui = BaseEndpoint + "/count-hoadon-kygui";
        }

        public class HoaDonThueXe
        {
            private const string BaseEndpoint = "~/" + AreaName + "/hoadon-thuexe";
            public const string GetHoaDonThueXe = BaseEndpoint + "/get-single" + "/{IDHoaDonThueXe}";
            public const string GetAllHoaDonThueXe = BaseEndpoint + "/get-all";
            public const string AddHoaDonThueXe = BaseEndpoint + "/add";
            public const string UpdateHoaDonThueXe = BaseEndpoint + "/update" + "/{IDHoaDonThueXe}";
            public const string DeleteHoaDonThueXe = BaseEndpoint + "/delete" + "/{IDHoaDonThueXe}";
            public const string CountHoaDonThueXe = BaseEndpoint + "/count-hoadon-thuexe" + "/{IDHoaDonThueXe}";
        }

        public class HopDongKyGui
        {
            private const string BaseEndpoint = "~/" + AreaName + "/hopdong-kygui";
            public const string GetHopDongKyGui = BaseEndpoint + "/get-single" + "/{IDHopDongKyGui}";
            public const string GetAllHopDongKyGui = BaseEndpoint + "/get-all";
            public const string AddHopDongKyGui = BaseEndpoint + "/add";
            public const string UpdateHopDongKyGui = BaseEndpoint + "/update" + "/{IDHopDongKyGui}";
            public const string DeleteHopDongKyGui = BaseEndpoint + "/delete" + "/{IDHopDongKyGui}";
            public const string CountHopDongKyGui = BaseEndpoint + "/count-hopdong-kygui" + "/{IDHopDongKyGui}";
        }

        public class HopDongThueXe
        {
            private const string BaseEndpoint = "~/" + AreaName + "/hopdong-thuexe";
            public const string GetHopDongThueXe = BaseEndpoint + "/get-single" + "/{IDHopDongThueXe}";
            public const string GetAllHopDongThueXe = BaseEndpoint + "/get-all";
            public const string AddHopDongThueXe = BaseEndpoint + "/add";
            public const string UpdateHopDongThueXe = BaseEndpoint + "/update" + "/{IDHopDongThueXe}";
            public const string DeleteHopDongThueXe = BaseEndpoint + "/delete" + "/{IDHopDongThueXe}";
            public const string CountHopDongThueXe = BaseEndpoint + "/count-hopdong-thuexe" + "/{IDHopDongThueXe}";
        }

        public static class KhachHang
        {
            private const string BaseEndpoint = "~/" + AreaName + "/khach-hang";
            public const string GetKhachHang = BaseEndpoint + "/get-single" + "/{IDKhachHang}";
            public const string GetKhachHangBySDT = BaseEndpoint + "/get-single" + "/{SoDienThoai}";
            public const string GetAllKhachHang = BaseEndpoint + "/get-all";
            public const string AddKhachHang = BaseEndpoint + "/add";
            public const string UpdateKhachHang = BaseEndpoint + "/update" + "/{IDKhachHang}";
            public const string DeleteKhachHang = BaseEndpoint + "/delete" + "/{IDKhachHang}";
            public const string CountKhachHang = BaseEndpoint + "/count-kh" + "/{IDKhachHang}";
            public const string KhachHangLogin = BaseEndpoint + "/kh-login" + "/{Email}-{PassWord}";
        }

        public class KhuyenMai
        {
            private const string BaseEndpoint = "~/" + AreaName + "/khuyen-mai";
            public const string GetKhuyenMai = BaseEndpoint + "/get-single" + "/{IDKhuyenMai}";
            public const string GetAllKhuyenMai = BaseEndpoint + "/get-all";
            public const string AddKhuyenMai = BaseEndpoint + "/add";
            public const string UpdateKhuyenMai = BaseEndpoint + "/update" + "/{IDKhuyenMai}";
            public const string DeleteKhuyenMai = BaseEndpoint + "/delete" + "/{IDKhuyenMai}";
            public const string PrintAllKhuyenMaiChuaHetHan = BaseEndpoint + "/print-khuyenmai-chua-het-han";
            public const string CountKhuyenMai = BaseEndpoint + "/count-khuyen-mai" + "/{IDKhuyenMai}";
        }

        public static class KMLoaiKH
        {
            private const string BaseEndpoint = "~/" + AreaName + "/km-loai-kh";
            public const string GetKMLoaiKH = BaseEndpoint + "/get-single" + "/{IDKhuyenMai}";
            public const string GetAllKMLoaiKH = BaseEndpoint + "/get-all";
            public const string AddKMLoaiKH = BaseEndpoint + "/add";
            public const string UpdateKMLoaiKH = BaseEndpoint + "/update" + "/{IDKhuyenMai}";
            public const string DeleteKMLoaiKH = BaseEndpoint + "/delete" + "/{IDKhuyenMai}";
            public const string DeleteKMLoaiKHByIDLoaiKH = BaseEndpoint + "/deleteByIDLoaiKH" + "/{IDLoaiKH}";
            public const string CountKMLoaiKH = BaseEndpoint + "/count-km-loai-kh";
            public const string PrintAllKMLoaiKHByIDLoaiKH = BaseEndpoint + "/print-khuyenmai-loai-kh-byid-loaikh" + "/{IDLoaiKH}";
            public const string UpdateStatus = BaseEndpoint + "/update-status";
        }

        public static class KMLoaiXe
        {
            private const string BaseEndpoint = "~/" + AreaName + "/km-loai-xe";
            public const string GetKMLoaiXe = BaseEndpoint + "/get-single" + "/{IDKhuyenMai}";
            public const string GetAllKMLoaiXe = BaseEndpoint + "/get-all";
            public const string AddKMLoaiXe = BaseEndpoint + "/add";
            public const string UpdateKMLoaiXe = BaseEndpoint + "/update" + "/{IDKhuyenMai}";
            public const string DeleteKMLoaiXe = BaseEndpoint + "/delete" + "/{IDKhuyenMai}";
            public const string DeleteKMLoaiXeByIDLoaiXe = BaseEndpoint + "/deleteByIDLoaiXe" + "/{IDLoaiXe}";
            public const string CountKMLoaiXe = BaseEndpoint + "/count-km-loai-xe";
            public const string PrintAllKMLoaiXeByIDLoaiXe = BaseEndpoint + "/print-khuyenmai-loai-xe-byid-loaixe" + "/{IDLoaiXe}";
            public const string UpdateStatus = BaseEndpoint + "/update-status";
        }

        public static class KMTrenHoaDon
        {
            private const string BaseEndpoint = "~/" + AreaName + "/km-tren-hoadon";
            public const string GetKMTrenHoaDon = BaseEndpoint + "/get-single" + "/{IDKhuyenMai}";
            public const string GetAllKMTrenHoaDon = BaseEndpoint + "/get-all";
            public const string AddKMTrenHoaDon = BaseEndpoint + "/add";
            public const string UpdateKMTrenHoaDon = BaseEndpoint + "/update" + "/{IDKhuyenMai}";
            public const string DeleteKMTrenHoaDon = BaseEndpoint + "/delete" + "/{IDKhuyenMai}";
            public const string CountKMTrenHoaDon = BaseEndpoint + "/count-km-tren-hoadon";
            public const string UpdateStatus = BaseEndpoint + "/update-status";
        }

        public static class KMVoucher
        {
            private const string BaseEndpoint = "~/" + AreaName + "/km-voucher";
            public const string GetKMVoucher = BaseEndpoint + "/get-single" + "/{IDKhuyenMai}";
            public const string GetAllKMVoucher = BaseEndpoint + "/get-all";
            public const string AddKMVoucher = BaseEndpoint + "/add";
            public const string UpdateKMVoucher = BaseEndpoint + "/update" + "/{IDKhuyenMai}";
            public const string DeleteKMVoucher = BaseEndpoint + "/delete" + "/{IDKhuyenMai}";
            public const string CountKMVoucher = BaseEndpoint + "/count-km-voucher";
            public const string PrintAllKMVoucherByIDCode = BaseEndpoint + "/print-km-voucher-bycode" + "/{IDCode}";
            public const string UpdateStatus = BaseEndpoint + "/update-status";
        }

        public static class LichXe
        {
            private const string BaseEndpoint = "~/" + AreaName + "/lich-xe";
            public const string GetLichXe = BaseEndpoint + "/get-single" + "/{IDLichXe}";
            public const string GetAllLichXe = BaseEndpoint + "/get-all";
            public const string AddLichXe = BaseEndpoint + "/add";
            public const string UpdateLichXe = BaseEndpoint + "/update" + "/{IDLichXe}";
            public const string DeleteLichXe = BaseEndpoint + "/delete" + "/{IDLichXe}";
            public const string PrintAllLichXeByIDXe = BaseEndpoint + "/print-lichxe-byidxe" + "/{IDXe}";
            public const string CountLichXe = BaseEndpoint + "/count-lich-xe" + "/{IDLichXe}";
            public const string UpdateStatus = BaseEndpoint + "/update-status";
        }

        public static class LoaiKhachHang
        {
            private const string BaseEndpoint = "~/" + AreaName + "/loai-kh";
            public const string GetLoaiKhachHang = BaseEndpoint + "/get-single" + "/{IDLoaiKH}";
            public const string GetAllLoaiKhachHang = BaseEndpoint + "/get-all";
            public const string AddLoaiKhachHang = BaseEndpoint + "/add";
            public const string UpdateLoaiKhachHang = BaseEndpoint + "/update" + "/{IDLoaiKH}";
            public const string DeleteLoaiKhachHang = BaseEndpoint + "/delete" + "/{IDLoaiKH}";
            public const string CountLoaiKhachHang = BaseEndpoint + "/count-loai-kh" + "/{IDLoaiKH}";
        }

        public static class LoaiXe
        {
            private const string BaseEndpoint = "~/" + AreaName + "/loai-xe";
            public const string GetLoaiXe = BaseEndpoint + "/get-single" + "/{IDLoaiXe}";
            public const string GetAllLoaiXe = BaseEndpoint + "/get-all";
            public const string AddLoaiXe = BaseEndpoint + "/add";
            public const string UpdateLoaiXe = BaseEndpoint + "/update" + "/{IDLoaiXe}";
            public const string DeleteLoaiXe = BaseEndpoint + "/delete" + "/{IDLoaiXe}";
            public const string CountLoaiXe = BaseEndpoint + "/count-loai-xe" + "/{IDLoaiXe}";
        }

        public static class NhacHen
        {
            private const string BaseEndpoint = "~/" + AreaName + "/nhac-hen";
            public const string GetNhacHen = BaseEndpoint + "/get-single" + "/{IDNhacHen}";
            public const string GetAllNhacHen = BaseEndpoint + "/get-all";
            public const string AddNhacHen = BaseEndpoint + "/add";
            public const string UpdateNhacHen = BaseEndpoint + "/update" + "/{IDNhacHen}";
            public const string DeleteNhacHen = BaseEndpoint + "/delete" + "/{IDNhacHen}";
            public const string CountNhacHen = BaseEndpoint + "/count-nhac-hen" + "/{IDNhacHen}";
        }

        public static class NhanVien
        {
            private const string BaseEndpoint = "~/" + AreaName + "/nhan-vien";
            public const string GetNhanVien = BaseEndpoint + "/get-single" + "/{IDNhanVien}";
            public const string GetAllNhanVien = BaseEndpoint + "/get-all";
            public const string AddNhanVien = BaseEndpoint + "/add";
            public const string UpdateNhanVien = BaseEndpoint + "/update" + "/{IDNhanVien}";
            public const string DeleteNhanVien = BaseEndpoint + "/delete" + "/{IDNhanVien}";
            public const string CountNhanVien = BaseEndpoint + "/count-nhan-vien" + "/{IDNhanVien}";
            public const string NhanVienLogin = BaseEndpoint + "/nv-login" + "/{Email}-{PassWord}";
        }

        public static class PermissionDetail
        {
            private const string BaseEndpoint = "~/" + AreaName + "/permission-detail";
            public const string GetPermissionDetail = BaseEndpoint + "/get-single" + "/{IDPermissionDetail}";
            public const string GetAllPermissionDetail = BaseEndpoint + "/get-all";
            public const string AddPermissionDetail = BaseEndpoint + "/add";
            public const string UpdatePermissionDetail = BaseEndpoint + "/update" + "/{IDPermissionDetail}";
            public const string DeletePermissionDetail = BaseEndpoint + "/delete" + "/{IDPermissionDetail}";
            public const string PrintAllPermissionDetailByIDPermission = BaseEndpoint + "/print-permission-detail-byid-permission" + "/{IDPermission}";
            public const string CountPermissionDetail = BaseEndpoint + "/count-permission-detail" + "/{IDPermissionDetail}";
        }

        public static class Permission
        {
            private const string BaseEndpoint = "~/" + AreaName + "/permission";
            public const string GetPermission = BaseEndpoint + "/get-single" + "/{IDPermission}";
            public const string GetAllPermission = BaseEndpoint + "/get-all";
            public const string AddPermission = BaseEndpoint + "/add";
            public const string UpdatePermission = BaseEndpoint + "/update" + "/{IDPermission}";
            public const string DeletePermission = BaseEndpoint + "/delete" + "/{IDPermission}";
            public const string CountPermission = BaseEndpoint + "/count-permission" + "/{IDPermission}";
        }

        public static class PhongBan
        {
            private const string BaseEndpoint = "~/" + AreaName + "/phong-ban";
            public const string GetPhongBan = BaseEndpoint + "/get-single" + "/{IDPhongBan}";
            public const string GetAllPhongBan = BaseEndpoint + "/get-all";
            public const string AddPhongBan = BaseEndpoint + "/add";
            public const string UpdatePhongBan = BaseEndpoint + "/update" + "/{IDPhongBan}";
            public const string DeletePhongBan = BaseEndpoint + "/delete" + "/{IDPhongBan}";
            public const string CountPhongBan = BaseEndpoint + "/count-phong-ban" + "/{IDPhongBan}";
        }

        public static class QuanLyChuyenKhoan
        {
            private const string BaseEndpoint = "~/" + AreaName + "/ql-chuyenkhoan";
            public const string GetQuanLyChuyenKhoan = BaseEndpoint + "/get-single" + "/{IDQuanLyCK}";
            public const string GetAllQuanLyChuyenKhoan = BaseEndpoint + "/get-all";
            public const string AddQuanLyChuyenKhoan = BaseEndpoint + "/add";
            public const string UpdateQuanLyChuyenKhoan = BaseEndpoint + "/update" + "/{IDQuanLyCK}";
            public const string DeleteQuanLyChuyenKhoan = BaseEndpoint + "/delete" + "/{IDQuanLyCK}";
            public const string CountQuanLyChuyenKhoan = BaseEndpoint + "/count-ql-chuyenkhoan" + "/{IDQuanLyCK}";
        }

        public static class Room
        {
            private const string BaseEndpoint = "~/" + AreaName + "/room";
            public const string GetRoom = BaseEndpoint + "/get-single" + "/{IDRoom}";
            public const string GetAllRoom = BaseEndpoint + "/get-all";
            public const string AddRoom = BaseEndpoint + "/add";
            public const string UpdateRoom = BaseEndpoint + "/update" + "/{IDRoom}";
            public const string DeleteRoom = BaseEndpoint + "/delete" + "/{IDRoom}";
            public const string CountRoom = BaseEndpoint + "/count-room" + "/{IDRoom}";
        }

        public static class SoDienThoai
        {
            private const string BaseEndpoint = "~/" + AreaName + "/dau-so";
            public const string GetDauSo = BaseEndpoint + "/get-single" + "/{DauSo}";
            public const string GetAllDauSo = BaseEndpoint + "/get-all";
            public const string AddDauSo = BaseEndpoint + "/add";
            public const string UpdateDauSo = BaseEndpoint + "/update" + "/{DauSo}";
            public const string DeleteDauSo = BaseEndpoint + "/delete" + "/{DauSo}";
        }

        public static class ThamDinhXe
        {
            private const string BaseEndpoint = "~/" + AreaName + "/tham-dinh-xe";
            public const string GetThamDinhXe = BaseEndpoint + "/get-single" + "/{IDThamDinh}";
            public const string GetAllThamDinhXe = BaseEndpoint + "/get-all";
            public const string AddThamDinhXe = BaseEndpoint + "/add";
            public const string UpdateThamDinhXe = BaseEndpoint + "/update" + "/{IDThamDinh}";
            public const string DeleteThamDinhXe = BaseEndpoint + "/delete" + "/{IDThamDinh}";
            public const string PrintAllThamDinhXeByIDNV = BaseEndpoint + "/print-thamdinhxe-byid-nhanvien" + "/{IDNhanVien}";
            public const string PrintAllThamDinhXeByIDXe = BaseEndpoint + "/print-thamdinhxe-byid-xe" + "/{IDXe}";
            public const string PrintAllThamDinhXeByIDKH = BaseEndpoint + "/print-thamdinhxe-byid-khachhang" + "/{IDKhachHang}";
            public const string PrintAllThamDinhXeThue = BaseEndpoint + "/print-thamdinhxe-thue" + "/{TenThamDinh}";
            public const string PrintAllThamDinhXeKyGui = BaseEndpoint + "/print-thamdinhxe-kygui" + "/{TenThamDinh}";
            public const string CountThamDinhXe = BaseEndpoint + "/count-thamdinhxe" + "/{IDThamDinh}";
        }

        public static class ThanhLyHopDong
        {
            private const string BaseEndpoint = "~/" + AreaName + "/thanh-ly-hd";
            public const string GetThanhLyHopDong = BaseEndpoint + "/get-single" + "/{IDThanhLy}";
            public const string GetAllThanhLyHopDong = BaseEndpoint + "/get-all";
            public const string AddThanhLyHopDong = BaseEndpoint + "/add";
            public const string UpdateThanhLyHopDong = BaseEndpoint + "/update" + "/{IDThanhLy}";
            public const string DeleteThanhLyHopDong = BaseEndpoint + "/delete" + "/{IDThanhLy}";
            public const string PrintAllThanhLyHopDongByIDNV = BaseEndpoint + "/print-thanhlyhd-byid-nhanvien" + "/{IDNhanVien}";
            public const string PrintAllThanhLyHopDongXeThue = BaseEndpoint + "/print-thanhlyhd-thue" + "/{TenThanhLy}";
            public const string PrintAllThanhLyHopDongKyGui = BaseEndpoint + "/print-thanhlyhd-kygui" + "/{TenThanhLy}";
            public const string CountThanhLyHopDong = BaseEndpoint + "/count-thanhlyhd" + "/{IDThanhLy}";
        }

        public static class TienNghi
        {
            private const string BaseEndpoint = "~/" + AreaName + "/tien-nghi";
            public const string GetTienNghi = BaseEndpoint + "/get-single" + "/{IDTienNghi}";
            public const string GetAllTienNghi = BaseEndpoint + "/get-all";
            public const string AddTienNghi = BaseEndpoint + "/add";
            public const string UpdateTienNghi = BaseEndpoint + "/update" + "/{IDTienNghi}";
            public const string DeleteTienNghi = BaseEndpoint + "/delete" + "/{IDTienNghi}";
            public const string CountTienNghi = BaseEndpoint + "/count-tiennghi" + "/{IDTienNghi}";
        }

        public static class TrangThaiBaoDuong
        {
            private const string BaseEndpoint = "~/" + AreaName + "/trthai-baoduong";
            public const string GetTrangThaiBaoDuong = BaseEndpoint + "/get-single" + "/{IDTrangThaiBD}";
            public const string GetAllTrangThaiBaoDuong = BaseEndpoint + "/get-all";
            public const string AddTrangThaiBaoDuong = BaseEndpoint + "/add";
            public const string UpdateTrangThaiBaoDuong = BaseEndpoint + "/update" + "/{IDTrangThaiBD}";
            public const string DeleteTrangThaiBaoDuong = BaseEndpoint + "/delete" + "/{IDTrangThaiBD}";
            public const string PrintAllTrangThaiBaoDuongByIDXe = BaseEndpoint + "/print-trthai-baoduong-byid-xe" + "/{IDXe}";
            public const string CountTrangThaiBaoDuong = BaseEndpoint + "/count-trthai-baoduong" + "/{IDTrangThaiBD}";
        }

        public static class User
        {
            private const string BaseEndpoint = "~/" + AreaName + "/user";
            public const string GetUser = BaseEndpoint + "/get-single" + "/{IDUser}";
            public const string GetAllUser = BaseEndpoint + "/get-all";
            public const string AddUser = BaseEndpoint + "/add";
            public const string UpdateUser = BaseEndpoint + "/update" + "/{IDUser}";
            public const string DeleteUser = BaseEndpoint + "/delete" + "/{IDUser}";
            public const string GetUserByEmail = BaseEndpoint + "/get-single" + "/{Email}";
        }

        public static class UserPermission
        {
            private const string BaseEndpoint = "~/" + AreaName + "/user-permission";
            public const string GetUserPermission = BaseEndpoint + "/get-single" + "/{IDUser}-{IDPermission}";
            public const string GetAllUserPermission = BaseEndpoint + "/get-all";
            public const string AddUserPermission = BaseEndpoint + "/add";
            public const string UpdateUserPermission = BaseEndpoint + "/update" + "/{IDUser}-{IDPermission}";
            public const string DeleteUserPermission = BaseEndpoint + "/delete" + "/{IDUser}-{IDPermission}";
            public const string PrintAllUserPermissionByIDUser = BaseEndpoint + "/print-user-permission-byidxe" + "/{IDUser}";
            public const string PrintAllUserPermissionByIDPer = BaseEndpoint + "/print-user-permission-byidper" + "/{IDPermission}";
            public const string CountUserPermission = BaseEndpoint + "/count-user-permission";
        }

        public static class Xe
        {
            private const string BaseEndpoint = "~/" + AreaName + "/xe";
            public const string GetXe = BaseEndpoint + "/get-single" + "/{IDXe}";
            public const string GetAllXe = BaseEndpoint + "/get-all";
            public const string AddXe = BaseEndpoint + "/add";
            public const string UpdateXe = BaseEndpoint + "/update" + "/{IDXe}";
            public const string DeleteXe = BaseEndpoint + "/delete" + "/{IDXe}";
            public const string PrintAllXeByIDLoaiXe = BaseEndpoint + "/print-xe-byid-loaixe" + "/{IDLoaiXe}";
            public const string CountXe = BaseEndpoint + "/count-xe" + "/{IDXe}";
        }

        public static class XeTienNghi
        {
            private const string BaseEndpoint = "~/" + AreaName + "/xe-tiennghi";
            public const string GetXeTienNghi = BaseEndpoint + "/get-single" + "/{IDXe}-{IDTienNghi}";
            public const string GetAllXeTienNghi = BaseEndpoint + "/get-all";
            public const string AddXeTienNghi = BaseEndpoint + "/add";
            public const string UpdateXeTienNghi = BaseEndpoint + "/update" + "/{IDXe}-{IDTienNghi}";
            public const string DeleteXeTienNghi = BaseEndpoint + "/delete" + "/{IDXe}-{IDTienNghi}";
            public const string PrintAllXeTienNghiByIDXe = BaseEndpoint + "/print-xe-tiennghi-byidxe" + "/{IDXe}";
            public const string PrintAllXeTienNghiByIDTienNghi = BaseEndpoint + "/print-xe-tiennghi-byid-tiennghi" + "/{IDTienNghi}";
            public const string CountXeTienNghi = BaseEndpoint + "/count-xe-tiennghi";
        }

        public static class Token
        {
            private const string BaseEndpoint = "~/" + AreaName + "/token";
            public const string RenewToken = BaseEndpoint + "/renew-token";
        }
    }
}