using Microsoft.EntityFrameworkCore.Migrations;

namespace HR.LeaveManagement.Identity.Migrations
{
    public partial class CorrectedUserAndRoleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95b75644-40a6-4802-899d-10ec4111353b",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "40271a92-ab88-44b6-bd20-7a07196f0a47", "ADMINISTRATOR" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eff52106-7b29-43d4-b2c6-57ef8905908e",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "d78019d8-8b1b-43ee-8e6b-0cef5985daa0", "EMPLOYEE" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41ca8caa-b68f-471d-bdbd-88b85688668c",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a2cf436c-c77a-4ed5-92e7-41d3acee4015", "USER@UNKNOWN.COM", "AQAAAAEAACcQAAAAEHpmz0XR134VqJl6uDshGnHBxk1nqEh5f244zagG2tJlygAoj0KqBlqMfoMEJ2UkGg==", "11824693-8336-47af-807d-eaf390ff919c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "95af8717-e912-4db9-b7f2-59a8bb3b0648",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c392fab0-daa3-450c-8cd5-39d906a40ae2", "ADMIN@UNKNOWN.COM", "AQAAAAEAACcQAAAAEHOpIs5eYJFb4TPYpqcTkvqIO7GuAIgJC+/AP6nFN9NXyeL5jtKUzmKZzBvEuLzzbg==", "fb35ce8e-567e-4a83-bf10-4109de42daa7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95b75644-40a6-4802-899d-10ec4111353b",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "86b85244-e8de-4072-8c8f-337369da2430", null });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eff52106-7b29-43d4-b2c6-57ef8905908e",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "e9721e7f-8fcb-4595-b75d-770c82c2e59b", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41ca8caa-b68f-471d-bdbd-88b85688668c",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "928f246f-9ca7-4686-9ae8-bd3f281a56c5", null, "AQAAAAEAACcQAAAAEISI5tkmCdiaD5wj0opfdwCz0Q90qvgB2bktN8PDwObtKP0kDEuW4OUcbv/07tQGFg==", "76c00238-4547-44ac-88d2-e9e7d1f7f499" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "95af8717-e912-4db9-b7f2-59a8bb3b0648",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ed692e1-3180-4986-b607-cfe881f0f79b", null, "AQAAAAEAACcQAAAAEMnxsvqdoEfLqSxSEye48kxPlqwJN40B9k0hLDO/ocMX4BWrzp65wChW0JOSZadUww==", "129a70e9-b058-475c-86c1-cbb535b46bd1" });
        }
    }
}
