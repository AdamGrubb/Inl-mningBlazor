using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HorrorFlux.Membership.Database.Migrations
{
    /// <inheritdoc />
    public partial class FixedSimilarFilm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SimilarFilm_Films_FilmId",
                table: "SimilarFilm");

            migrationBuilder.DropIndex(
                name: "IX_SimilarFilm_FilmId",
                table: "SimilarFilm");

            migrationBuilder.DropColumn(
                name: "FilmId",
                table: "SimilarFilm");

            migrationBuilder.CreateIndex(
                name: "IX_SimilarFilm_SimilarFilmId",
                table: "SimilarFilm",
                column: "SimilarFilmId");

            migrationBuilder.AddForeignKey(
                name: "FK_SimilarFilm_Films_ParentFilmId",
                table: "SimilarFilm",
                column: "ParentFilmId",
                principalTable: "Films",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SimilarFilm_Films_SimilarFilmId",
                table: "SimilarFilm",
                column: "SimilarFilmId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SimilarFilm_Films_ParentFilmId",
                table: "SimilarFilm");

            migrationBuilder.DropForeignKey(
                name: "FK_SimilarFilm_Films_SimilarFilmId",
                table: "SimilarFilm");

            migrationBuilder.DropIndex(
                name: "IX_SimilarFilm_SimilarFilmId",
                table: "SimilarFilm");

            migrationBuilder.AddColumn<int>(
                name: "FilmId",
                table: "SimilarFilm",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SimilarFilm_FilmId",
                table: "SimilarFilm",
                column: "FilmId");

            migrationBuilder.AddForeignKey(
                name: "FK_SimilarFilm_Films_FilmId",
                table: "SimilarFilm",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
