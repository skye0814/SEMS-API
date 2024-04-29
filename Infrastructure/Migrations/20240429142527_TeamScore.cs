using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class TeamScore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Team1Score",
                table: "Matches",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Team2Score",
                table: "Matches",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38b13138-2eb6-415b-b1d4-c36f6c6fdee4",
                column: "ConcurrencyStamp",
                value: "b63586f4-ed5d-450e-88ea-a6544a7b93ce");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ed57acf-cb38-4df4-ac5f-be45115fd783",
                column: "ConcurrencyStamp",
                value: "7f8580d6-4b23-43fe-b721-fa40164fe17a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22dc9879-b5f7-4fff-bd8d-b3821455b6d5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a0a6571c-33c6-4bd4-ae46-56d496286d95", "8d6e3c0a-2f39-4921-8e0e-fd70ac6ffb2c" });

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "22dc9879-b5f7-4fff-bd8d-b3821455b6d5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e1e5cd96-ea9c-492d-b08e-8e8654da130b", "AQAAAAEAACcQAAAAEIGYwleX4NgBsGYUFrK5FesRHfl/nIv/RspaZYExg8Wxh/LOvG3v/6aElqd+VWIOVQ==", "9dd932d8-23b9-485d-804c-de66e01829c2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Team1Score",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "Team2Score",
                table: "Matches");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38b13138-2eb6-415b-b1d4-c36f6c6fdee4",
                column: "ConcurrencyStamp",
                value: "bc9d2a9d-62fe-4d38-8e01-f4cabdead8bf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ed57acf-cb38-4df4-ac5f-be45115fd783",
                column: "ConcurrencyStamp",
                value: "1680b11e-fc32-4d4a-a8e2-cfbdfddc334e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22dc9879-b5f7-4fff-bd8d-b3821455b6d5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e6021454-9c5b-4995-98b8-ec4e9503616a", "ff91fe36-ad1e-469b-aff3-1422679787f2" });

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "22dc9879-b5f7-4fff-bd8d-b3821455b6d5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5cc0e28d-ec70-463f-a04a-4f4706f48926", "AQAAAAEAACcQAAAAEJnFy03ObSHUY40rZ5uB69skXro26lC/DyIyzkaNgwk0SOcEgIYCUQiJ/awqghRR1w==", "1a621919-c30d-48fe-a851-bfcd799aa368" });
        }
    }
}
