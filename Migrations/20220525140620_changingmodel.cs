using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace moneylandingApp.Migrations
{
    public partial class changingmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OweAmont",
                table: "borrowers");

            migrationBuilder.DropColumn(
                name: "RepayedAmount",
                table: "borrowers");

            migrationBuilder.AddColumn<bool>(
                name: "Repayed",
                table: "borrowers",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Repayed",
                table: "borrowers");

            migrationBuilder.AddColumn<decimal>(
                name: "OweAmont",
                table: "borrowers",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RepayedAmount",
                table: "borrowers",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
