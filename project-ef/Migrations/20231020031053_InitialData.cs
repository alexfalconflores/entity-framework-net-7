using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace project_ef.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Task",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 19, 22, 10, 53, 69, DateTimeKind.Local).AddTicks(9500),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Description", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("311fcc30-77c4-4ea0-9d03-685266df766f"), null, "Actividades Personales", 50 },
                    { new Guid("f41c1bb2-b8ff-447e-a1df-0bf091f26d1c"), null, "Actividades Pendientes", 20 }
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "Id", "CategoryId", "Description", "TaskPriority", "Title" },
                values: new object[,]
                {
                    { new Guid("8b9f19f8-7900-4e05-ac39-e53e4c8630d6"), new Guid("311fcc30-77c4-4ea0-9d03-685266df766f"), null, 0, "Terminar de ver pelicula" },
                    { new Guid("d80f1fd0-d62a-49db-8da2-79ff95c712c7"), new Guid("f41c1bb2-b8ff-447e-a1df-0bf091f26d1c"), null, 1, "Pago de servicios publicos" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "Id",
                keyValue: new Guid("8b9f19f8-7900-4e05-ac39-e53e4c8630d6"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "Id",
                keyValue: new Guid("d80f1fd0-d62a-49db-8da2-79ff95c712c7"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("311fcc30-77c4-4ea0-9d03-685266df766f"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("f41c1bb2-b8ff-447e-a1df-0bf091f26d1c"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Task",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2023, 10, 19, 22, 10, 53, 69, DateTimeKind.Local).AddTicks(9500));

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
