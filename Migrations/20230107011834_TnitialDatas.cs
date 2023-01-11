using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class TnitialDatas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Homework",
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
                columns: new[] { "CategoryId", "Description", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("64ec6ad2-eb0b-4aa5-90cf-a6d2d0131536"), null, "Actividades personales", 50 },
                    { new Guid("75ec6ad2-eb0b-4aa5-90cf-a6d2d0131536"), null, "Actividades pendientes", 20 }
                });

            migrationBuilder.InsertData(
                table: "Homework",
                columns: new[] { "HomeworkId", "CategoryId", "CreationDate", "Description", "PriorityHomework", "Process", "Title" },
                values: new object[,]
                {
                    { new Guid("42ec6ad2-eb0b-4aa5-90cf-a6d2d0131536"), new Guid("75ec6ad2-eb0b-4aa5-90cf-a6d2d0131536"), new DateTime(2023, 1, 6, 20, 18, 34, 586, DateTimeKind.Local).AddTicks(4651), null, 0, "Pending", "Terminar serie" },
                    { new Guid("53ec6ad2-eb0b-4aa5-90cf-a6d2d0131536"), new Guid("75ec6ad2-eb0b-4aa5-90cf-a6d2d0131536"), new DateTime(2023, 1, 6, 20, 18, 34, 586, DateTimeKind.Local).AddTicks(4630), null, 1, "Pending", "Pago de servicios" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("64ec6ad2-eb0b-4aa5-90cf-a6d2d0131536"));

            migrationBuilder.DeleteData(
                table: "Homework",
                keyColumn: "HomeworkId",
                keyValue: new Guid("42ec6ad2-eb0b-4aa5-90cf-a6d2d0131536"));

            migrationBuilder.DeleteData(
                table: "Homework",
                keyColumn: "HomeworkId",
                keyValue: new Guid("53ec6ad2-eb0b-4aa5-90cf-a6d2d0131536"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("75ec6ad2-eb0b-4aa5-90cf-a6d2d0131536"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Homework",
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
