using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENB.PharmaciesAndPrescriptions.EF.Migrations
{
    public partial class Drgcpm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Drug_Companies",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Drug_Companies",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MgfLicence",
                table: "Drug_Companies",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Numberstreet",
                table: "Drug_Companies",
                type: "nvarchar(600)",
                maxLength: 600,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State_province_county",
                table: "Drug_Companies",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Drug_Companies",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Drug_Companies");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Drug_Companies");

            migrationBuilder.DropColumn(
                name: "MgfLicence",
                table: "Drug_Companies");

            migrationBuilder.DropColumn(
                name: "Numberstreet",
                table: "Drug_Companies");

            migrationBuilder.DropColumn(
                name: "State_province_county",
                table: "Drug_Companies");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Drug_Companies");
        }
    }
}
