using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDataTimeDefaultTwoN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Homework",
                keyColumn: "HomeworkId",
                keyValue: new Guid("42ec6ad2-eb0b-4aa5-90cf-a6d2d0131536"),
                column: "CreationDate",
                value: new DateTime(2023, 1, 7, 3, 33, 0, 789, DateTimeKind.Utc).AddTicks(1431));

            migrationBuilder.UpdateData(
                table: "Homework",
                keyColumn: "HomeworkId",
                keyValue: new Guid("53ec6ad2-eb0b-4aa5-90cf-a6d2d0131536"),
                column: "CreationDate",
                value: new DateTime(2023, 1, 7, 3, 33, 0, 789, DateTimeKind.Utc).AddTicks(1431));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Homework",
                keyColumn: "HomeworkId",
                keyValue: new Guid("42ec6ad2-eb0b-4aa5-90cf-a6d2d0131536"),
                column: "CreationDate",
                value: new DateTime(2023, 1, 7, 3, 30, 47, 100, DateTimeKind.Utc).AddTicks(7921));

            migrationBuilder.UpdateData(
                table: "Homework",
                keyColumn: "HomeworkId",
                keyValue: new Guid("53ec6ad2-eb0b-4aa5-90cf-a6d2d0131536"),
                column: "CreationDate",
                value: new DateTime(2023, 1, 7, 3, 30, 47, 100, DateTimeKind.Utc).AddTicks(7921));
        }
    }
}
