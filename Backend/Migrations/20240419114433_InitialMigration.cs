using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategoriak",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriaNev = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriak", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tesztek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kerdes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    V1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    V2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    V3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    V4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Helyes = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false, defaultValue: "V1"),
                    KategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tesztek", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tesztek_Kategoriak_KategoriaId",
                        column: x => x.KategoriaId,
                        principalTable: "Kategoriak",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tesztek_KategoriaId",
                table: "Tesztek",
                column: "KategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tesztek");

            migrationBuilder.DropTable(
                name: "Kategoriak");
        }
    }
}
