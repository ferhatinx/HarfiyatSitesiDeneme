using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Harfiyat_DataAccess.Migrations
{
    public partial class add_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "JobRequests",
                columns: new[] { "Id", "IsApproved", "JobTitle", "RequestDate", "RequestedBy" },
                values: new object[] { 1, false, "Bina Yıkımı", new DateTime(2025, 2, 10, 15, 5, 21, 529, DateTimeKind.Local).AddTicks(6604), "Ferhat Ersoy" });

            migrationBuilder.InsertData(
                table: "JobRequests",
                columns: new[] { "Id", "IsApproved", "JobTitle", "RequestDate", "RequestedBy" },
                values: new object[] { 2, false, "Kanalizasyon kazimi", new DateTime(2025, 2, 10, 15, 5, 21, 529, DateTimeKind.Local).AddTicks(6612), "Osman Ersoy" });

            migrationBuilder.InsertData(
                table: "JobRequests",
                columns: new[] { "Id", "IsApproved", "JobTitle", "RequestDate", "RequestedBy" },
                values: new object[] { 3, true, "Duvar Yikimi", new DateTime(2025, 2, 10, 15, 5, 21, 529, DateTimeKind.Local).AddTicks(6613), "İlker Yalçın" });

            migrationBuilder.InsertData(
                table: "JobRequests",
                columns: new[] { "Id", "IsApproved", "JobTitle", "RequestDate", "RequestedBy" },
                values: new object[] { 4, false, "Çiçek çukuru kazma", new DateTime(2025, 2, 10, 15, 5, 21, 529, DateTimeKind.Local).AddTicks(6615), "Uzay Can" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "JobRequests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "JobRequests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "JobRequests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "JobRequests",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
