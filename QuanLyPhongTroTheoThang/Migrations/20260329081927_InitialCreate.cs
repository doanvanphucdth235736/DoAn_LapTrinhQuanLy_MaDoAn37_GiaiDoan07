using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyPhongTroTheoThang.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Rooms_RoomID",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Rooms_RoomID",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Tenants_TenantID",
                table: "Contracts");

            migrationBuilder.RenameColumn(
                name: "RoomID",
                table: "Bills",
                newName: "ContractID");

            migrationBuilder.RenameIndex(
                name: "IX_Bills_RoomID",
                table: "Bills",
                newName: "IX_Bills_ContractID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Contracts_ContractID",
                table: "Bills",
                column: "ContractID",
                principalTable: "Contracts",
                principalColumn: "ContractID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Rooms_RoomID",
                table: "Contracts",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "RoomID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Tenants_TenantID",
                table: "Contracts",
                column: "TenantID",
                principalTable: "Tenants",
                principalColumn: "TenantID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Contracts_ContractID",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Rooms_RoomID",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Tenants_TenantID",
                table: "Contracts");

            migrationBuilder.RenameColumn(
                name: "ContractID",
                table: "Bills",
                newName: "RoomID");

            migrationBuilder.RenameIndex(
                name: "IX_Bills_ContractID",
                table: "Bills",
                newName: "IX_Bills_RoomID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Rooms_RoomID",
                table: "Bills",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "RoomID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Rooms_RoomID",
                table: "Contracts",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "RoomID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Tenants_TenantID",
                table: "Contracts",
                column: "TenantID",
                principalTable: "Tenants",
                principalColumn: "TenantID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
