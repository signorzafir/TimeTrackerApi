using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeTrackerAPI.Migrations
{
    /// <inheritdoc />
    public partial class _ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "397752af-b4a2-46fe-bef1-22ce604f9337",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4eac806f-5d7a-454e-9e8a-11fd68fe211f", "72140a95-7d95-431c-b1ba-40d769fd662e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "51841e02-fa5b-4e18-9eef-b3f78eefff51",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4105d78f-b5a3-4cfe-ae2b-8966e60aa97e", "5de89b89-3b6f-4f3d-b9ee-dbc84eb3056b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "78158e67-cea7-4398-9304-715aebaff2ae",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e2823af1-27c3-4a7a-934f-845b33299371", "8018102c-0f7b-4d1e-a3f0-3fe2223132e9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "397752af-b4a2-46fe-bef1-22ce604f9337",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0896a5a8-0a9c-4bbb-995c-40a8e33e5237", "af9f5766-d679-4dc0-a73a-ce07e25e9634" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "51841e02-fa5b-4e18-9eef-b3f78eefff51",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7ce404bc-2b9b-4f21-86a2-b50380bfc7f8", "5894e518-d508-4f2a-bd4f-82c53b959709" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "78158e67-cea7-4398-9304-715aebaff2ae",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6b29b39a-5aa6-4f2e-aae3-5da99bfdf6ba", "78ec02cd-1846-4bb6-b254-6d8b6b69cd20" });
        }
    }
}
