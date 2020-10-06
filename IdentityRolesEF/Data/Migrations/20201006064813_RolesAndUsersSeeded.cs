using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityRolesEF.Data.Migrations
{
    public partial class RolesAndUsersSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a4280b6a-0653-4cbd-a0p6-f1701e926e73", "60ba824b-94fe-4960-acc2-245bd9ded33c", "admin", "ADMIN" },
                    { "c9280b6a-0613-4cbd-a9e6-f1701e926e73", "e4dd5ba0-3c87-4f36-a225-8ae989a48e53", "basic", "BASIC" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "b4280b6a-0613-4cbd-a9e6-f1701e926e73", 0, "820c8865-89cf-4608-afe6-05abd5a9fa54", "admin@admin.com", false, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAELddu9cf1CfwbvoG6lnVcjO90xtEsOxryL6wgEMrHU8HBaR3+4FTe/uVx8NnorIvoQ==", null, false, "4877a2d5-77a2-40d1-b3f6-f5df919183b4", false, "admin@admin.com" },
                    { "b4280b6a-0613-4ciod-a9e6-f1702f926e73", 0, "8f2a4048-4cd2-4353-9be7-34f7f2b59b9f", "basic@basic.com", false, false, null, "BASIC@BASIC.COM", "BASIC@BASIC.COM", "AQAAAAEAACcQAAAAENcvgURrzrKvFEQzpnyGPXr6wA+HOWIUrJuRgme1u2ERthN7R7CQIIFRoWnVII5u5w==", null, false, "44767464-9049-436e-b9a6-036c27114fb6", false, "basic@basic.com" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "FirstName", "LastName", "UserId" },
                values: new object[,]
                {
                    { 1, "admin", "admin", "b4280b6a-0613-4cbd-a9e6-f1701e926e73" },
                    { 2, "basic", "basic", "b4280b6a-0613-4ciod-a9e6-f1702f926e73" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "b4280b6a-0613-4cbd-a9e6-f1701e926e73", "a4280b6a-0653-4cbd-a0p6-f1701e926e73" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "b4280b6a-0613-4ciod-a9e6-f1702f926e73", "c9280b6a-0613-4cbd-a9e6-f1701e926e73" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "b4280b6a-0613-4cbd-a9e6-f1701e926e73", "a4280b6a-0653-4cbd-a0p6-f1701e926e73" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "b4280b6a-0613-4ciod-a9e6-f1702f926e73", "c9280b6a-0613-4cbd-a9e6-f1701e926e73" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4280b6a-0653-4cbd-a0p6-f1701e926e73");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9280b6a-0613-4cbd-a9e6-f1701e926e73");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4ciod-a9e6-f1702f926e73");
        }
    }
}
