using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymCore.Persistence.Migrations
{
    public partial class nLogCreateTargetTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "logs",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_date = table.Column<DateTime>(nullable: false),
                    modified_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()"),
                    call_site = table.Column<string>(nullable: true),
                    exception = table.Column<string>(nullable: true),
                    level = table.Column<string>(nullable: true),
                    logger = table.Column<string>(nullable: true),
                    machine_name = table.Column<string>(nullable: true),
                    message = table.Column<string>(nullable: true),
                    stack_trace = table.Column<string>(nullable: true),
                    thread = table.Column<string>(nullable: true),
                    username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_logs", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "logs");
        }
    }
}
