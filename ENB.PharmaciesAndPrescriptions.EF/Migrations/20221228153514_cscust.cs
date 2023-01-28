using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENB.PharmaciesAndPrescriptions.EF.Migrations
{
    public partial class cscust : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Prescription_item",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_item_CustomerId",
                table: "Prescription_item",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_item_Customers_CustomerId",
                table: "Prescription_item",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_item_Customers_CustomerId",
                table: "Prescription_item");

            migrationBuilder.DropIndex(
                name: "IX_Prescription_item_CustomerId",
                table: "Prescription_item");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Prescription_item");
        }
    }
}
