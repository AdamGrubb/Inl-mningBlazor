using HorrorFlux.Membership.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HorrorFlux.Membership.Database.Contexts
{
    public class HorrorFluxContext: DbContext
    {
        public DbSet<Director> Directors { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<FilmGenre> FilmGenres { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<SimilarFilms> SimilarFilm { get; set; }
        public HorrorFluxContext(DbContextOptions options) :base (options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder) //Kanske ha kvar cascading delete på vissa.
        {
            base.OnModelCreating(builder);

            builder.Entity<SimilarFilms>().HasKey(sf => new { sf.ParentFilmId, sf.SimilarFilmId });

            builder.Entity<FilmGenre>().HasKey(fg => new { fg.GenreId, fg.FilmId });

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e
            => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            builder.Entity<Film>(entity =>
            {
                entity
                    .HasMany(d => d.SimilarFilms)
                    .WithOne(p => p.Film)
                    .HasForeignKey(d => d.ParentFilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasMany(d => d.Genres)
                      .WithMany(p => p.Films)
                      .UsingEntity<FilmGenre>()
                      // Specify the table name for the connection table
                      // to avoid duplicate tables (FilmGenre and FilmGenres)
                      // in the database.
                      .ToTable("FilmGenres");
            });
        }



    }
}
