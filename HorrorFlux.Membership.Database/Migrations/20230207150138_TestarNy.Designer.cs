﻿// <auto-generated />
using System;
using HorrorFlux.Membership.Database.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HorrorFlux.Membership.Database.Migrations
{
    [DbContext(typeof(HorrorFluxContext))]
    [Migration("20230207150138_TestarNy")]
    partial class TestarNy
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HorrorFlux.Membership.Database.Entities.Director", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Directors");
                });

            modelBuilder.Entity("HorrorFlux.Membership.Database.Entities.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("DirectorId")
                        .HasColumnType("int");

                    b.Property<string>("FilmPoster")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("FilmUrl")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<DateTime>("Release")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("DirectorId");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("HorrorFlux.Membership.Database.Entities.FilmGenre", b =>
                {
                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.HasKey("GenreId", "FilmId");

                    b.HasIndex("FilmId");

                    b.ToTable("FilmGenres", (string)null);
                });

            modelBuilder.Entity("HorrorFlux.Membership.Database.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("HorrorFlux.Membership.Database.Entities.SimilarFilms", b =>
                {
                    b.Property<int>("ParentFilmId")
                        .HasColumnType("int");

                    b.Property<int>("SimilarFilmId")
                        .HasColumnType("int");

                    b.HasKey("ParentFilmId", "SimilarFilmId");

                    b.HasIndex("SimilarFilmId");

                    b.ToTable("SimilarFilm");
                });

            modelBuilder.Entity("HorrorFlux.Membership.Database.Entities.Film", b =>
                {
                    b.HasOne("HorrorFlux.Membership.Database.Entities.Director", "Director")
                        .WithMany("Films")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Director");
                });

            modelBuilder.Entity("HorrorFlux.Membership.Database.Entities.FilmGenre", b =>
                {
                    b.HasOne("HorrorFlux.Membership.Database.Entities.Film", "Film")
                        .WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HorrorFlux.Membership.Database.Entities.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("HorrorFlux.Membership.Database.Entities.SimilarFilms", b =>
                {
                    b.HasOne("HorrorFlux.Membership.Database.Entities.Film", "Film")
                        .WithMany("SimilarFilms")
                        .HasForeignKey("ParentFilmId")
                        .IsRequired();

                    b.HasOne("HorrorFlux.Membership.Database.Entities.Film", "SimilarFilm")
                        .WithMany()
                        .HasForeignKey("SimilarFilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("SimilarFilm");
                });

            modelBuilder.Entity("HorrorFlux.Membership.Database.Entities.Director", b =>
                {
                    b.Navigation("Films");
                });

            modelBuilder.Entity("HorrorFlux.Membership.Database.Entities.Film", b =>
                {
                    b.Navigation("SimilarFilms");
                });
#pragma warning restore 612, 618
        }
    }
}
