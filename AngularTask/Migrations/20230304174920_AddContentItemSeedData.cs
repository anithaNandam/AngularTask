using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularTask.Migrations
{
    public partial class AddContentItemSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContentItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThumbnailUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DownloadCount = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DownloadUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contents", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ContentItems",
                columns: new[] { "Id", "CreatedAt", "Description", "DownloadCount", "ImageUrl", "ThumbnailUrl", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 4, 21, 49, 20, 142, DateTimeKind.Local).AddTicks(7115), "This is the first item.", 0, "https://example.com/image1.jpg", "https://example.com/thumb1.jpg", "First Item", new DateTime(2023, 3, 4, 21, 49, 20, 144, DateTimeKind.Local).AddTicks(2040) },
                    { 2, new DateTime(2023, 3, 4, 21, 49, 20, 144, DateTimeKind.Local).AddTicks(2578), "This is the second item.", 0, "https://example.com/image2.jpg", "https://example.com/thumb2.jpg", "Second Item", new DateTime(2023, 3, 4, 21, 49, 20, 144, DateTimeKind.Local).AddTicks(2584) },
                    { 3, new DateTime(2023, 3, 4, 21, 49, 20, 144, DateTimeKind.Local).AddTicks(2589), "This is the third item.", 0, "https://example.com/image3.jpg", "https://example.com/thumb3.jpg", "Third Item", new DateTime(2023, 3, 4, 21, 49, 20, 144, DateTimeKind.Local).AddTicks(2591) }
                });

            migrationBuilder.InsertData(
                table: "Contents",
                columns: new[] { "Id", "Description", "DownloadUrl", "Title" },
                values: new object[,]
                {
                    { 1, "This is a sample content.", "https://example.com/sample-content-1.pdf", "Sample Content 1" },
                    { 2, "This is another sample content.", "https://example.com/sample-content-2.pdf", "Sample Content 2" },
                    { 3, "This is yet another sample content.", "https://example.com/sample-content-3.pdf", "Sample Content 3" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContentItems");

            migrationBuilder.DropTable(
                name: "Contents");
        }
    }
}
