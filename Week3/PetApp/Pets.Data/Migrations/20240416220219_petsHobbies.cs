using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pets.Data.Migrations
{
    /// <inheritdoc />
    public partial class petsHobbies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hobbies_Pets_PetId",
                table: "Hobbies");

            migrationBuilder.DropIndex(
                name: "IX_Hobbies_PetId",
                table: "Hobbies");

            migrationBuilder.DropColumn(
                name: "PetId",
                table: "Hobbies");

            migrationBuilder.CreateTable(
                name: "HobbyPet",
                columns: table => new
                {
                    HobbiesId = table.Column<int>(type: "int", nullable: false),
                    PetsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HobbyPet", x => new { x.HobbiesId, x.PetsId });
                    table.ForeignKey(
                        name: "FK_HobbyPet_Hobbies_HobbiesId",
                        column: x => x.HobbiesId,
                        principalTable: "Hobbies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HobbyPet_Pets_PetsId",
                        column: x => x.PetsId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HobbyPet_PetsId",
                table: "HobbyPet",
                column: "PetsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HobbyPet");

            migrationBuilder.AddColumn<int>(
                name: "PetId",
                table: "Hobbies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hobbies_PetId",
                table: "Hobbies",
                column: "PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hobbies_Pets_PetId",
                table: "Hobbies",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id");
        }
    }
}
