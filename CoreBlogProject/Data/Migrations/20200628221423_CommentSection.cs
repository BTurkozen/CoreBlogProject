using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreBlogProject.Data.Migrations
{
    public partial class CommentSection : Migration
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
                values: new object[] { new DateTime(2020, 6, 29, 1, 14, 22, 590, DateTimeKind.Local).AddTicks(273), new DateTime(2020, 6, 29, 1, 14, 22, 591, DateTimeKind.Local).AddTicks(1306) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                columns: new[] { "AddTime", "EditTime" },
                values: new object[] { new DateTime(2020, 6, 29, 1, 14, 22, 591, DateTimeKind.Local).AddTicks(2384), new DateTime(2020, 6, 29, 1, 14, 22, 591, DateTimeKind.Local).AddTicks(2398) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                columns: new[] { "AddTime", "EditTime" },
                values: new object[] { new DateTime(2020, 6, 29, 1, 14, 22, 591, DateTimeKind.Local).AddTicks(2458), new DateTime(2020, 6, 29, 1, 14, 22, 591, DateTimeKind.Local).AddTicks(2461) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 4,
                columns: new[] { "AddTime", "EditTime" },
                values: new object[] { new DateTime(2020, 6, 29, 1, 14, 22, 591, DateTimeKind.Local).AddTicks(2494), new DateTime(2020, 6, 29, 1, 14, 22, 591, DateTimeKind.Local).AddTicks(2496) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 5,
                columns: new[] { "AddTime", "EditTime" },
                values: new object[] { new DateTime(2020, 6, 29, 1, 14, 22, 591, DateTimeKind.Local).AddTicks(2527), new DateTime(2020, 6, 29, 1, 14, 22, 591, DateTimeKind.Local).AddTicks(2529) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 6,
                columns: new[] { "AddTime", "EditTime" },
                values: new object[] { new DateTime(2020, 6, 29, 1, 14, 22, 591, DateTimeKind.Local).AddTicks(2565), new DateTime(2020, 6, 29, 1, 14, 22, 591, DateTimeKind.Local).AddTicks(2567) });

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
