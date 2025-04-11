using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TripExperienceAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedActivityScheduleFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DurationUnit",
                table: "Activities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDateTime",
                table: "Activities",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sequence",
                table: "Activities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDateTime",
                table: "Activities",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationUnit",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "EndDateTime",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "Sequence",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "StartDateTime",
                table: "Activities");
        }
    }
}
