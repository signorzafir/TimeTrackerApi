using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeTrackerAPI.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "397752af-b4a2-46fe-bef1-22ce604f9337",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f04015ae-b70f-4b69-b9ae-393859db7e3e", "04413c1a-7c06-444f-bc4a-6486e1abd0cf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "51841e02-fa5b-4e18-9eef-b3f78eefff51",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bb140b91-7cfd-4856-afd5-93dbd1d5fe13", "e6e45515-312f-499a-80d5-078a4d5e4d60" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "78158e67-cea7-4398-9304-715aebaff2ae",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1c300b7e-e65b-458a-a55c-6a37669ec776", "64c04e1e-b04a-4acf-bbad-7bcde9ae7e59" });
        }
    }
}
