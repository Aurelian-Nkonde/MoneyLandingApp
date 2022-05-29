using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace moneylandingApp.Migrations
{
    public partial class addingApproved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Approved",
                table: "borrowers",
                type: "boolean",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Approved",
                table: "borrowers");
        }
    }
}
