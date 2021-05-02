using Microsoft.EntityFrameworkCore.Migrations;

namespace GymCore.Persistence.Migrations
{
    public partial class userAddFieldsEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "UserEntity",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "UserEntity",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "UserEntity");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "UserEntity");
        }
    }
}
