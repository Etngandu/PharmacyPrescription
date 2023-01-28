using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENB.PharmaciesAndPrescriptions.EF.Migrations
{
    public partial class KeyPres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Physicians_PhysicianId",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "Customer_id",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "Physician_id",
                table: "Prescription");

            migrationBuilder.AlterColumn<int>(
                name: "PhysicianId",
                table: "Prescription",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Physicians_PhysicianId",
                table: "Prescription",
                column: "PhysicianId",
                principalTable: "Physicians",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Physicians_PhysicianId",
                table: "Prescription");

            migrationBuilder.AlterColumn<int>(
                name: "PhysicianId",
                table: "Prescription",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Customer_id",
                table: "Prescription",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Physician_id",
                table: "Prescription",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Physicians_PhysicianId",
                table: "Prescription",
                column: "PhysicianId",
                principalTable: "Physicians",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
