using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymCore.Persistence.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExerciseEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "now()"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseHistoryHeaderEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "now()"),
                    UserId = table.Column<Guid>(nullable: false),
                    WorkoutId = table.Column<Guid>(nullable: true),
                    StartDateTime = table.Column<DateTime>(nullable: false),
                    EndDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseHistoryHeaderEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseHistoryHeaderEntity_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserWorkoutEntity",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    WorkoutId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWorkoutEntity", x => new { x.UserId, x.WorkoutId });
                    table.ForeignKey(
                        name: "FK_UserWorkoutEntity_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutAreaEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "now()"),
                    WorkoutId = table.Column<Guid>(nullable: true),
                    QtyRepetitions = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutAreaEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutAreaEntity_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseHistoryLinesEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "now()"),
                    ExerciseHistoryHeaderId = table.Column<Guid>(nullable: true),
                    ExerciseId = table.Column<Guid>(nullable: true),
                    Load = table.Column<double>(nullable: false),
                    QtyRepetitions = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseHistoryLinesEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseHistoryLinesEntity_ExerciseHistoryHeaderEntity_Exer~",
                        column: x => x.ExerciseHistoryHeaderId,
                        principalTable: "ExerciseHistoryHeaderEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExerciseHistoryLinesEntity_ExerciseEntity_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "ExerciseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutAreaExerciseEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "now()"),
                    WorkoutAreaId = table.Column<Guid>(nullable: false),
                    ExerciseId = table.Column<Guid>(nullable: false),
                    Load = table.Column<double>(nullable: false),
                    QtyRepetitions = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutAreaExerciseEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutAreaExerciseEntity_ExerciseEntity_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "ExerciseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutAreaExerciseEntity_WorkoutAreaEntity_WorkoutAreaId",
                        column: x => x.WorkoutAreaId,
                        principalTable: "WorkoutAreaEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseHistoryHeaderEntity_WorkoutId",
                table: "ExerciseHistoryHeaderEntity",
                column: "WorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseHistoryLinesEntity_ExerciseHistoryHeaderId",
                table: "ExerciseHistoryLinesEntity",
                column: "ExerciseHistoryHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseHistoryLinesEntity_ExerciseId",
                table: "ExerciseHistoryLinesEntity",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWorkoutEntity_WorkoutId",
                table: "UserWorkoutEntity",
                column: "WorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutAreaEntity_WorkoutId",
                table: "WorkoutAreaEntity",
                column: "WorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutAreaExerciseEntity_ExerciseId",
                table: "WorkoutAreaExerciseEntity",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutAreaExerciseEntity_WorkoutAreaId",
                table: "WorkoutAreaExerciseEntity",
                column: "WorkoutAreaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseHistoryLinesEntity");

            migrationBuilder.DropTable(
                name: "UserWorkoutEntity");

            migrationBuilder.DropTable(
                name: "WorkoutAreaExerciseEntity");

            migrationBuilder.DropTable(
                name: "ExerciseHistoryHeaderEntity");

            migrationBuilder.DropTable(
                name: "ExerciseEntity");

            migrationBuilder.DropTable(
                name: "WorkoutAreaEntity");

            migrationBuilder.DropTable(
                name: "Workouts");
        }
    }
}
