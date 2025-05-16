using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FitnessCheck.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cohorts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Profession = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Baccalaureate = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SchoolYear = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    FirstSchoolYear = table.Column<uint>(type: "int unsigned", nullable: false),
                    ClassNameVocationalEducation = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClassNameBaccalaureate = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cohorts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Grade = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Points = table.Column<uint>(type: "int unsigned", nullable: false),
                    MedicineBallPush = table.Column<int>(type: "int", nullable: false),
                    StandingLongJump = table.Column<int>(type: "int", nullable: false),
                    CoreStrength = table.Column<int>(type: "int", nullable: false),
                    OneLegStand = table.Column<int>(type: "int", nullable: false),
                    ShuttleRun = table.Column<int>(type: "int", nullable: false),
                    TwelveMinutesRun = table.Column<float>(type: "float", nullable: false),
                    Gender = table.Column<string>(type: "varchar(1)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CoreStrengthAttempts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ResultInSeconds = table.Column<uint>(type: "int unsigned", nullable: false),
                    AttemptNumber = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Points = table.Column<uint>(type: "int unsigned", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Gender = table.Column<string>(type: "varchar(1)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CohortId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoreStrengthAttempts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoreStrengthAttempts_Cohorts_CohortId",
                        column: x => x.CohortId,
                        principalTable: "Cohorts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MedicineBallPushAttempts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ResultInCentimeters = table.Column<uint>(type: "int unsigned", nullable: false),
                    AttemptNumber = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Points = table.Column<uint>(type: "int unsigned", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Gender = table.Column<string>(type: "varchar(1)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CohortId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineBallPushAttempts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicineBallPushAttempts_Cohorts_CohortId",
                        column: x => x.CohortId,
                        principalTable: "Cohorts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OneLegStandAttempts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Foot = table.Column<int>(type: "int", nullable: false),
                    ResultInSeconds = table.Column<uint>(type: "int unsigned", nullable: false),
                    AttemptNumber = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Points = table.Column<uint>(type: "int unsigned", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Gender = table.Column<string>(type: "varchar(1)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CohortId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OneLegStandAttempts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OneLegStandAttempts_Cohorts_CohortId",
                        column: x => x.CohortId,
                        principalTable: "Cohorts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShuttleRunAttempts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ResultInMilliseconds = table.Column<uint>(type: "int unsigned", nullable: false),
                    AttemptNumber = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Points = table.Column<uint>(type: "int unsigned", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Gender = table.Column<string>(type: "varchar(1)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CohortId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShuttleRunAttempts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShuttleRunAttempts_Cohorts_CohortId",
                        column: x => x.CohortId,
                        principalTable: "Cohorts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StandingLongJumpAttempts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ResultInCentimeters = table.Column<uint>(type: "int unsigned", nullable: false),
                    AttemptNumber = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Points = table.Column<uint>(type: "int unsigned", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Gender = table.Column<string>(type: "varchar(1)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CohortId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandingLongJumpAttempts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StandingLongJumpAttempts_Cohorts_CohortId",
                        column: x => x.CohortId,
                        principalTable: "Cohorts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TwelveMinutesRunAttempts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ResultInRounds = table.Column<float>(type: "float", nullable: false),
                    AttemptNumber = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Points = table.Column<uint>(type: "int unsigned", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Gender = table.Column<string>(type: "varchar(1)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CohortId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TwelveMinutesRunAttempts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TwelveMinutesRunAttempts_Cohorts_CohortId",
                        column: x => x.CohortId,
                        principalTable: "Cohorts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Results",
                columns: new[] { "ID", "CoreStrength", "Gender", "Grade", "MedicineBallPush", "OneLegStand", "Points", "ShuttleRun", "StandingLongJump", "TwelveMinutesRun" },
                values: new object[,]
                {
                    { 1, 0, "m", "TE", 0, 0, 0u, 100000, 0, 0f },
                    { 2, 5, "m", "TE", 410, 11, 1u, 12260, 165, 31f },
                    { 3, 10, "m", "TE", 420, 14, 2u, 12120, 170, 31.5f },
                    { 4, 15, "m", "TE", 430, 17, 3u, 11980, 175, 32f },
                    { 5, 20, "m", "TE", 440, 20, 4u, 11840, 180, 32.5f },
                    { 6, 25, "m", "TE", 450, 23, 5u, 11700, 185, 33f },
                    { 7, 30, "m", "TE", 470, 26, 6u, 11560, 190, 33.5f },
                    { 8, 40, "m", "EE", 490, 29, 7u, 11420, 195, 34.5f },
                    { 9, 50, "m", "EE", 510, 31, 8u, 11280, 200, 35f },
                    { 10, 60, "m", "EE", 530, 33, 9u, 11140, 205, 35.5f },
                    { 11, 70, "m", "EE", 550, 35, 10u, 11000, 210, 36f },
                    { 12, 80, "m", "EE", 570, 37, 11u, 10860, 215, 36.5f },
                    { 13, 90, "m", "EE", 590, 39, 12u, 10720, 220, 37.5f },
                    { 14, 100, "m", "EE", 610, 41, 13u, 10580, 225, 38f },
                    { 15, 110, "m", "EE", 630, 43, 14u, 10440, 230, 38.5f },
                    { 16, 120, "m", "EE", 650, 45, 15u, 10300, 235, 39f },
                    { 17, 130, "m", "UEE", 670, 47, 16u, 10160, 240, 39.5f },
                    { 18, 145, "m", "UEE", 690, 49, 17u, 10020, 245, 40.5f },
                    { 19, 160, "m", "UEE", 710, 51, 18u, 9880, 250, 41f },
                    { 20, 175, "m", "UEE", 730, 54, 19u, 9740, 255, 41.5f },
                    { 21, 190, "m", "UEE", 750, 58, 20u, 9600, 260, 42f },
                    { 22, 210, "m", "UEE", 770, 64, 21u, 9460, 265, 42.5f },
                    { 23, 230, "m", "UED", 790, 71, 22u, 9320, 270, 43.5f },
                    { 24, 250, "m", "UED", 810, 79, 23u, 9180, 275, 44f },
                    { 25, 270, "m", "UED", 830, 88, 24u, 9040, 280, 44.5f },
                    { 26, 290, "m", "UED", 850, 100, 25u, 8900, 285, 45f },
                    { 27, 0, "f", "TE", 0, 0, 0u, 100000, 0, 0f },
                    { 28, 5, "f", "TE", 316, 11, 1u, 13000, 116, 24f },
                    { 29, 9, "f", "TE", 321, 14, 2u, 12950, 119, 24.5f },
                    { 30, 14, "f", "TE", 327, 17, 3u, 12820, 123, 25f },
                    { 31, 18, "f", "TE", 332, 20, 4u, 12680, 126, 26f },
                    { 32, 23, "f", "TE", 338, 23, 5u, 12540, 130, 26.5f },
                    { 33, 27, "f", "TE", 349, 26, 6u, 12400, 133, 27f },
                    { 34, 36, "f", "EE", 360, 29, 7u, 12270, 137, 28f },
                    { 35, 45, "f", "EE", 371, 31, 8u, 12130, 140, 28.5f },
                    { 36, 54, "f", "EE", 382, 33, 9u, 11990, 144, 29f },
                    { 37, 63, "f", "EE", 393, 35, 10u, 11860, 147, 30f },
                    { 38, 72, "f", "EE", 404, 37, 11u, 11720, 151, 30.5f },
                    { 39, 81, "f", "EE", 415, 39, 12u, 11580, 154, 31f },
                    { 40, 90, "f", "EE", 426, 41, 13u, 11440, 158, 32f },
                    { 41, 99, "f", "EE", 437, 43, 14u, 11310, 161, 32.5f },
                    { 42, 108, "f", "EE", 448, 45, 15u, 11170, 165, 33f },
                    { 43, 117, "f", "UEE", 459, 47, 16u, 11030, 168, 34f },
                    { 44, 131, "f", "UEE", 470, 49, 17u, 10900, 172, 34.5f },
                    { 45, 144, "f", "UEE", 481, 51, 18u, 10760, 175, 35f },
                    { 46, 158, "f", "UEE", 492, 54, 19u, 10620, 179, 36f },
                    { 47, 171, "f", "UEE", 503, 58, 20u, 10480, 182, 36.5f },
                    { 48, 189, "f", "UEE", 514, 64, 21u, 10360, 186, 37f },
                    { 49, 207, "f", "UED", 525, 71, 22u, 10220, 189, 38f },
                    { 50, 225, "f", "UED", 536, 79, 23u, 10080, 193, 38.5f },
                    { 51, 243, "f", "UED", 547, 88, 24u, 9940, 196, 39f },
                    { 52, 261, "f", "UED", 558, 100, 25u, 9800, 200, 40f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoreStrengthAttempts_CohortId",
                table: "CoreStrengthAttempts",
                column: "CohortId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineBallPushAttempts_CohortId",
                table: "MedicineBallPushAttempts",
                column: "CohortId");

            migrationBuilder.CreateIndex(
                name: "IX_OneLegStandAttempts_CohortId",
                table: "OneLegStandAttempts",
                column: "CohortId");

            migrationBuilder.CreateIndex(
                name: "IX_ShuttleRunAttempts_CohortId",
                table: "ShuttleRunAttempts",
                column: "CohortId");

            migrationBuilder.CreateIndex(
                name: "IX_StandingLongJumpAttempts_CohortId",
                table: "StandingLongJumpAttempts",
                column: "CohortId");

            migrationBuilder.CreateIndex(
                name: "IX_TwelveMinutesRunAttempts_CohortId",
                table: "TwelveMinutesRunAttempts",
                column: "CohortId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoreStrengthAttempts");

            migrationBuilder.DropTable(
                name: "MedicineBallPushAttempts");

            migrationBuilder.DropTable(
                name: "OneLegStandAttempts");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "ShuttleRunAttempts");

            migrationBuilder.DropTable(
                name: "StandingLongJumpAttempts");

            migrationBuilder.DropTable(
                name: "TwelveMinutesRunAttempts");

            migrationBuilder.DropTable(
                name: "Cohorts");
        }
    }
}
