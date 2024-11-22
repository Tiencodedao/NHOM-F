using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KoiPond.Migrations
{
    /// <inheritdoc />
    public partial class updatedb1911 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "DuAns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDuAn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UuDiem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KichThuoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VatLieu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoLuongCa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuAns", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DuAns");
        }
    }
}
