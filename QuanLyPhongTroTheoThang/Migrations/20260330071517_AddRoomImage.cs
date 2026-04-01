using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyPhongTroTheoThang.Migrations
{
    /// <inheritdoc />
    public partial class AddRoomImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Rooms");
        }
    }
}
