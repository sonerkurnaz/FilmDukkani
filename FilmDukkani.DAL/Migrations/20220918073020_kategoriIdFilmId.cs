using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmDukkani.DAL.Migrations
{
    public partial class kategoriIdFilmId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresler_Sehirler_SehirId",
                table: "Adresler");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Adresler_Sehirler_SehirId",
                table: "Adresler",
                column: "SehirId",
                principalTable: "Sehirler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresler_Sehirler_SehirId",
                table: "Adresler");

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
    }
}
