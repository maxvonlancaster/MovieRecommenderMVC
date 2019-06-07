using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieRecommenderMVC.DAL.Migrations
{
    public partial class genretable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ganre",
                table: "Movies");

            migrationBuilder.AddColumn<int>(
                name: "GanreId",
                table: "Movies",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GenreName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GanreId",
                table: "Movies",
                column: "GanreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genres_GanreId",
                table: "Movies",
                column: "GanreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genres_GanreId",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Movies_GanreId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "GanreId",
                table: "Movies");

            migrationBuilder.AddColumn<string>(
                name: "Ganre",
                table: "Movies",
                nullable: true);
        }
    }
}
