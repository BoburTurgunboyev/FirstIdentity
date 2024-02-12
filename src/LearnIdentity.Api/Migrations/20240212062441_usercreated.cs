using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LearnIdentity.Api.Migrations
{
    /// <inheritdoc />
    public partial class usercreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45a80955-2319-475e-b501-5395f1ae1abb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e2f898c-4192-41dc-814c-3f703b8107c3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe35a847-7ea8-493c-be31-9192f2ce8370");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0be38b98-5b36-4a7c-ba8f-0021b6687d5d", "1", "Admin", "Admin" },
                    { "43bd1394-55c2-4fce-8ead-3a1755423fc1", "3", "My", "My" },
                    { "ae9a099a-7536-4c0d-9f1a-797a4bbea46c", "2", "User", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0be38b98-5b36-4a7c-ba8f-0021b6687d5d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43bd1394-55c2-4fce-8ead-3a1755423fc1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae9a099a-7536-4c0d-9f1a-797a4bbea46c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "45a80955-2319-475e-b501-5395f1ae1abb", "1", "Admin", "Admin" },
                    { "6e2f898c-4192-41dc-814c-3f703b8107c3", "3", "My", "My" },
                    { "fe35a847-7ea8-493c-be31-9192f2ce8370", "2", "User", "User" }
                });
        }
    }
}
