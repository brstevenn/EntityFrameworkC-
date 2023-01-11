using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDataTimeDefaultTwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Homework",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 7, 3, 20, 42, 916, DateTimeKind.Utc).AddTicks(8377),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.UpdateData(
                table: "Homework",
                keyColumn: "HomeworkId",
                keyValue: new Guid("42ec6ad2-eb0b-4aa5-90cf-a6d2d0131536"),
                column: "CreationDate",
                value: new DateTime(2023, 1, 7, 3, 20, 42, 916, DateTimeKind.Utc).AddTicks(5722));

            migrationBuilder.UpdateData(
                table: "Homework",
                keyColumn: "HomeworkId",
                keyValue: new Guid("53ec6ad2-eb0b-4aa5-90cf-a6d2d0131536"),
                column: "CreationDate",
                value: new DateTime(2023, 1, 7, 3, 20, 42, 916, DateTimeKind.Utc).AddTicks(5715));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Homework",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 1, 7, 3, 20, 42, 916, DateTimeKind.Utc).AddTicks(8377));

            migrationBuilder.UpdateData(
                table: "Homework",
                keyColumn: "HomeworkId",
                keyValue: new Guid("42ec6ad2-eb0b-4aa5-90cf-a6d2d0131536"),
                column: "CreationDate",
                value: new DateTime(2023, 1, 7, 3, 19, 22, 455, DateTimeKind.Utc).AddTicks(7844));

            migrationBuilder.UpdateData(
                table: "Homework",
                keyColumn: "HomeworkId",
                keyValue: new Guid("53ec6ad2-eb0b-4aa5-90cf-a6d2d0131536"),
                column: "CreationDate",
                value: new DateTime(2023, 1, 7, 3, 19, 22, 455, DateTimeKind.Utc).AddTicks(7836));
        }
    }
}
