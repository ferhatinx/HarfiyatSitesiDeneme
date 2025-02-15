using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Harfiyat_DataAccess.Migrations
{
    public partial class add_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    JobTitle = table.Column<string>(type: "TEXT", nullable: false),
                    RequestedBy = table.Column<string>(type: "TEXT", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FileName = table.Column<string>(type: "TEXT", nullable: true),
                    FilePath = table.Column<string>(type: "TEXT", nullable: true),
                    UploadedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ImageType = table.Column<int>(type: "INTEGER", nullable: false),
                    JobRequestId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_JobRequests_JobRequestId",
                        column: x => x.JobRequestId,
                        principalTable: "JobRequests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProjectName = table.Column<string>(type: "TEXT", nullable: true),
                    Localiton = table.Column<string>(type: "TEXT", nullable: true),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    FinishDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: true),
                    isCompleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Summary = table.Column<string>(type: "TEXT", nullable: true),
                    JobRequestId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_JobRequests_JobRequestId",
                        column: x => x.JobRequestId,
                        principalTable: "JobRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "JobRequests",
                columns: new[] { "Id", "IsApproved", "JobTitle", "RequestDate", "RequestedBy" },
                values: new object[] { 1, false, "Bina Yıkımı", new DateTime(2025, 2, 15, 14, 39, 7, 744, DateTimeKind.Local).AddTicks(3878), "Ferhat Ersoy" });

            migrationBuilder.InsertData(
                table: "JobRequests",
                columns: new[] { "Id", "IsApproved", "JobTitle", "RequestDate", "RequestedBy" },
                values: new object[] { 2, false, "Kanalizasyon kazimi", new DateTime(2025, 2, 15, 14, 39, 7, 744, DateTimeKind.Local).AddTicks(3892), "Osman Ersoy" });

            migrationBuilder.InsertData(
                table: "JobRequests",
                columns: new[] { "Id", "IsApproved", "JobTitle", "RequestDate", "RequestedBy" },
                values: new object[] { 3, true, "Duvar Yikimi", new DateTime(2025, 2, 15, 14, 39, 7, 744, DateTimeKind.Local).AddTicks(3893), "İlker Yalçın" });

            migrationBuilder.InsertData(
                table: "JobRequests",
                columns: new[] { "Id", "IsApproved", "JobTitle", "RequestDate", "RequestedBy" },
                values: new object[] { 4, false, "Çiçek çukuru kazma", new DateTime(2025, 2, 15, 14, 39, 7, 744, DateTimeKind.Local).AddTicks(3894), "Uzay Can" });

            migrationBuilder.CreateIndex(
                name: "IX_Images_JobRequestId",
                table: "Images",
                column: "JobRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_JobRequestId",
                table: "Jobs",
                column: "JobRequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "JobRequests");
        }
    }
}
