using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyPhongTroTheoThang.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTenantName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Tenants",
                newName: "TenantName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TenantName",
                table: "Tenants",
                newName: "Name");
        }
    }
}
