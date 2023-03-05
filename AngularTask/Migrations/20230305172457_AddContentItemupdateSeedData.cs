using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularTask.Migrations
{
    public partial class AddContentItemupdateSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalsDownloadsA4",
                table: "ContentItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalsDownloadsimage",
                table: "ContentItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalsDownloadsmobile",
                table: "ContentItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 3, 5, 21, 24, 56, 333, DateTimeKind.Local).AddTicks(8412), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse quis risus quam. Nulla quis mauris vel libero mollis facilisis. Ut vitae fringilla nisi. Nam eu augue eget arcu rutrum vestibulum. In hac habitasse platea dictumst. Curabitur id urna at mauris auctor malesuada. Sed non ipsum ac nisi iaculis ullamcorper vel vel lectus.", new DateTime(2023, 3, 5, 21, 24, 56, 335, DateTimeKind.Local).AddTicks(5159) });

            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 3, 5, 21, 24, 56, 335, DateTimeKind.Local).AddTicks(5780), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse quis risus quam. Nulla quis mauris vel libero mollis facilisis. Ut vitae fringilla nisi. Nam eu augue eget arcu rutrum vestibulum. In hac habitasse platea dictumst. Curabitur id urna at mauris auctor malesuada. Sed non ipsum ac nisi iaculis ullamcorper vel vel lectus.", new DateTime(2023, 3, 5, 21, 24, 56, 335, DateTimeKind.Local).AddTicks(5786) });

            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Description", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 3, 5, 21, 24, 56, 335, DateTimeKind.Local).AddTicks(5789), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse quis risus quam. Nulla quis mauris vel libero mollis facilisis. Ut vitae fringilla nisi. Nam eu augue eget arcu rutrum vestibulum. In hac habitasse platea dictumst. Curabitur id urna at mauris auctor malesuada. Sed non ipsum ac nisi iaculis ullamcorper vel vel lectus", new DateTime(2023, 3, 5, 21, 24, 56, 335, DateTimeKind.Local).AddTicks(5791) });

            migrationBuilder.InsertData(
                table: "ContentItems",
                columns: new[] { "Id", "CreatedAt", "Description", "DownloadCount", "ImageUrl", "ThumbnailUrl", "Title", "TotalsDownloadsA4", "TotalsDownloadsimage", "TotalsDownloadsmobile", "UpdatedAt" },
                values: new object[,]
                {
                    { 4, new DateTime(2023, 3, 5, 21, 24, 56, 335, DateTimeKind.Local).AddTicks(5793), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse quis risus quam. Nulla quis mauris vel libero mollis facilisis. Ut vitae fringilla nisi. Nam eu augue eget arcu rutrum vestibulum. In hac habitasse platea dictumst. Curabitur id urna at mauris auctor malesuada. Sed non ipsum ac nisi iaculis ullamcorper vel vel lectus.", 0, "https://example.com/image1.jpg", "https://example.com/thumb1.jpg", "Fourth Item", 0, 0, 0, new DateTime(2023, 3, 5, 21, 24, 56, 335, DateTimeKind.Local).AddTicks(5795) },
                    { 5, new DateTime(2023, 3, 5, 21, 24, 56, 335, DateTimeKind.Local).AddTicks(5799), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse quis risus quam. Nulla quis mauris vel libero mollis facilisis. Ut vitae fringilla nisi. Nam eu augue eget arcu rutrum vestibulum. In hac habitasse platea dictumst. Curabitur id urna at mauris auctor malesuada. Sed non ipsum ac nisi iaculis ullamcorper vel vel lectus.", 0, "https://example.com/image2.jpg", "https://example.com/thumb2.jpg", "Fifth Item", 0, 0, 0, new DateTime(2023, 3, 5, 21, 24, 56, 335, DateTimeKind.Local).AddTicks(5800) },
                    { 6, new DateTime(2023, 3, 5, 21, 24, 56, 335, DateTimeKind.Local).AddTicks(5813), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse quis risus quam. Nulla quis mauris vel libero mollis facilisis. Ut vitae fringilla nisi. Nam eu augue eget arcu rutrum vestibulum. In hac habitasse platea dictumst. Curabitur id urna at mauris auctor malesuada. Sed non ipsum ac nisi iaculis ullamcorper vel vel lectus.", 0, "https://example.com/image3.jpg", "https://example.com/thumb3.jpg", "Sixth Item", 0, 0, 0, new DateTime(2023, 3, 5, 21, 24, 56, 335, DateTimeKind.Local).AddTicks(5814) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContentItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ContentItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ContentItems",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "TotalsDownloadsA4",
                table: "ContentItems");

            migrationBuilder.DropColumn(
                name: "TotalsDownloadsimage",
                table: "ContentItems");

            migrationBuilder.DropColumn(
                name: "TotalsDownloadsmobile",
                table: "ContentItems");

            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 3, 4, 21, 49, 20, 142, DateTimeKind.Local).AddTicks(7115), "This is the first item.", new DateTime(2023, 3, 4, 21, 49, 20, 144, DateTimeKind.Local).AddTicks(2040) });

            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 3, 4, 21, 49, 20, 144, DateTimeKind.Local).AddTicks(2578), "This is the second item.", new DateTime(2023, 3, 4, 21, 49, 20, 144, DateTimeKind.Local).AddTicks(2584) });

            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Description", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 3, 4, 21, 49, 20, 144, DateTimeKind.Local).AddTicks(2589), "This is the third item.", new DateTime(2023, 3, 4, 21, 49, 20, 144, DateTimeKind.Local).AddTicks(2591) });
        }
    }
}
