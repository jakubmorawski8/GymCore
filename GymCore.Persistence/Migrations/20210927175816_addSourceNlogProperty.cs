using Microsoft.EntityFrameworkCore.Migrations;

namespace GymCore.Persistence.Migrations
{
    public partial class addSourceNlogProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "source",
                table: "logs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "source",
                table: "logs");
        }
    }
}
