using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Repository.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMQH : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_KMLoaiXe_IDLoaiXe",
                table: "KMLoaiXe");

            migrationBuilder.DropIndex(
                name: "IX_KMLoaiKH_IDLoaiKH",
                table: "KMLoaiKH");

            migrationBuilder.DropIndex(
                name: "IX_HopDongKyGui_IDXe",
                table: "HopDongKyGui");

            migrationBuilder.CreateIndex(
                name: "IX_KMLoaiXe_IDLoaiXe",
                table: "KMLoaiXe",
                column: "IDLoaiXe");

            migrationBuilder.CreateIndex(
                name: "IX_KMLoaiKH_IDLoaiKH",
                table: "KMLoaiKH",
                column: "IDLoaiKH");

            migrationBuilder.CreateIndex(
                name: "IX_HopDongKyGui_IDXe",
                table: "HopDongKyGui",
                column: "IDXe");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_KMLoaiXe_IDLoaiXe",
                table: "KMLoaiXe");

            migrationBuilder.DropIndex(
                name: "IX_KMLoaiKH_IDLoaiKH",
                table: "KMLoaiKH");

            migrationBuilder.DropIndex(
                name: "IX_HopDongKyGui_IDXe",
                table: "HopDongKyGui");

            migrationBuilder.CreateIndex(
                name: "IX_KMLoaiXe_IDLoaiXe",
                table: "KMLoaiXe",
                column: "IDLoaiXe",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KMLoaiKH_IDLoaiKH",
                table: "KMLoaiKH",
                column: "IDLoaiKH",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HopDongKyGui_IDXe",
                table: "HopDongKyGui",
                column: "IDXe",
                unique: true);
        }
    }
}
