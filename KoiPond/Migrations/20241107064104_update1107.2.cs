using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KoiPond.Migrations
{
    /// <inheritdoc />
    public partial class update11072 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DuongDanFileThietKe",
                table: "BaoGiaDuAn",
                newName: "DesignFilePath");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "NhanVien",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "KhachHang",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "NhanVien");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "KhachHang");

            migrationBuilder.RenameColumn(
                name: "DesignFilePath",
                table: "BaoGiaDuAn",
                newName: "DuongDanFileThietKe");
        }
    }
}
