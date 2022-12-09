using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EShopMvcSolution.Data.Migrations
{
    public partial class UpdateProductImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("28c32ce9-578a-4525-b45d-d115db752a04"),
                column: "ConcurrencyStamp",
                value: "7efd83de-9d65-46c6-8717-d225784432e8");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("42323d12-3fe8-4118-b801-2d2b201be1e1"),
                column: "ConcurrencyStamp",
                value: "6a219d44-5ac5-4fdd-84c9-39cb91376730");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("a35d4ce1-076b-4369-a16a-c08c10de1278"),
                column: "ConcurrencyStamp",
                value: "f4dd0e0e-4ba9-467f-b6f7-87269e7d174f");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("e425ffa2-c591-445b-8051-8605fee3d90f"),
                column: "ConcurrencyStamp",
                value: "511d8a4b-fbf2-43af-abcd-2731d732c126");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("7b60066f-0858-4879-a924-28c011d80f20"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d2cf6c05-3a46-4b2c-b060-e39e2d6afc53", "AQAAAAEAACcQAAAAEOUI2iFtZUveYlzBqngMNjgqRoM9ObH0KTg+B5OE9zq+IOHDYFSlb+8C1o7kUSkl6g==" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreate",
                value: new DateTime(2022, 12, 9, 16, 18, 10, 886, DateTimeKind.Local).AddTicks(5400));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("28c32ce9-578a-4525-b45d-d115db752a04"),
                column: "ConcurrencyStamp",
                value: "9df1827d-c576-4a8f-8b2a-5bfa5f9b78d2");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("42323d12-3fe8-4118-b801-2d2b201be1e1"),
                column: "ConcurrencyStamp",
                value: "926affcb-aea3-49af-a4b2-a85471e14ed9");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("a35d4ce1-076b-4369-a16a-c08c10de1278"),
                column: "ConcurrencyStamp",
                value: "825e35e4-ba36-4b8b-a2e4-11f3845361e0");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("e425ffa2-c591-445b-8051-8605fee3d90f"),
                column: "ConcurrencyStamp",
                value: "3f738c5a-965a-4513-8b9e-02502b80e6b3");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("7b60066f-0858-4879-a924-28c011d80f20"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6b28ebe5-d69e-466e-9deb-83c940b9eddc", "AQAAAAEAACcQAAAAENcaP8EZYWoXQpl7QUUDEB/dj7iW7Q/xXYzkGOwP+coACWDvv3kNX/lYgRFtUXAflA==" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreate",
                value: new DateTime(2022, 11, 23, 3, 20, 56, 644, DateTimeKind.Local).AddTicks(2077));
        }
    }
}
