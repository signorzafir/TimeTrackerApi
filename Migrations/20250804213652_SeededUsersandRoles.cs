using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TimeTrackerAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeededUsersandRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "11163a23-ce1b-4809-b39d-8f153489a4cb", null, "User", "USER" },
                    { "6880cbe1-c055-455e-b6ca-c0060ddc28c2", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "397752af-b4a2-46fe-bef1-22ce604f9337", 0, "442ff401-9dbb-483d-8513-f30873b72e36", "bravouser@timetracker.com", true, "Bravo User", false, null, "BRAVOUSER@TIMETRACKER.COM", "BRAVOUSER@TIMETRACKER.COM", "AQAAAAIAAYagAAAAEDoBzQ5PB7kefERvqTpxoTkmkZrm1MfQrIlC76PtKI5pCAeUe0a4zBMTwi4Ah8Ibzw==", null, false, "01446478-8ddc-4bd9-bb4e-a617eb120609", false, "bravouser@timetracker.com" },
                    { "51841e02-fa5b-4e18-9eef-b3f78eefff51", 0, "eca74cfb-a9b2-42e7-9ea5-6360fbb1aee0", "alphauser@timetracker.com", true, "Alpha User", false, null, "ALPHAUSER@TIMETRACKER.COM", "ALPHAUSER@TIMETRACKER.COM", "AQAAAAIAAYagAAAAEDoBzQ5PB7kefERvqTpxoTkmkZrm1MfQrIlC76PtKI5pCAeUe0a4zBMTwi4Ah8Ibzw==", null, false, "ca5b5fb2-f959-46f5-9e90-6eeba3ec4567", false, "alphauser@timetracker.com" },
                    { "78158e67-cea7-4398-9304-715aebaff2ae", 0, "89ecb0d2-10e7-4bf3-8bf1-fe37aaf8e0fc", "admin@timetracker.com", true, "System Admin", false, null, "ADMIN@TIMETRACKER.COM", "ADMIN@TIMETRACKER.COM", "AQAAAAIAAYagAAAAEDoBzQ5PB7kefERvqTpxoTkmkZrm1MfQrIlC76PtKI5pCAeUe0a4zBMTwi4Ah8Ibzw==", null, false, "ae984071-7f30-4379-9e48-bd9abb624cae", false, "admin@timetracker.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "11163a23-ce1b-4809-b39d-8f153489a4cb", "397752af-b4a2-46fe-bef1-22ce604f9337" },
                    { "11163a23-ce1b-4809-b39d-8f153489a4cb", "51841e02-fa5b-4e18-9eef-b3f78eefff51" },
                    { "11163a23-ce1b-4809-b39d-8f153489a4cb", "78158e67-cea7-4398-9304-715aebaff2ae" },
                    { "6880cbe1-c055-455e-b6ca-c0060ddc28c2", "78158e67-cea7-4398-9304-715aebaff2ae" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "11163a23-ce1b-4809-b39d-8f153489a4cb", "397752af-b4a2-46fe-bef1-22ce604f9337" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "11163a23-ce1b-4809-b39d-8f153489a4cb", "51841e02-fa5b-4e18-9eef-b3f78eefff51" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "11163a23-ce1b-4809-b39d-8f153489a4cb", "78158e67-cea7-4398-9304-715aebaff2ae" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6880cbe1-c055-455e-b6ca-c0060ddc28c2", "78158e67-cea7-4398-9304-715aebaff2ae" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11163a23-ce1b-4809-b39d-8f153489a4cb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6880cbe1-c055-455e-b6ca-c0060ddc28c2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "397752af-b4a2-46fe-bef1-22ce604f9337");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "51841e02-fa5b-4e18-9eef-b3f78eefff51");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "78158e67-cea7-4398-9304-715aebaff2ae");
        }
    }
}
