using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDataTimeDefault : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Homework",
                keyColumn: "HomeworkId",
                keyValue: new Guid("42ec6ad2-eb0b-4aa5-90cf-a6d2d0131536"),
                column: "CreationDate",
                value: new DateTime(2023, 1, 6, 20, 18, 34, 586, DateTimeKind.Local).AddTicks(4651));

            migrationBuilder.UpdateData(
                table: "Homework",
                keyColumn: "HomeworkId",
                keyValue: new Guid("53ec6ad2-eb0b-4aa5-90cf-a6d2d0131536"),
                column: "CreationDate",
                value: new DateTime(2023, 1, 6, 20, 18, 34, 586, DateTimeKind.Local).AddTicks(4630));
        }
    }
}
