using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Participants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Age = table.Column<int>(type: "INTEGER", nullable: true),
                    HeightInCm = table.Column<decimal>(type: "TEXT", nullable: false),
                    WeightInKg = table.Column<decimal>(type: "TEXT", nullable: false),
                    TeamId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participants_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38b13138-2eb6-415b-b1d4-c36f6c6fdee4",
                column: "ConcurrencyStamp",
                value: "18c6b2f5-1044-48b6-90f7-0bf66b5f682d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ed57acf-cb38-4df4-ac5f-be45115fd783",
                column: "ConcurrencyStamp",
                value: "19d36102-3335-41a5-a10a-108364d2fe98");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22dc9879-b5f7-4fff-bd8d-b3821455b6d5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d064b51c-01ad-490c-a27d-f5611181232c", "3b110859-6204-4ac4-98fa-d33c43e5705f" });

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "22dc9879-b5f7-4fff-bd8d-b3821455b6d5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6d83c51e-daa4-46fe-860a-c406d095a601", "AQAAAAEAACcQAAAAEKFc/Hz4opIotwDPZ/Mr2sLVPuzE5/nppf/0mk2YLu/Ki9MW04y0OKbJTxDehhdL8A==", "e7bbf0d4-1160-465e-bc14-6958602fd484" });

            migrationBuilder.CreateIndex(
                name: "IX_Participants_TeamId",
                table: "Participants",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38b13138-2eb6-415b-b1d4-c36f6c6fdee4",
                column: "ConcurrencyStamp",
                value: "6f6024f8-23d2-4fc8-a80c-c512496afbaf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ed57acf-cb38-4df4-ac5f-be45115fd783",
                column: "ConcurrencyStamp",
                value: "a7e28ac7-fc8e-45db-b267-1780c874498a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22dc9879-b5f7-4fff-bd8d-b3821455b6d5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1c16e47c-9f60-4909-8561-b338187e1151", "88ad594c-36eb-4201-8592-bea6d167eb22" });

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "22dc9879-b5f7-4fff-bd8d-b3821455b6d5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "54f00ae4-3f5c-445c-88e7-872647306b85", "AQAAAAEAACcQAAAAEMTfYDcsTeshIs2cmg+2rfAtbsaW1ybJ2H96lk7r/M9SWXzRnO8XkC0PDlfadU0bBw==", "89895454-74eb-4e58-b56d-b678160f4e8c" });
        }
    }
}
