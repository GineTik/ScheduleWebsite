using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScheduleWebSite.Data.Migrations
{
    public partial class CreateDayOfScheduleModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DayOfScheduleId",
                table: "Lessons",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DaysOfSchedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaysOfSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DaysOfSchedules_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_DayOfScheduleId",
                table: "Lessons",
                column: "DayOfScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_DaysOfSchedules_ScheduleId",
                table: "DaysOfSchedules",
                column: "ScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_DaysOfSchedules_DayOfScheduleId",
                table: "Lessons",
                column: "DayOfScheduleId",
                principalTable: "DaysOfSchedules",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_DaysOfSchedules_DayOfScheduleId",
                table: "Lessons");

            migrationBuilder.DropTable(
                name: "DaysOfSchedules");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_DayOfScheduleId",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "DayOfScheduleId",
                table: "Lessons");
        }
    }
}
