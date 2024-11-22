using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KoiPond.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class update11112 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "YeuCauThiCong",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "YeuCauDichVu",
                type: "nvarchar(max)",
                nullable: true);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "YeuCauThiCong");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "YeuCauDichVu");
        }
    }
}
