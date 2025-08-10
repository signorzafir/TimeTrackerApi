using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeTrackerAPI.Migrations
{
    /// <inheritdoc />
    public partial class addingUserIdToEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Employees",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_AspNetUsers_UserId",
                table: "Employees",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AspNetUsers_UserId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_UserId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Employees");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "397752af-b4a2-46fe-bef1-22ce604f9337",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "442ff401-9dbb-483d-8513-f30873b72e36", "01446478-8ddc-4bd9-bb4e-a617eb120609" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "51841e02-fa5b-4e18-9eef-b3f78eefff51",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "eca74cfb-a9b2-42e7-9ea5-6360fbb1aee0", "ca5b5fb2-f959-46f5-9e90-6eeba3ec4567" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "78158e67-cea7-4398-9304-715aebaff2ae",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "89ecb0d2-10e7-4bf3-8bf1-fe37aaf8e0fc", "ae984071-7f30-4379-9e48-bd9abb624cae" });
        }
    }
}
