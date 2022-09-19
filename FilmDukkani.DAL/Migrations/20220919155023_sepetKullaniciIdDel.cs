using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmDukkani.DAL.Migrations
{
    public partial class sepetKullaniciIdDel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresler_Sehirler_SehirId",
                table: "Adresler");

            migrationBuilder.DropForeignKey(
                name: "FK_Sepetler_Kullanicilar_KullaniciId",
                table: "Sepetler");

            migrationBuilder.DropIndex(
                name: "IX_Sepetler_KullaniciId",
                table: "Sepetler");

            migrationBuilder.DropColumn(
                name: "KullaniciId",
                table: "Sepetler");

            migrationBuilder.DropColumn(
                name: "FilmId",
                table: "Kategoriler");

            migrationBuilder.DropColumn(
                name: "KategoriId",
                table: "Filmler");

            migrationBuilder.AlterColumn<int>(
                name: "SehirId",
                table: "Adresler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Adresler_Sehirler_SehirId",
                table: "Adresler",
                column: "SehirId",
                principalTable: "Sehirler",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresler_Sehirler_SehirId",
                table: "Adresler");

            migrationBuilder.AddColumn<int>(
                name: "KullaniciId",
                table: "Sepetler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FilmId",
                table: "Kategoriler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KategoriId",
                table: "Filmler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "SehirId",
                table: "Adresler",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sepetler_KullaniciId",
                table: "Sepetler",
                column: "KullaniciId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adresler_Sehirler_SehirId",
                table: "Adresler",
                column: "SehirId",
                principalTable: "Sehirler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sepetler_Kullanicilar_KullaniciId",
                table: "Sepetler",
                column: "KullaniciId",
                principalTable: "Kullanicilar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
