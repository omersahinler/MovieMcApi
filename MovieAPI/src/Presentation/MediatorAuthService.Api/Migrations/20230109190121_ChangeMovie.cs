using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieAPI.Api.Migrations
{
    public partial class ChangeMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "note",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "point",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d0bfa391-a604-4049-a868-359091461e46"),
                columns: new[] { "CreatedDate", "Password", "RefreshToken" },
                values: new object[] { new DateTime(2023, 1, 9, 19, 1, 21, 49, DateTimeKind.Utc).AddTicks(6765), "APRNyY5PZAOpXm4RvIl0dq42WeoevHvCc0H44W+ATEaY/ZGMogBrGORrRExxKEvuTw==", "ADFu1JjTS5YyKghPTlnY0UhoI2bcHVCnGEP5ud0eFgMpx7bxFjCXgo99ZYrx7wKq7A==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "note",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "point",
                table: "Movies");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d0bfa391-a604-4049-a868-359091461e46"),
                columns: new[] { "CreatedDate", "Password", "RefreshToken" },
                values: new object[] { new DateTime(2023, 1, 9, 15, 36, 56, 85, DateTimeKind.Utc).AddTicks(3322), "AKf2JUvtYupJMVPn06viGBjTZriOI2LnJEWNvFd+3rktgZAuZsZt6U1pFEF/0mPa7A==", "ACakmuy57kVkseu1DGKQnxe9oxODBeVf/Fm2kERLKXSvUY6yJRBYh8u3eJPfaS5lzQ==" });
        }
    }
}
