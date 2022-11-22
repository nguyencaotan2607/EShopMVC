using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EShopMvcSolution.Data.Migrations
{
    public partial class SeedIdentityDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("42323d12-3fe8-4118-b801-2d2b201be1e1"), "d70c07c9-beba-4ae4-ab0f-856fb6e5a4a4", "Adminitration role", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("42323d12-3fe8-4118-b801-2d2b201be1e1"), new Guid("7b60066f-0858-4879-a924-28c011d80f20") });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("7b60066f-0858-4879-a924-28c011d80f20"), 0, "5c45c850-2042-4599-9244-50830c81c2fd", new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "nguyencaotan2607@gmail.com", true, "Cao", "Tan", false, null, "nguyencaotan2607@gmail.com", "admin", "AQAAAAEAACcQAAAAEIkHTc9enwulKSMfQHcbUIqHdZ+mXZH2B9r+dcAJuDEk4T6GR9gBEo2RcmHPWap+Qw==", null, false, "", false, "admin" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreate",
                value: new DateTime(2022, 11, 23, 2, 54, 4, 397, DateTimeKind.Local).AddTicks(6641));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("42323d12-3fe8-4118-b801-2d2b201be1e1"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("42323d12-3fe8-4118-b801-2d2b201be1e1"), new Guid("7b60066f-0858-4879-a924-28c011d80f20") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("7b60066f-0858-4879-a924-28c011d80f20"));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreate",
                value: new DateTime(2022, 11, 23, 2, 23, 27, 591, DateTimeKind.Local).AddTicks(5744));
        }
    }
}
