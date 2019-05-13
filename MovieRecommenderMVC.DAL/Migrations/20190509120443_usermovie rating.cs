using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieRecommenderMVC.DAL.Migrations
{
    public partial class usermovierating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "UserMovies",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "UserMovies");
        }
    }
}
