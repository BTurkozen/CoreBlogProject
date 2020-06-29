using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreBlogProject.Data.Migrations
{
    public partial class commentPostId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainComments_Posts_PostId",
                table: "MainComments");

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "MainComments",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                columns: new[] { "AddTime", "EditTime" },
                values: new object[] { new DateTime(2020, 6, 29, 15, 12, 27, 486, DateTimeKind.Local).AddTicks(8511), new DateTime(2020, 6, 29, 15, 12, 27, 488, DateTimeKind.Local).AddTicks(680) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                columns: new[] { "AddTime", "EditTime" },
                values: new object[] { new DateTime(2020, 6, 29, 15, 12, 27, 488, DateTimeKind.Local).AddTicks(1894), new DateTime(2020, 6, 29, 15, 12, 27, 488, DateTimeKind.Local).AddTicks(1909) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                columns: new[] { "AddTime", "EditTime" },
                values: new object[] { new DateTime(2020, 6, 29, 15, 12, 27, 488, DateTimeKind.Local).AddTicks(1967), new DateTime(2020, 6, 29, 15, 12, 27, 488, DateTimeKind.Local).AddTicks(1970) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 4,
                columns: new[] { "AddTime", "EditTime" },
                values: new object[] { new DateTime(2020, 6, 29, 15, 12, 27, 488, DateTimeKind.Local).AddTicks(2001), new DateTime(2020, 6, 29, 15, 12, 27, 488, DateTimeKind.Local).AddTicks(2003) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 5,
                columns: new[] { "AddTime", "EditTime" },
                values: new object[] { new DateTime(2020, 6, 29, 15, 12, 27, 488, DateTimeKind.Local).AddTicks(2033), new DateTime(2020, 6, 29, 15, 12, 27, 488, DateTimeKind.Local).AddTicks(2035) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 6,
                columns: new[] { "AddTime", "EditTime" },
                values: new object[] { new DateTime(2020, 6, 29, 15, 12, 27, 488, DateTimeKind.Local).AddTicks(2070), new DateTime(2020, 6, 29, 15, 12, 27, 488, DateTimeKind.Local).AddTicks(2072) });

            migrationBuilder.AddForeignKey(
                name: "FK_MainComments_Posts_PostId",
                table: "MainComments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainComments_Posts_PostId",
                table: "MainComments");

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "MainComments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                columns: new[] { "AddTime", "EditTime" },
                values: new object[] { new DateTime(2020, 6, 29, 15, 4, 10, 983, DateTimeKind.Local).AddTicks(6053), new DateTime(2020, 6, 29, 15, 4, 10, 984, DateTimeKind.Local).AddTicks(5601) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                columns: new[] { "AddTime", "EditTime" },
                values: new object[] { new DateTime(2020, 6, 29, 15, 4, 10, 984, DateTimeKind.Local).AddTicks(6566), new DateTime(2020, 6, 29, 15, 4, 10, 984, DateTimeKind.Local).AddTicks(6580) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                columns: new[] { "AddTime", "EditTime" },
                values: new object[] { new DateTime(2020, 6, 29, 15, 4, 10, 984, DateTimeKind.Local).AddTicks(6636), new DateTime(2020, 6, 29, 15, 4, 10, 984, DateTimeKind.Local).AddTicks(6639) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 4,
                columns: new[] { "AddTime", "EditTime" },
                values: new object[] { new DateTime(2020, 6, 29, 15, 4, 10, 984, DateTimeKind.Local).AddTicks(6671), new DateTime(2020, 6, 29, 15, 4, 10, 984, DateTimeKind.Local).AddTicks(6673) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 5,
                columns: new[] { "AddTime", "EditTime" },
                values: new object[] { new DateTime(2020, 6, 29, 15, 4, 10, 984, DateTimeKind.Local).AddTicks(6702), new DateTime(2020, 6, 29, 15, 4, 10, 984, DateTimeKind.Local).AddTicks(6704) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 6,
                columns: new[] { "AddTime", "EditTime" },
                values: new object[] { new DateTime(2020, 6, 29, 15, 4, 10, 984, DateTimeKind.Local).AddTicks(6738), new DateTime(2020, 6, 29, 15, 4, 10, 984, DateTimeKind.Local).AddTicks(6740) });

            migrationBuilder.AddForeignKey(
                name: "FK_MainComments_Posts_PostId",
                table: "MainComments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
