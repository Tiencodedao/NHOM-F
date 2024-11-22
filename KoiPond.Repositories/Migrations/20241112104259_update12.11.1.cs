using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KoiPond.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class update12111 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NhanVienMaNhanVien",
                table: "YeuCauDichVu",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_YeuCauDichVu_NhanVienMaNhanVien",
                table: "YeuCauDichVu",
                column: "NhanVienMaNhanVien");

            migrationBuilder.AddForeignKey(
                name: "FK_YeuCauDichVu_NhanVien_NhanVienMaNhanVien",
                table: "YeuCauDichVu",
                column: "NhanVienMaNhanVien",
                principalTable: "NhanVien",
                principalColumn: "MaNhanVien");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_YeuCauDichVu_NhanVien_NhanVienMaNhanVien",
                table: "YeuCauDichVu");

            migrationBuilder.DropIndex(
                name: "IX_YeuCauDichVu_NhanVienMaNhanVien",
                table: "YeuCauDichVu");

            migrationBuilder.DropColumn(
                name: "NhanVienMaNhanVien",
                table: "YeuCauDichVu");
        }
    }
}
