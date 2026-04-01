using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyPhongTroTheoThang.Migrations
{
    /// <inheritdoc />
    public partial class AddNotesToBill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Bills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Bills");
        }
    }
}
