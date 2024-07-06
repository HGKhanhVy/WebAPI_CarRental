using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Repository.Migrations
{
    /// <inheritdoc />
    public partial class UpdateXeHopDong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HopDongThueXe_IDXe",
                table: "HopDongThueXe");

            migrationBuilder.CreateIndex(
                name: "IX_HopDongThueXe_IDXe",
                table: "HopDongThueXe",
                column: "IDXe");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HopDongThueXe_IDXe",
                table: "HopDongThueXe");

            migrationBuilder.CreateIndex(
                name: "IX_HopDongThueXe_IDXe",
                table: "HopDongThueXe",
                column: "IDXe",
                unique: true);
        }
    }
}
