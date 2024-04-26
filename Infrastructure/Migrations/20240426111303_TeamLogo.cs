using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class TeamLogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamLogoId",
                table: "Teams",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TeamLogos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamLogos", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38b13138-2eb6-415b-b1d4-c36f6c6fdee4",
                column: "ConcurrencyStamp",
                value: "9c836476-2e90-40c3-92ed-8e3fab053d60");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ed57acf-cb38-4df4-ac5f-be45115fd783",
                column: "ConcurrencyStamp",
                value: "964d638b-ef47-4f8c-96ec-cdd2b96e0cc9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22dc9879-b5f7-4fff-bd8d-b3821455b6d5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9f9a6e55-33d2-46d7-b0bf-f88a05197828", "48a8e59d-932f-4df8-8112-5800db93e098" });

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "22dc9879-b5f7-4fff-bd8d-b3821455b6d5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "05f17d5e-8a47-41c8-b3bd-9c347c74eafd", "AQAAAAEAACcQAAAAEDNxfCAGcrS+zXW2LIMZlFgxdU5d9krP7haqVnw2am9T/lnTg/upcxsE6bjuq9Tfiw==", "615df557-3564-4d34-b39f-1400ae6c7fd5" });

            migrationBuilder.InsertData(
                table: "TeamLogos",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[] { 1, "/images/team icons/beaver.png", "Beaver" });

            migrationBuilder.InsertData(
                table: "TeamLogos",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[] { 2, "/images/team icons/bee.png", "Bee" });

            migrationBuilder.InsertData(
                table: "TeamLogos",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[] { 3, "/images/team icons/boar.png", "Boar" });

            migrationBuilder.InsertData(
                table: "TeamLogos",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[] { 4, "/images/team icons/buffalo.png", "Buffalo" });

            migrationBuilder.InsertData(
                table: "TeamLogos",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[] { 5, "/images/team icons/cat.png", "Cat" });

            migrationBuilder.InsertData(
                table: "TeamLogos",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[] { 6, "/images/team icons/chameleon.png", "Chameleon" });

            migrationBuilder.InsertData(
                table: "TeamLogos",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[] { 7, "/images/team icons/chicken.png", "Chicken" });

            migrationBuilder.InsertData(
                table: "TeamLogos",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[] { 8, "/images/team icons/clown-fish.png", "Clownfish" });

            migrationBuilder.InsertData(
                table: "TeamLogos",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[] { 9, "/images/team icons/crab.png", "Crab" });

            migrationBuilder.InsertData(
                table: "TeamLogos",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[] { 10, "/images/team icons/crocodile.png", "Crocodile" });

            migrationBuilder.InsertData(
                table: "TeamLogos",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[] { 11, "/images/team icons/dog.png", "Dog" });

            migrationBuilder.InsertData(
                table: "TeamLogos",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[] { 12, "/images/team icons/elephant.png", "Elephant" });

            migrationBuilder.InsertData(
                table: "TeamLogos",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[] { 13, "/images/team icons/frog.png", "Frog" });

            migrationBuilder.InsertData(
                table: "TeamLogos",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[] { 14, "/images/team icons/giraffe.png", "Giraffe" });

            migrationBuilder.InsertData(
                table: "TeamLogos",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[] { 15, "/images/team icons/gorilla.png", "Gorilla" });

            migrationBuilder.InsertData(
                table: "TeamLogos",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[] { 16, "/images/team icons/horse.png", "Horse" });

            migrationBuilder.InsertData(
                table: "TeamLogos",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[] { 17, "/images/team icons/lama.png", "Llama" });

            migrationBuilder.InsertData(
                table: "TeamLogos",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[] { 18, "/images/team icons/lion.png", "Lion" });

            migrationBuilder.InsertData(
                table: "TeamLogos",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[] { 19, "/images/team icons/mouse.png", "Mouse" });

            migrationBuilder.InsertData(
                table: "TeamLogos",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[] { 20, "/images/team icons/owl.png", "Owl" });

            migrationBuilder.InsertData(
                table: "TeamLogos",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[] { 21, "/images/team icons/panda.png", "Panda" });

            migrationBuilder.InsertData(
                table: "TeamLogos",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[] { 22, "/images/team icons/parrot.png", "Parrot" });

            migrationBuilder.InsertData(
                table: "TeamLogos",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[] { 23, "/images/team icons/penguin.png", "Penguin" });

            migrationBuilder.InsertData(
                table: "TeamLogos",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[] { 24, "/images/team icons/pig.png", "Pig" });

            migrationBuilder.InsertData(
                table: "TeamLogos",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[] { 25, "/images/team icons/rhino.png", "Rhino" });

            migrationBuilder.InsertData(
                table: "TeamLogos",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[] { 26, "/images/team icons/sheep.png", "Sheep" });

            migrationBuilder.InsertData(
                table: "TeamLogos",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[] { 27, "/images/team icons/snake.png", "Snake" });

            migrationBuilder.InsertData(
                table: "TeamLogos",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[] { 28, "/images/team icons/turtle.png", "Turtle" });

            migrationBuilder.InsertData(
                table: "TeamLogos",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[] { 29, "/images/team icons/walrus.png", "Walrus" });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_TeamLogoId",
                table: "Teams",
                column: "TeamLogoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_TeamLogos_TeamLogoId",
                table: "Teams",
                column: "TeamLogoId",
                principalTable: "TeamLogos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_TeamLogos_TeamLogoId",
                table: "Teams");

            migrationBuilder.DropTable(
                name: "TeamLogos");

            migrationBuilder.DropIndex(
                name: "IX_Teams_TeamLogoId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "TeamLogoId",
                table: "Teams");

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
        }
    }
}
