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
    public class HorrorFluxContext : DbContext
    {
        public DbSet<Director> Directors { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<FilmGenre> FilmGenres { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<SimilarFilms> SimilarFilm { get; set; }
        public HorrorFluxContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
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
                     entity
                .HasMany(d => d.SimilarFilms)
                .WithOne(p => p.ParentFilm)
                .HasForeignKey(d => d.ParentFilmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
            );



            builder.Entity<Film>(entity =>
            {
                entity.HasMany(d => d.Genres)
                      .WithMany(p => p.Films)
                      .UsingEntity<FilmGenre>()
                      .ToTable("FilmGenres");
            });

            //SeedData(builder);


        }

        void SeedData(ModelBuilder builder)
        {
            builder.Entity<Director>().HasData(
                new { Id = 1, Name = "James Gunn" });

            builder.Entity<Film>().HasData(
                new Film
                {
                    Id = 1,
                    Title = "Super",
                    Description = "After his wife falls under the influence of a drug dealer, an everyday guy transforms himself into Crimson Bolt, a superhero with the best intentions, but lacking in heroic skills.",
                    FilmUrl = "https://www.youtube.com/watch?v=tLj_Bzw8n90",
                    FilmPoster = "/MoviePoster/Super.png",
                    Release = new DateTime(2010, 10, 12),
                    DirectorId = 1,
                    Free = true
                },
                new Film
                {
                    Id = 2,
                    Title = "Slither",
                    Description = "A small town is taken over by an alien plague, turning residents into zombies and all forms of mutant monsters.",
                    FilmUrl = "https://www.youtube.com/watch?v=SI0BcgVdSWg",
                    FilmPoster = "/MoviePoster/Slither.png",
                    Release = new DateTime(2006, 4, 2),
                    DirectorId = 1,
                    Free = false
                },
                new Film
                {
                    Id = 3,
                    Title = "Guardian Of the Galaxy",
                    Description = "A group of intergalactic criminals must pull together to stop a fanatical warrior with plans to purge the universe.",
                    FilmUrl = "https://www.youtube.com/watch?v=d96cjJhvlMA",
                    FilmPoster = "/MoviePoster/Guardian Of The Galaxy.png",
                    Release = new DateTime(2014, 4, 2),
                    DirectorId = 1,
                    Free = true
                });


            builder.Entity<SimilarFilms>().HasData(
                new SimilarFilms { ParentFilmId = 1, SimilarFilmId = 2 }, new SimilarFilms { ParentFilmId = 1, SimilarFilmId = 3 }, new SimilarFilms { ParentFilmId = 2, SimilarFilmId = 3 });

            builder.Entity<Genre>().HasData(
                new { Id = 1, Name = "Action" },
                new { Id = 2, Name = "Sci-Fi" });

            builder.Entity<FilmGenre>().HasData(
                new FilmGenre { FilmId = 1, GenreId = 1 },
                new FilmGenre { FilmId = 2, GenreId = 1 },
                new FilmGenre { FilmId = 3, GenreId = 2 },
                new FilmGenre { FilmId = 2, GenreId = 2 });

        }

    }
}
