using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFMigration.Migrations
{
    /// <inheritdoc />
    public partial class hobbies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "hobbies",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hobbies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hobbies_pets_PetId",
                        column: x => x.PetId,
                        principalTable: "pets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_hobbies_PetId",
                table: "hobbies",
                column: "PetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hobbies");
        }
    }
}
