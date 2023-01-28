using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENB.PharmaciesAndPrescriptions.EF.Migrations
{
    public partial class Drgupdt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Company_name",
                table: "Drug_Companies",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AddColumn<string>(
                name: "ContactPerson",
                table: "Drug_Companies",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Drug_Companies",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Drug_Companies",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactPerson",
                table: "Drug_Companies");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Drug_Companies");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Drug_Companies");

            migrationBuilder.AlterColumn<string>(
                name: "Company_name",
                table: "Drug_Companies",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);
        }
    }
}
