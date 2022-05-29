using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace moneylandingApp.Migrations
{
    public partial class addingOwes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "OweAmont",
                table: "borrowers",
                type: "numeric",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OweAmont",
                table: "borrowers");
        }
    }
}
