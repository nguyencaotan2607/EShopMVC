using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EShopMvcSolution.Data.Migrations
{
    public partial class AddNewRoleIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("42323d12-3fe8-4118-b801-2d2b201be1e1"),
                column: "ConcurrencyStamp",
                value: "926affcb-aea3-49af-a4b2-a85471e14ed9");

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("28c32ce9-578a-4525-b45d-d115db752a04"), "9df1827d-c576-4a8f-8b2a-5bfa5f9b78d2", "Customer role", "Customer", "CUSTOMER" },
                    { new Guid("a35d4ce1-076b-4369-a16a-c08c10de1278"), "825e35e4-ba36-4b8b-a2e4-11f3845361e0", "Employee role", "Employee", "EMPLOYEE" },
                    { new Guid("e425ffa2-c591-445b-8051-8605fee3d90f"), "3f738c5a-965a-4513-8b9e-02502b80e6b3", "Seller role", "Seller", "SELLER" }
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("28c32ce9-578a-4525-b45d-d115db752a04"));

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("a35d4ce1-076b-4369-a16a-c08c10de1278"));

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("e425ffa2-c591-445b-8051-8605fee3d90f"));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("42323d12-3fe8-4118-b801-2d2b201be1e1"),
                column: "ConcurrencyStamp",
                value: "d70c07c9-beba-4ae4-ab0f-856fb6e5a4a4");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("7b60066f-0858-4879-a924-28c011d80f20"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5c45c850-2042-4599-9244-50830c81c2fd", "AQAAAAEAACcQAAAAEIkHTc9enwulKSMfQHcbUIqHdZ+mXZH2B9r+dcAJuDEk4T6GR9gBEo2RcmHPWap+Qw==" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreate",
                value: new DateTime(2022, 11, 23, 2, 54, 4, 397, DateTimeKind.Local).AddTicks(6641));
        }
    }
}
