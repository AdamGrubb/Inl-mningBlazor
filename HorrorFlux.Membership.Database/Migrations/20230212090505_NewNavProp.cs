using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HorrorFlux.Membership.Database.Migrations
{
    /// <inheritdoc />
    public partial class NewNavProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SimilarFilm",
                columns: new[] { "ParentFilmId", "SimilarFilmId" },
                values: new object[] { 2, 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SimilarFilm",
                keyColumns: new[] { "ParentFilmId", "SimilarFilmId" },
                keyValues: new object[] { 2, 3 });
        }
    }
}
