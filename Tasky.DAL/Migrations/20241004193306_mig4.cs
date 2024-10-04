using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tasky.DAL.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "KayitTarihi",
                table: "KullaniciYetkiler",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciYetkiler_KullaniciId",
                table: "KullaniciYetkiler",
                column: "KullaniciId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciYetkiler_YetkiId",
                table: "KullaniciYetkiler",
                column: "YetkiId");

            migrationBuilder.AddForeignKey(
                name: "FK_KullaniciYetkiler_Kullanicilar_KullaniciId",
                table: "KullaniciYetkiler",
                column: "KullaniciId",
                principalTable: "Kullanicilar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KullaniciYetkiler_Yetkiler_YetkiId",
                table: "KullaniciYetkiler",
                column: "YetkiId",
                principalTable: "Yetkiler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KullaniciYetkiler_Kullanicilar_KullaniciId",
                table: "KullaniciYetkiler");

            migrationBuilder.DropForeignKey(
                name: "FK_KullaniciYetkiler_Yetkiler_YetkiId",
                table: "KullaniciYetkiler");

            migrationBuilder.DropIndex(
                name: "IX_KullaniciYetkiler_KullaniciId",
                table: "KullaniciYetkiler");

            migrationBuilder.DropIndex(
                name: "IX_KullaniciYetkiler_YetkiId",
                table: "KullaniciYetkiler");

            migrationBuilder.DropColumn(
                name: "KayitTarihi",
                table: "KullaniciYetkiler");
        }
    }
}
