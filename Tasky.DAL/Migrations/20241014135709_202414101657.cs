using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tasky.DAL.Migrations
{
    /// <inheritdoc />
    public partial class _202414101657 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KategoriId",
                table: "Kategoriler");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KategoriId",
                table: "Kategoriler",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
