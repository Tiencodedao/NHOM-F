using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KoiPond.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class update11113 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DiemTrungThanh",
                table: "KhachHang",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "0",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DiemTrungThanh",
                table: "KhachHang",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "0");
        }
    }
}
