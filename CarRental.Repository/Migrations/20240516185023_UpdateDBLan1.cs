using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Repository.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDBLan1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChucVu",
                columns: table => new
                {
                    IDChucVu = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenChucVu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MucLuongTheoChucVu = table.Column<double>(type: "float", nullable: false),
                    PhanTramMuc1 = table.Column<double>(type: "float", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucVu", x => x.IDChucVu);
                });

            migrationBuilder.CreateTable(
                name: "KhuyenMai",
                columns: table => new
                {
                    IDKhuyenMai = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenCTKM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThoiGianBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhuyenMai", x => x.IDKhuyenMai);
                });

            migrationBuilder.CreateTable(
                name: "LoaiKhachHang",
                columns: table => new
                {
                    IDLoaiKH = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenLoaiKH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiKhachHang", x => x.IDLoaiKH);
                });

            migrationBuilder.CreateTable(
                name: "LoaiXe",
                columns: table => new
                {
                    IDLoaiXe = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenLoaiXe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiaThue = table.Column<double>(type: "float", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiXe", x => x.IDLoaiXe);
                });

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "NhacHen",
                columns: table => new
                {
                    IDNhacHen = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DinhKyNhacHen = table.Column<int>(type: "int", nullable: false),
                    NDNhacHen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhacHen", x => x.IDNhacHen);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    IDPermission = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PermissionGroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.IDPermission);
                });

            migrationBuilder.CreateTable(
                name: "PhongBan",
                columns: table => new
                {
                    IDPhongBan = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenPhongBan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhanTramMuc1 = table.Column<double>(type: "float", nullable: false),
                    PhanTramMuc2 = table.Column<double>(type: "float", nullable: false),
                    PhanTramMuc3 = table.Column<double>(type: "float", nullable: false),
                    PhanTramMuc4 = table.Column<double>(type: "float", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhongBan", x => x.IDPhongBan);
                });

            migrationBuilder.CreateTable(
                name: "QuanLyChuyenKhoan",
                columns: table => new
                {
                    IDQuanLyCK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NDChuyenKhoanKyGui = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NDChuyenKhoanThue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NDChuyenKhoanCoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuanLyChuyenKhoan", x => x.IDQuanLyCK);
                });

            migrationBuilder.CreateTable(
                name: "SoDienThoai",
                columns: table => new
                {
                    DauSo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoDienThoai", x => x.DauSo);
                });

            migrationBuilder.CreateTable(
                name: "TienNghi",
                columns: table => new
                {
                    IDTienNghi = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenTienNghi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TienNghi", x => x.IDTienNghi);
                });

            migrationBuilder.CreateTable(
                name: "Token",
                columns: table => new
                {
                    IDToken = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Token", x => x.IDToken);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    IDUser = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.IDUser);
                });

            migrationBuilder.CreateTable(
                name: "KMTrenHoaDon",
                columns: table => new
                {
                    IDKhuyenMai = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DieuKienApDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TyLePhanTram = table.Column<double>(type: "float", nullable: true),
                    SoTien = table.Column<double>(type: "float", nullable: true),
                    SoTienToiDaDuocGiam = table.Column<double>(type: "float", nullable: false),
                    Inactive = table.Column<bool>(type: "bit", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KMTrenHoaDon", x => x.IDKhuyenMai);
                    table.ForeignKey(
                        name: "FK_KMTrenHoaDon_KhuyenMai_IDKhuyenMai",
                        column: x => x.IDKhuyenMai,
                        principalTable: "KhuyenMai",
                        principalColumn: "IDKhuyenMai",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KMVoucher",
                columns: table => new
                {
                    IDKhuyenMai = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IDCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VoucherCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TyLePhanTram = table.Column<double>(type: "float", nullable: true),
                    SoTien = table.Column<double>(type: "float", nullable: true),
                    SoTienToiDaDuocGiam = table.Column<double>(type: "float", nullable: false),
                    Inactive = table.Column<bool>(type: "bit", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KMVoucher", x => x.IDKhuyenMai);
                    table.ForeignKey(
                        name: "FK_KMVoucher_KhuyenMai_IDKhuyenMai",
                        column: x => x.IDKhuyenMai,
                        principalTable: "KhuyenMai",
                        principalColumn: "IDKhuyenMai",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    IDKhachHang = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IDLoaiKH = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CCCD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GPLX = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoPassPort = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChiThuongTru = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChiHienTai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDienThoaiDuPhong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoDienThoaiNguoiThamChieu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoTaiKhoan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NganHang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChiNhanhNganHang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.IDKhachHang);
                    table.ForeignKey(
                        name: "FK_KhachHang_LoaiKhachHang_IDLoaiKH",
                        column: x => x.IDLoaiKH,
                        principalTable: "LoaiKhachHang",
                        principalColumn: "IDLoaiKH",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KMLoaiKH",
                columns: table => new
                {
                    IDKhuyenMai = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IDLoaiKH = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TyLePhanTram = table.Column<double>(type: "float", nullable: true),
                    SoTien = table.Column<double>(type: "float", nullable: true),
                    SoTienToiDaDuocGiam = table.Column<double>(type: "float", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KMLoaiKH", x => x.IDKhuyenMai);
                    table.ForeignKey(
                        name: "FK_KMLoaiKH_KhuyenMai_IDKhuyenMai",
                        column: x => x.IDKhuyenMai,
                        principalTable: "KhuyenMai",
                        principalColumn: "IDKhuyenMai",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KMLoaiKH_LoaiKhachHang_IDLoaiKH",
                        column: x => x.IDLoaiKH,
                        principalTable: "LoaiKhachHang",
                        principalColumn: "IDLoaiKH",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KMLoaiXe",
                columns: table => new
                {
                    IDKhuyenMai = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IDLoaiXe = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TyLePhanTram = table.Column<double>(type: "float", nullable: true),
                    SoTien = table.Column<double>(type: "float", nullable: true),
                    SoTienToiDaDuocGiam = table.Column<double>(type: "float", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KMLoaiXe", x => x.IDKhuyenMai);
                    table.ForeignKey(
                        name: "FK_KMLoaiXe_KhuyenMai_IDKhuyenMai",
                        column: x => x.IDKhuyenMai,
                        principalTable: "KhuyenMai",
                        principalColumn: "IDKhuyenMai",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KMLoaiXe_LoaiXe_IDLoaiXe",
                        column: x => x.IDLoaiXe,
                        principalTable: "LoaiXe",
                        principalColumn: "IDLoaiXe",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Xe",
                columns: table => new
                {
                    IDXe = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IDLoaiXe = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TruyenDong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NhienLieu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguyenLieuTieuHao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenXe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BienSoXe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HangXe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamSanXuat = table.Column<int>(type: "int", nullable: false),
                    SoChoNgoi = table.Column<int>(type: "int", nullable: false),
                    GiaThue = table.Column<double>(type: "float", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Xe", x => x.IDXe);
                    table.ForeignKey(
                        name: "FK_Xe_LoaiXe_IDLoaiXe",
                        column: x => x.IDLoaiXe,
                        principalTable: "LoaiXe",
                        principalColumn: "IDLoaiXe",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermissionDetail",
                columns: table => new
                {
                    IDPermissionDetail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IDPermission = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ActionCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckAction = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionDetail", x => x.IDPermissionDetail);
                    table.ForeignKey(
                        name: "FK_PermissionDetail_Permission_IDPermission",
                        column: x => x.IDPermission,
                        principalTable: "Permission",
                        principalColumn: "IDPermission",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    IDNhanVien = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IDChucVu = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IDPhongBan = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CCCD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayVaoLam = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayNghiViec = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HeSoLuong = table.Column<double>(type: "float", nullable: false),
                    SoTaiKhoan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NganHang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChiNhanhNganHang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.IDNhanVien);
                    table.ForeignKey(
                        name: "FK_NhanVien_ChucVu_IDChucVu",
                        column: x => x.IDChucVu,
                        principalTable: "ChucVu",
                        principalColumn: "IDChucVu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NhanVien_PhongBan_IDPhongBan",
                        column: x => x.IDPhongBan,
                        principalTable: "PhongBan",
                        principalColumn: "IDPhongBan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccessToken",
                columns: table => new
                {
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StrTokenIDToken = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IDUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false),
                    ExpireAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_AccessToken_Token_StrTokenIDToken",
                        column: x => x.StrTokenIDToken,
                        principalTable: "Token",
                        principalColumn: "IDToken");
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Token = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IDUser = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StrTokenIDToken = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    JwtID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false),
                    ExpireAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => new { x.Token, x.IDUser });
                    table.ForeignKey(
                        name: "FK_RefreshToken_Token_StrTokenIDToken",
                        column: x => x.StrTokenIDToken,
                        principalTable: "Token",
                        principalColumn: "IDToken");
                });

            migrationBuilder.CreateTable(
                name: "UserPermission",
                columns: table => new
                {
                    IDUser = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IDPermission = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermission", x => new { x.IDUser, x.IDPermission });
                    table.ForeignKey(
                        name: "FK_UserPermission_Permission_IDPermission",
                        column: x => x.IDPermission,
                        principalTable: "Permission",
                        principalColumn: "IDPermission",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPermission_User_IDUser",
                        column: x => x.IDUser,
                        principalTable: "User",
                        principalColumn: "IDUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LichXe",
                columns: table => new
                {
                    IDLichXe = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IDXe = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ThoiGianBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichXe", x => x.IDLichXe);
                    table.ForeignKey(
                        name: "FK_LichXe_Xe_IDXe",
                        column: x => x.IDXe,
                        principalTable: "Xe",
                        principalColumn: "IDXe",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrangThaiBaoDuong",
                columns: table => new
                {
                    IDTrangThaiBD = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IDXe = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NDBaoDuong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayBaoDuong = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HinhAnhHoaDonBD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrangThaiBaoDuong", x => x.IDTrangThaiBD);
                    table.ForeignKey(
                        name: "FK_TrangThaiBaoDuong_Xe_IDXe",
                        column: x => x.IDXe,
                        principalTable: "Xe",
                        principalColumn: "IDXe",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "XeTienNghi",
                columns: table => new
                {
                    IDXe = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IDTienNghi = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XeTienNghi", x => new { x.IDXe, x.IDTienNghi });
                    table.ForeignKey(
                        name: "FK_XeTienNghi_TienNghi_IDTienNghi",
                        column: x => x.IDTienNghi,
                        principalTable: "TienNghi",
                        principalColumn: "IDTienNghi",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_XeTienNghi_Xe_IDXe",
                        column: x => x.IDXe,
                        principalTable: "Xe",
                        principalColumn: "IDXe",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HopDongKyGui",
                columns: table => new
                {
                    IDHopDongKyGui = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SoHopDong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDKhachHang = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IDNhanVien = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IDXe = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhanTramHoaHong = table.Column<double>(type: "float", nullable: false),
                    PhuongThucThanhToan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DinhKyThanhToan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThoiDiemThanhToan = table.Column<int>(type: "int", nullable: false),
                    NgayHieuLuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayHetHan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    XacNhan = table.Column<bool>(type: "bit", nullable: false),
                    HinhAnhHopDong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopDongKyGui", x => x.IDHopDongKyGui);
                    table.ForeignKey(
                        name: "FK_HopDongKyGui_KhachHang_IDKhachHang",
                        column: x => x.IDKhachHang,
                        principalTable: "KhachHang",
                        principalColumn: "IDKhachHang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HopDongKyGui_NhanVien_IDNhanVien",
                        column: x => x.IDNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "IDNhanVien",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HopDongKyGui_Xe_IDXe",
                        column: x => x.IDXe,
                        principalTable: "Xe",
                        principalColumn: "IDXe",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HopDongThueXe",
                columns: table => new
                {
                    IDHopDongThueXe = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SoHopDong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDKhachHang = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IDNhanVien = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IDXe = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GiaThue = table.Column<double>(type: "float", nullable: false),
                    SoTienCoc = table.Column<double>(type: "float", nullable: false),
                    TongThanhTienDuKien = table.Column<double>(type: "float", nullable: false),
                    TongThanhTienDuKienSauKM = table.Column<double>(type: "float", nullable: false),
                    TienThanhToanTheoDot = table.Column<double>(type: "float", nullable: false),
                    TienThanhToanTheoDotChuaKM = table.Column<double>(type: "float", nullable: false),
                    PhuongThucThanhToan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DinhKyThanhToan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThoiDiemThanhToan = table.Column<int>(type: "int", nullable: false),
                    NgayHieuLuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayHetHan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    XacNhan = table.Column<bool>(type: "bit", nullable: false),
                    HinhAnhHopDong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDKMLoaiKH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDKMLoaiXe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDKMVoucher = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDKMTrenHoaDon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenKMLoaiKH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenKMLoaiXe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenKMVoucher = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VoucherCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopDongThueXe", x => x.IDHopDongThueXe);
                    table.ForeignKey(
                        name: "FK_HopDongThueXe_KhachHang_IDKhachHang",
                        column: x => x.IDKhachHang,
                        principalTable: "KhachHang",
                        principalColumn: "IDKhachHang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HopDongThueXe_NhanVien_IDNhanVien",
                        column: x => x.IDNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "IDNhanVien",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HopDongThueXe_Xe_IDXe",
                        column: x => x.IDXe,
                        principalTable: "Xe",
                        principalColumn: "IDXe",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    IDRoom = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IDNhanVien = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IDKhachHang = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ThoiGianRoom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.IDRoom);
                    table.ForeignKey(
                        name: "FK_Room_KhachHang_IDKhachHang",
                        column: x => x.IDKhachHang,
                        principalTable: "KhachHang",
                        principalColumn: "IDKhachHang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Room_NhanVien_IDNhanVien",
                        column: x => x.IDNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "IDNhanVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThamDinhXe",
                columns: table => new
                {
                    IDThamDinh = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IDNhanVien = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenThamDinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDXe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDKhachHang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayThamDinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BienBanThamDinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiDungHoSoXe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TinhTrangNgoaiThat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TinhTrangNoiThat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeThongDongCo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeThongTreo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeThongPhanh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThamDinhXe", x => x.IDThamDinh);
                    table.ForeignKey(
                        name: "FK_ThamDinhXe_NhanVien_IDNhanVien",
                        column: x => x.IDNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "IDNhanVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThanhLyHopDong",
                columns: table => new
                {
                    IDThanhLy = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IDNhanVien = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenThanhLy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayThanhLy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    XacNhanCuaAdmin = table.Column<bool>(type: "bit", nullable: false),
                    XacNhanThamDinh = table.Column<bool>(type: "bit", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThanhLyHopDong", x => x.IDThanhLy);
                    table.ForeignKey(
                        name: "FK_ThanhLyHopDong_NhanVien_IDNhanVien",
                        column: x => x.IDNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "IDNhanVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDonKyGui",
                columns: table => new
                {
                    IDHoaDonKyGui = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IDHopDongKyGui = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SoHoaDon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDKhachHang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDNhanVien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoHoaDonThue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TongThanhToan = table.Column<double>(type: "float", nullable: false),
                    TrangThaiThanhToan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HinhThucThanhToan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonKyGui", x => x.IDHoaDonKyGui);
                    table.ForeignKey(
                        name: "FK_HoaDonKyGui_HopDongKyGui_IDHopDongKyGui",
                        column: x => x.IDHopDongKyGui,
                        principalTable: "HopDongKyGui",
                        principalColumn: "IDHopDongKyGui",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDonThueXe",
                columns: table => new
                {
                    IDHoaDonThueXe = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IDHopDongThueXe = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SoHoaDon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDKhachHang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDNhanVien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TongThanhToan = table.Column<double>(type: "float", nullable: false),
                    TongThanhToanChuaKM = table.Column<double>(type: "float", nullable: false),
                    TrangThaiThanhToan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HinhThucThanhToan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HinhAnhThanhToan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonThueXe", x => x.IDHoaDonThueXe);
                    table.ForeignKey(
                        name: "FK_HoaDonThueXe_HopDongThueXe_IDHopDongThueXe",
                        column: x => x.IDHopDongThueXe,
                        principalTable: "HopDongThueXe",
                        principalColumn: "IDHopDongThueXe",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessToken_StrTokenIDToken",
                table: "AccessToken",
                column: "StrTokenIDToken");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonKyGui_IDHopDongKyGui",
                table: "HoaDonKyGui",
                column: "IDHopDongKyGui");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonThueXe_IDHopDongThueXe",
                table: "HoaDonThueXe",
                column: "IDHopDongThueXe");

            migrationBuilder.CreateIndex(
                name: "IX_HopDongKyGui_IDKhachHang",
                table: "HopDongKyGui",
                column: "IDKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_HopDongKyGui_IDNhanVien",
                table: "HopDongKyGui",
                column: "IDNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_HopDongKyGui_IDXe",
                table: "HopDongKyGui",
                column: "IDXe",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HopDongThueXe_IDKhachHang",
                table: "HopDongThueXe",
                column: "IDKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_HopDongThueXe_IDNhanVien",
                table: "HopDongThueXe",
                column: "IDNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_HopDongThueXe_IDXe",
                table: "HopDongThueXe",
                column: "IDXe",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KhachHang_IDLoaiKH",
                table: "KhachHang",
                column: "IDLoaiKH");

            migrationBuilder.CreateIndex(
                name: "IX_KMLoaiKH_IDLoaiKH",
                table: "KMLoaiKH",
                column: "IDLoaiKH",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KMLoaiXe_IDLoaiXe",
                table: "KMLoaiXe",
                column: "IDLoaiXe",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LichXe_IDXe",
                table: "LichXe",
                column: "IDXe");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_IDChucVu",
                table: "NhanVien",
                column: "IDChucVu");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_IDPhongBan",
                table: "NhanVien",
                column: "IDPhongBan");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionDetail_IDPermission",
                table: "PermissionDetail",
                column: "IDPermission");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_StrTokenIDToken",
                table: "RefreshToken",
                column: "StrTokenIDToken");

            migrationBuilder.CreateIndex(
                name: "IX_Room_IDKhachHang",
                table: "Room",
                column: "IDKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_Room_IDNhanVien",
                table: "Room",
                column: "IDNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_ThamDinhXe_IDNhanVien",
                table: "ThamDinhXe",
                column: "IDNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhLyHopDong_IDNhanVien",
                table: "ThanhLyHopDong",
                column: "IDNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_TrangThaiBaoDuong_IDXe",
                table: "TrangThaiBaoDuong",
                column: "IDXe");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermission_IDPermission",
                table: "UserPermission",
                column: "IDPermission");

            migrationBuilder.CreateIndex(
                name: "IX_Xe_IDLoaiXe",
                table: "Xe",
                column: "IDLoaiXe");

            migrationBuilder.CreateIndex(
                name: "IX_XeTienNghi_IDTienNghi",
                table: "XeTienNghi",
                column: "IDTienNghi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessToken");

            migrationBuilder.DropTable(
                name: "HoaDonKyGui");

            migrationBuilder.DropTable(
                name: "HoaDonThueXe");

            migrationBuilder.DropTable(
                name: "KMLoaiKH");

            migrationBuilder.DropTable(
                name: "KMLoaiXe");

            migrationBuilder.DropTable(
                name: "KMTrenHoaDon");

            migrationBuilder.DropTable(
                name: "KMVoucher");

            migrationBuilder.DropTable(
                name: "LichXe");

            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "NhacHen");

            migrationBuilder.DropTable(
                name: "PermissionDetail");

            migrationBuilder.DropTable(
                name: "QuanLyChuyenKhoan");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "SoDienThoai");

            migrationBuilder.DropTable(
                name: "ThamDinhXe");

            migrationBuilder.DropTable(
                name: "ThanhLyHopDong");

            migrationBuilder.DropTable(
                name: "TrangThaiBaoDuong");

            migrationBuilder.DropTable(
                name: "UserPermission");

            migrationBuilder.DropTable(
                name: "XeTienNghi");

            migrationBuilder.DropTable(
                name: "HopDongKyGui");

            migrationBuilder.DropTable(
                name: "HopDongThueXe");

            migrationBuilder.DropTable(
                name: "KhuyenMai");

            migrationBuilder.DropTable(
                name: "Token");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "TienNghi");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "Xe");

            migrationBuilder.DropTable(
                name: "LoaiKhachHang");

            migrationBuilder.DropTable(
                name: "ChucVu");

            migrationBuilder.DropTable(
                name: "PhongBan");

            migrationBuilder.DropTable(
                name: "LoaiXe");
        }
    }
}
