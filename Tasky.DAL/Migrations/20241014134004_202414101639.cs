using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tasky.DAL.Migrations
{
    /// <inheritdoc />
    public partial class _202414101639 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KonuKategori_Kategori_KategoriId",
                table: "KonuKategori");

            migrationBuilder.DropForeignKey(
                name: "FK_KonuKategori_Konular_KonuId",
                table: "KonuKategori");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KonuKategori",
                table: "KonuKategori");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kategori",
                table: "Kategori");

            migrationBuilder.RenameTable(
                name: "KonuKategori",
                newName: "KonuKategoriler");

            migrationBuilder.RenameTable(
                name: "Kategori",
                newName: "Kategoriler");

            migrationBuilder.RenameIndex(
                name: "IX_KonuKategori_KonuId",
                table: "KonuKategoriler",
                newName: "IX_KonuKategoriler_KonuId");

            migrationBuilder.RenameIndex(
                name: "IX_KonuKategori_KategoriId",
                table: "KonuKategoriler",
                newName: "IX_KonuKategoriler_KategoriId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KonuKategoriler",
                table: "KonuKategoriler",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kategoriler",
                table: "Kategoriler",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KonuKategoriler_Kategoriler_KategoriId",
                table: "KonuKategoriler",
                column: "KategoriId",
                principalTable: "Kategoriler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KonuKategoriler_Konular_KonuId",
                table: "KonuKategoriler",
                column: "KonuId",
                principalTable: "Konular",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KonuKategoriler_Kategoriler_KategoriId",
                table: "KonuKategoriler");

            migrationBuilder.DropForeignKey(
                name: "FK_KonuKategoriler_Konular_KonuId",
                table: "KonuKategoriler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KonuKategoriler",
                table: "KonuKategoriler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kategoriler",
                table: "Kategoriler");

            migrationBuilder.RenameTable(
                name: "KonuKategoriler",
                newName: "KonuKategori");

            migrationBuilder.RenameTable(
                name: "Kategoriler",
                newName: "Kategori");

            migrationBuilder.RenameIndex(
                name: "IX_KonuKategoriler_KonuId",
                table: "KonuKategori",
                newName: "IX_KonuKategori_KonuId");

            migrationBuilder.RenameIndex(
                name: "IX_KonuKategoriler_KategoriId",
                table: "KonuKategori",
                newName: "IX_KonuKategori_KategoriId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KonuKategori",
                table: "KonuKategori",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kategori",
                table: "Kategori",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KonuKategori_Kategori_KategoriId",
                table: "KonuKategori",
                column: "KategoriId",
                principalTable: "Kategori",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KonuKategori_Konular_KonuId",
                table: "KonuKategori",
                column: "KonuId",
                principalTable: "Konular",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
