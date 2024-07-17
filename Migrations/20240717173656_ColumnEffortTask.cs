using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace home.Migrations
{
    public partial class ColumnEffortTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Effort",
                table: "Task",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Effort",
                table: "Task");
        }
    }
}
