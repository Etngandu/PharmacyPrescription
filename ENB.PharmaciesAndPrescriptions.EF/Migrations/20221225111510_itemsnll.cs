using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENB.PharmaciesAndPrescriptions.EF.Migrations
{
    public partial class itemsnll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_item_Drug_medication_Drug_medicationId",
                table: "Prescription_item");

            migrationBuilder.AlterColumn<int>(
                name: "Drug_medicationId",
                table: "Prescription_item",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_item_Drug_medication_Drug_medicationId",
                table: "Prescription_item",
                column: "Drug_medicationId",
                principalTable: "Drug_medication",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_item_Drug_medication_Drug_medicationId",
                table: "Prescription_item");

            migrationBuilder.AlterColumn<int>(
                name: "Drug_medicationId",
                table: "Prescription_item",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_item_Drug_medication_Drug_medicationId",
                table: "Prescription_item",
                column: "Drug_medicationId",
                principalTable: "Drug_medication",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
