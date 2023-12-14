using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SachAPI.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_keSachs_chiTietSachs_ChiTietSachID",
                table: "keSachs");

            migrationBuilder.DropIndex(
                name: "IX_keSachs_ChiTietSachID",
                table: "keSachs");

            migrationBuilder.DropColumn(
                name: "ChiTietSachID",
                table: "keSachs");

            migrationBuilder.AddColumn<int>(
                name: "KeSachID",
                table: "chiTietSachs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_chiTietSachs_KeSachID",
                table: "chiTietSachs",
                column: "KeSachID");

            migrationBuilder.AddForeignKey(
                name: "FK_chiTietSachs_keSachs_KeSachID",
                table: "chiTietSachs",
                column: "KeSachID",
                principalTable: "keSachs",
                principalColumn: "KeSachID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_chiTietSachs_keSachs_KeSachID",
                table: "chiTietSachs");

            migrationBuilder.DropIndex(
                name: "IX_chiTietSachs_KeSachID",
                table: "chiTietSachs");

            migrationBuilder.DropColumn(
                name: "KeSachID",
                table: "chiTietSachs");

            migrationBuilder.AddColumn<int>(
                name: "ChiTietSachID",
                table: "keSachs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_keSachs_ChiTietSachID",
                table: "keSachs",
                column: "ChiTietSachID");

            migrationBuilder.AddForeignKey(
                name: "FK_keSachs_chiTietSachs_ChiTietSachID",
                table: "keSachs",
                column: "ChiTietSachID",
                principalTable: "chiTietSachs",
                principalColumn: "ChiTietSachID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
