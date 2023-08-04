using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt_Programowanie.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Create1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Slowo1",
                table: "Wzory",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Slowo2",
                table: "Wzory",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Slowo3",
                table: "Wzory",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Slowo4",
                table: "Wzory",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Slowo5",
                table: "Wzory",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Slowo6",
                table: "Wzory",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slowo1",
                table: "Wzory");

            migrationBuilder.DropColumn(
                name: "Slowo2",
                table: "Wzory");

            migrationBuilder.DropColumn(
                name: "Slowo3",
                table: "Wzory");

            migrationBuilder.DropColumn(
                name: "Slowo4",
                table: "Wzory");

            migrationBuilder.DropColumn(
                name: "Slowo5",
                table: "Wzory");

            migrationBuilder.DropColumn(
                name: "Slowo6",
                table: "Wzory");
        }
    }
}
