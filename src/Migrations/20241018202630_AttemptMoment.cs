using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessCheck.Migrations
{
    /// <inheritdoc />
    public partial class AttemptMoment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "MomentUtc",
                table: "TwelveMinutesRunAttempts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "MomentUtc",
                table: "StandingLongJumpAttempts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "MomentUtc",
                table: "ShuttleRunAttempts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "MomentUtc",
                table: "OneLegStandAttempts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "MomentUtc",
                table: "MedicineBallPushAttempts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "MomentUtc",
                table: "CoreStrengthAttempts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MomentUtc",
                table: "TwelveMinutesRunAttempts");

            migrationBuilder.DropColumn(
                name: "MomentUtc",
                table: "StandingLongJumpAttempts");

            migrationBuilder.DropColumn(
                name: "MomentUtc",
                table: "ShuttleRunAttempts");

            migrationBuilder.DropColumn(
                name: "MomentUtc",
                table: "OneLegStandAttempts");

            migrationBuilder.DropColumn(
                name: "MomentUtc",
                table: "MedicineBallPushAttempts");

            migrationBuilder.DropColumn(
                name: "MomentUtc",
                table: "CoreStrengthAttempts");
        }
    }
}
