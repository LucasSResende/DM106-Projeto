using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SerieManager.Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Serie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    serieName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    serieGenre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    serieDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Episode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EpisodeNumber = table.Column<int>(type: "int", nullable: false),
                    EpisodeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Episode_Serie_SerieId",
                        column: x => x.SerieId,
                        principalTable: "Serie",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Episode_SerieId",
                table: "Episode",
                column: "SerieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Episode");

            migrationBuilder.DropTable(
                name: "Serie");
        }
    }
}
