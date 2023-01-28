using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENB.PharmaciesAndPrescriptions.EF.Migrations
{
    public partial class prescriptionItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_item_Drug_medication_Drug_medicationId",
                table: "Prescription_item");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_item_Prescription_PrescriptionId",
                table: "Prescription_item");

            migrationBuilder.DropColumn(
                name: "Drug_medication_Id",
                table: "Prescription_item");

            migrationBuilder.DropColumn(
                name: "Prescription_Id",
                table: "Prescription_item");

            migrationBuilder.AlterColumn<int>(
                name: "PrescriptionId",
                table: "Prescription_item",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_item_Prescription_PrescriptionId",
                table: "Prescription_item",
                column: "PrescriptionId",
                principalTable: "Prescription",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_item_Drug_medication_Drug_medicationId",
                table: "Prescription_item");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_item_Prescription_PrescriptionId",
                table: "Prescription_item");

            migrationBuilder.AlterColumn<int>(
                name: "PrescriptionId",
                table: "Prescription_item",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Drug_medicationId",
                table: "Prescription_item",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Drug_medication_Id",
                table: "Prescription_item",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Prescription_Id",
                table: "Prescription_item",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_item_Drug_medication_Drug_medicationId",
                table: "Prescription_item",
                column: "Drug_medicationId",
                principalTable: "Drug_medication",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_item_Prescription_PrescriptionId",
                table: "Prescription_item",
                column: "PrescriptionId",
                principalTable: "Prescription",
                principalColumn: "Id");
        }
    }
}
