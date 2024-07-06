using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Repository.Migrations
{
    /// <inheritdoc />
    public partial class XoaMotSoBang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessToken");

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
                name: "UserPermission");

            migrationBuilder.DropTable(
                name: "Token");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "QuanLyChuyenKhoan",
                columns: table => new
                {
                    IDQuanLyCK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NDChuyenKhoanCoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NDChuyenKhoanKyGui = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NDChuyenKhoanThue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuanLyChuyenKhoan", x => x.IDQuanLyCK);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    IDRoom = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IDKhachHang = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IDNhanVien = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "AccessToken",
                columns: table => new
                {
                    StrTokenIDToken = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ExpireAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IDUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    ExpireAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    JwtID = table.Column<string>(type: "nvarchar(max)", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_AccessToken_StrTokenIDToken",
                table: "AccessToken",
                column: "StrTokenIDToken");

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
                name: "IX_UserPermission_IDPermission",
                table: "UserPermission",
                column: "IDPermission");
        }
    }
}
