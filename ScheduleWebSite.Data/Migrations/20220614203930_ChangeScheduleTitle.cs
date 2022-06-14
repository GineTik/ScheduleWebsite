using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScheduleWebSite.Data.Migrations
{
    public partial class ChangeScheduleTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Schedules",
                newName: "Title");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Schedules",
                newName: "Name");
        }
    }
}
