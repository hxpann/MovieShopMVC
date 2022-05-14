using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UpdatePurchaseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PurchaseNumer",
                table: "Purchase",
                newName: "PurchaseNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Purchase_PurchaseNumer",
                table: "Purchase",
                newName: "IX_Purchase_PurchaseNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PurchaseNumber",
                table: "Purchase",
                newName: "PurchaseNumer");

            migrationBuilder.RenameIndex(
                name: "IX_Purchase_PurchaseNumber",
                table: "Purchase",
                newName: "IX_Purchase_PurchaseNumer");
        }
    }
}
