using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymCore.Persistence.Migrations
{
    public partial class SnakeCaseNaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "exercise",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_date = table.Column<DateTime>(nullable: false),
                    modified_date = table.Column<DateTime>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_exercise", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "workout_entity",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_date = table.Column<DateTime>(nullable: false),
                    modified_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()"),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    created_by = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workout_entity", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "exercise_history_header_entity",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_date = table.Column<DateTime>(nullable: false),
                    modified_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()"),
                    user_id = table.Column<Guid>(nullable: false),
                    workout_id = table.Column<Guid>(nullable: true),
                    start_date_time = table.Column<DateTime>(nullable: false),
                    end_date_time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_exercise_history_header_entity", x => x.id);
                    table.ForeignKey(
                        name: "fk_exercise_history_header_entity_workout_entity_workout_id",
                        column: x => x.workout_id,
                        principalTable: "workout_entity",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_workout",
                columns: table => new
                {
                    user_id = table.Column<Guid>(nullable: false),
                    workout_id = table.Column<Guid>(nullable: false),
                    id = table.Column<Guid>(nullable: false),
                    created_date = table.Column<DateTime>(nullable: false),
                    modified_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_workout", x => new { x.user_id, x.workout_id });
                    table.ForeignKey(
                        name: "fk_user_workout_workout_entity_workout_id",
                        column: x => x.workout_id,
                        principalTable: "workout_entity",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "workout_area_entity",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_date = table.Column<DateTime>(nullable: false),
                    modified_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()"),
                    workout_id = table.Column<Guid>(nullable: true),
                    qty_repetitions = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workout_area_entity", x => x.id);
                    table.ForeignKey(
                        name: "fk_workout_area_entity_workout_entity_workout_id",
                        column: x => x.workout_id,
                        principalTable: "workout_entity",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "exercise_history_lines_entity",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_date = table.Column<DateTime>(nullable: false),
                    modified_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()"),
                    exercise_history_header_id = table.Column<Guid>(nullable: true),
                    exercise_id = table.Column<Guid>(nullable: true),
                    load = table.Column<double>(nullable: false),
                    qty_repetitions = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_exercise_history_lines_entity", x => x.id);
                    table.ForeignKey(
                        name: "fk_exercise_history_lines_entity_exercise_history_header_entit",
                        column: x => x.exercise_history_header_id,
                        principalTable: "exercise_history_header_entity",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_exercise_history_lines_entity_exercise_exercise_id",
                        column: x => x.exercise_id,
                        principalTable: "exercise",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "workout_area_exercise",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_date = table.Column<DateTime>(nullable: false),
                    modified_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()"),
                    workout_area_id = table.Column<Guid>(nullable: false),
                    exercise_id = table.Column<Guid>(nullable: false),
                    load = table.Column<double>(nullable: false),
                    qty_repetitions = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workout_area_exercise", x => x.id);
                    table.ForeignKey(
                        name: "fk_workout_area_exercise_exercise_exercise_id",
                        column: x => x.exercise_id,
                        principalTable: "exercise",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_workout_area_exercise_workout_area_entity_workout_area_id",
                        column: x => x.workout_area_id,
                        principalTable: "workout_area_entity",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_exercise_history_header_entity_workout_id",
                table: "exercise_history_header_entity",
                column: "workout_id");

            migrationBuilder.CreateIndex(
                name: "ix_exercise_history_lines_entity_exercise_history_header_id",
                table: "exercise_history_lines_entity",
                column: "exercise_history_header_id");

            migrationBuilder.CreateIndex(
                name: "ix_exercise_history_lines_entity_exercise_id",
                table: "exercise_history_lines_entity",
                column: "exercise_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_workout_workout_id",
                table: "user_workout",
                column: "workout_id");

            migrationBuilder.CreateIndex(
                name: "ix_workout_area_entity_workout_id",
                table: "workout_area_entity",
                column: "workout_id");

            migrationBuilder.CreateIndex(
                name: "ix_workout_area_exercise_exercise_id",
                table: "workout_area_exercise",
                column: "exercise_id");

            migrationBuilder.CreateIndex(
                name: "ix_workout_area_exercise_workout_area_id",
                table: "workout_area_exercise",
                column: "workout_area_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "exercise_history_lines_entity");

            migrationBuilder.DropTable(
                name: "user_workout");

            migrationBuilder.DropTable(
                name: "workout_area_exercise");

            migrationBuilder.DropTable(
                name: "exercise_history_header_entity");

            migrationBuilder.DropTable(
                name: "exercise");

            migrationBuilder.DropTable(
                name: "workout_area_entity");

            migrationBuilder.DropTable(
                name: "workout_entity");
        }
    }
}
