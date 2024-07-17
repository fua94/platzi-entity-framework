using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace home.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("17f5abc5-59ef-4564-acfe-ae4cb8c0a6c0"), null, "Pendientes" },
                    { new Guid("17f5abc5-59ef-4564-acfe-ae4cb8c0a6c1"), null, "Completadas" },
                    { new Guid("17f5abc5-59ef-4564-acfe-ae4cb8c0a6c2"), null, "En progreso" }
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "Id", "CategoryId", "CreateAt", "Description", "Effort", "Priority", "Title" },
                values: new object[] { new Guid("17f5abc5-59ef-4564-acfe-ae4cb8c0a6c3"), new Guid("17f5abc5-59ef-4564-acfe-ae4cb8c0a6c0"), new DateTime(2024, 7, 17, 13, 6, 10, 96, DateTimeKind.Local).AddTicks(9610), null, 9, 2, "MVP proyecto tareas" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("17f5abc5-59ef-4564-acfe-ae4cb8c0a6c1"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("17f5abc5-59ef-4564-acfe-ae4cb8c0a6c2"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "Id",
                keyValue: new Guid("17f5abc5-59ef-4564-acfe-ae4cb8c0a6c3"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("17f5abc5-59ef-4564-acfe-ae4cb8c0a6c0"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
