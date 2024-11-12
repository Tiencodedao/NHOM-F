using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KoiPond.Migrations
{
    /// <inheritdoc />
    public partial class Update1191 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__YeuCauDic__MaKha__49C3F6B7",
                table: "YeuCauDichVu");

            migrationBuilder.DropForeignKey(
                name: "FK__YeuCauThi__MaKha__412EB0B6",
                table: "YeuCauThiCong");

            migrationBuilder.RenameColumn(
                name: "MaKhachHang",
                table: "YeuCauThiCong",
                newName: "KhachHangMaKhachHang");

            //migrationBuilder.RenameIndex(
            //    name: "IX_YeuCauThiCong_MaKhachHang",
            //    table: "YeuCauThiCong",
            //    newName: "IX_YeuCauThiCong_KhachHangMaKhachHang");

            migrationBuilder.RenameColumn(
                name: "MaKhachHang",
                table: "YeuCauDichVu",
                newName: "KhachHangMaKhachHang");

            //migrationBuilder.RenameIndex(
            //    name: "IX_YeuCauDichVu_MaKhachHang",
            //    table: "YeuCauDichVu",
            //    newName: "IX_YeuCauDichVu_KhachHangMaKhachHang");

            migrationBuilder.AddColumn<string>(
                name: "DiaChi",
                table: "YeuCauThiCong",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileDinhKem",
                table: "YeuCauThiCong",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SDT",
                table: "YeuCauThiCong",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoLuong",
                table: "YeuCauThiCong",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenKhachHang",
                table: "YeuCauThiCong",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DiaChi",
                table: "YeuCauDichVu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MoTa",
                table: "YeuCauDichVu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SDT",
                table: "YeuCauDichVu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoLuong",
                table: "YeuCauDichVu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenKhachHang",
                table: "YeuCauDichVu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_YeuCauDichVu_KhachHang_KhachHangMaKhachHang",
                table: "YeuCauDichVu",
                column: "KhachHangMaKhachHang",
                principalTable: "KhachHang",
                principalColumn: "MaKhachHang");

            migrationBuilder.AddForeignKey(
                name: "FK_YeuCauThiCong_KhachHang_KhachHangMaKhachHang",
                table: "YeuCauThiCong",
                column: "KhachHangMaKhachHang",
                principalTable: "KhachHang",
                principalColumn: "MaKhachHang");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_YeuCauDichVu_KhachHang_KhachHangMaKhachHang",
                table: "YeuCauDichVu");

            migrationBuilder.DropForeignKey(
                name: "FK_YeuCauThiCong_KhachHang_KhachHangMaKhachHang",
                table: "YeuCauThiCong");

            migrationBuilder.DropColumn(
                name: "DiaChi",
                table: "YeuCauThiCong");

            migrationBuilder.DropColumn(
                name: "FileDinhKem",
                table: "YeuCauThiCong");

            migrationBuilder.DropColumn(
                name: "SDT",
                table: "YeuCauThiCong");

            migrationBuilder.DropColumn(
                name: "SoLuong",
                table: "YeuCauThiCong");

            migrationBuilder.DropColumn(
                name: "TenKhachHang",
                table: "YeuCauThiCong");

            migrationBuilder.DropColumn(
                name: "DiaChi",
                table: "YeuCauDichVu");

            migrationBuilder.DropColumn(
                name: "MoTa",
                table: "YeuCauDichVu");

            migrationBuilder.DropColumn(
                name: "SDT",
                table: "YeuCauDichVu");

            migrationBuilder.DropColumn(
                name: "SoLuong",
                table: "YeuCauDichVu");

            migrationBuilder.DropColumn(
                name: "TenKhachHang",
                table: "YeuCauDichVu");

            migrationBuilder.RenameColumn(
                name: "KhachHangMaKhachHang",
                table: "YeuCauThiCong",
                newName: "MaKhachHang");

            migrationBuilder.RenameIndex(
                name: "IX_YeuCauThiCong_KhachHangMaKhachHang",
                table: "YeuCauThiCong",
                newName: "IX_YeuCauThiCong_MaKhachHang");

            migrationBuilder.RenameColumn(
                name: "KhachHangMaKhachHang",
                table: "YeuCauDichVu",
                newName: "MaKhachHang");

            migrationBuilder.RenameIndex(
                name: "IX_YeuCauDichVu_KhachHangMaKhachHang",
                table: "YeuCauDichVu",
                newName: "IX_YeuCauDichVu_MaKhachHang");

            migrationBuilder.AddForeignKey(
                name: "FK__YeuCauDic__MaKha__49C3F6B7",
                table: "YeuCauDichVu",
                column: "MaKhachHang",
                principalTable: "KhachHang",
                principalColumn: "MaKhachHang");

            migrationBuilder.AddForeignKey(
                name: "FK__YeuCauThi__MaKha__412EB0B6",
                table: "YeuCauThiCong",
                column: "MaKhachHang",
                principalTable: "KhachHang",
                principalColumn: "MaKhachHang");
        }
    }
}
