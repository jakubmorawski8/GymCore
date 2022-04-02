using Microsoft.EntityFrameworkCore.Migrations;

namespace GymCore.Persistence.Migrations
{
    public partial class nLogTargetTableRemoveSomeFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "machine_name",
                table: "logs");

            migrationBuilder.DropColumn(
                name: "thread",
                table: "logs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "machine_name",
                table: "logs",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "thread",
                table: "logs",
                type: "text",
                nullable: true);
        }
    }
}
