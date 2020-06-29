using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreBlogProject.Data.Migrations
{
    public partial class commentAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MainComments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    PostId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainComments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubComments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    MainCommentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubComments_MainComments_MainCommentId",
                        column: x => x.MainCommentId,
                        principalTable: "MainComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_MainComments_PostId",
                table: "MainComments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_SubComments_MainCommentId",
                table: "SubComments",
                column: "MainCommentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubComments");

            migrationBuilder.DropTable(
                name: "MainComments");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                columns: new[] { "AddTime", "EditTime" },
                values: new object[] { new DateTime(2020, 6, 21, 14, 0, 14, 283, DateTimeKind.Local).AddTicks(8258), new DateTime(2020, 6, 21, 14, 0, 14, 285, DateTimeKind.Local).AddTicks(4496) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                columns: new[] { "AddTime", "EditTime" },
                values: new object[] { new DateTime(2020, 6, 21, 14, 0, 14, 285, DateTimeKind.Local).AddTicks(5611), new DateTime(2020, 6, 21, 14, 0, 14, 285, DateTimeKind.Local).AddTicks(5625) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                columns: new[] { "AddTime", "EditTime" },
                values: new object[] { new DateTime(2020, 6, 21, 14, 0, 14, 285, DateTimeKind.Local).AddTicks(5680), new DateTime(2020, 6, 21, 14, 0, 14, 285, DateTimeKind.Local).AddTicks(5684) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 4,
                columns: new[] { "AddTime", "EditTime" },
                values: new object[] { new DateTime(2020, 6, 21, 14, 0, 14, 285, DateTimeKind.Local).AddTicks(5718), new DateTime(2020, 6, 21, 14, 0, 14, 285, DateTimeKind.Local).AddTicks(5720) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 5,
                columns: new[] { "AddTime", "EditTime" },
                values: new object[] { new DateTime(2020, 6, 21, 14, 0, 14, 285, DateTimeKind.Local).AddTicks(5751), new DateTime(2020, 6, 21, 14, 0, 14, 285, DateTimeKind.Local).AddTicks(5753) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 6,
                columns: new[] { "AddTime", "EditTime" },
                values: new object[] { new DateTime(2020, 6, 21, 14, 0, 14, 285, DateTimeKind.Local).AddTicks(5789), new DateTime(2020, 6, 21, 14, 0, 14, 285, DateTimeKind.Local).AddTicks(5792) });
        }
    }
}
