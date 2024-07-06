using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Repository.Migrations
{
    /// <inheritdoc />
    public partial class XoaBangSDT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SoDienThoai");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
