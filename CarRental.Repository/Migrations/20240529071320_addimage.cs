using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Repository.Migrations
{
    /// <inheritdoc />
    public partial class addimage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HinhAnh1",
                table: "Xe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HinhAnh2",
                table: "Xe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HinhAnh3",
                table: "Xe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HinhAnh4",
                table: "Xe",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HinhAnh1",
                table: "Xe");

            migrationBuilder.DropColumn(
                name: "HinhAnh2",
                table: "Xe");

            migrationBuilder.DropColumn(
                name: "HinhAnh3",
                table: "Xe");

            migrationBuilder.DropColumn(
                name: "HinhAnh4",
                table: "Xe");
        }
    }
}
