﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GymCore.Infrastructure.Migrations.GymCoreDB
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExerciseEntity",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                name: "UserEntity",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutEntity",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "now()"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatedById = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutEntity_UserEntity_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseHistoryHeaderEntity",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "now()"),
                    WorkoutId = table.Column<long>(nullable: true),
                    StartDateTime = table.Column<DateTime>(nullable: false),
                    EndDateTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseHistoryHeaderEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseHistoryHeaderEntity_UserEntity_UserId",
                        column: x => x.UserId,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExerciseHistoryHeaderEntity_WorkoutEntity_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "WorkoutEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserWorkoutEntity",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    WorkoutId = table.Column<long>(nullable: false),
                    Id = table.Column<long>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWorkoutEntity", x => new { x.UserId, x.WorkoutId });
                    table.ForeignKey(
                        name: "FK_UserWorkoutEntity_UserEntity_UserId",
                        column: x => x.UserId,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserWorkoutEntity_WorkoutEntity_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "WorkoutEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutAreaEntity",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "now()"),
                    WorkoutId = table.Column<long>(nullable: true),
                    QtyRepetitions = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutAreaEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutAreaEntity_WorkoutEntity_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "WorkoutEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseHistoryLinesEntity",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "now()"),
                    ExerciseHistoryHeaderId = table.Column<long>(nullable: true),
                    ExerciseId = table.Column<long>(nullable: true),
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
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "now()"),
                    WorkoutAreaId = table.Column<long>(nullable: false),
                    ExerciseId = table.Column<long>(nullable: false),
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
                name: "IX_ExerciseHistoryHeaderEntity_UserId",
                table: "ExerciseHistoryHeaderEntity",
                column: "UserId");

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

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutEntity_CreatedById",
                table: "WorkoutEntity",
                column: "CreatedById");
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
                name: "WorkoutEntity");

            migrationBuilder.DropTable(
                name: "UserEntity");
        }
    }
}
