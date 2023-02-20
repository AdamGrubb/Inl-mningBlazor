using HorrorFlux.Common.DTOs;
using HorrorFlux.Membership.Database.Contexts;
using HorrorFlux.Membership.Database.Entities;
using HorrorFlux.Membership.Database.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.FileProviders.Composite;
using static System.Collections.Specialized.BitVector32;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(policy =>
{
    policy.AddPolicy("CorsAllAccessPolicy", opt =>
        opt.AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod()
    );
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HorrorFluxContext>(
options => options.UseSqlServer(
builder.Configuration.GetConnectionString("VODConnection")));
builder.Services.AddScoped<IDbService, DbService>();
ConfigureAutoMapper();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsAllAccessPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfigureAutoMapper()
{
    var config = new AutoMapper.MapperConfiguration(cfg =>
    {
        cfg.CreateMap<Film, FilmDTO>()
        .ForMember(dest => dest.DirectorName, src => src.MapFrom(film => film.Director.Name))
        .ForMember(dest => dest.SimilarFilms, src => src.MapFrom(similarFilms => similarFilms.SimilarFilms))
        .ReverseMap()
        .ForMember(dest => dest.Director, src => src.Ignore()); //Om man lägger till en ny film via denna kontroller så kommer ju inte den skapa en director-connection. Så frågan är ifall man ska låta den hänga med?



        cfg.CreateMap<Director, DirectorDTO>().ReverseMap();

        cfg.CreateMap<Genre, GenreDTO>().ReverseMap();

        cfg.CreateMap<AddGenreDTO, Genre>();
        cfg.CreateMap<EditGenreDTO, Genre>();

        cfg.CreateMap<addFilmDTO, Film>();

        cfg.CreateMap<SimilarFilms, SimilarFilmsNameDTO>()
        .ForMember(dest => dest.ParentFilmTitle, src => src.MapFrom(parentFilm => parentFilm.ParentFilm.Title))
        .ForMember(dest => dest.SimilarFilmTitle, src => src.MapFrom(parentFilm => parentFilm.SimilarFilm.Title))
         .ReverseMap()
        .ForMember(dest => dest.SimilarFilm, src => src.Ignore())
        .ForMember(dest => dest.ParentFilm, src => src.Ignore());

        cfg.CreateMap<FilmGenre, FilmGenreNameDTO>()
        .ForMember(dest => dest.FilmName, src => src.MapFrom(film => film.Film.Title))
        .ForMember(dest => dest.GenreName, src => src.MapFrom(genre => genre.Genre.Name))
        .ReverseMap()
        .ForMember(dest => dest.Genre, src => src.Ignore())
        .ForMember(dest => dest.Film, src => src.Ignore());

        cfg.CreateMap<editFilmDTO, Film>();

        cfg.CreateMap<FilmGenre, FilmGenreDTO>().ReverseMap();

        cfg.CreateMap<Director, DirectorNameDTO>();

        cfg.CreateMap<AddDirector, Director>();
        cfg.CreateMap<EditDirector, Director>();

        cfg.CreateMap<SimilarFilms, ListSimilarFilmsDTO>();
        cfg.CreateMap<SimilarFilms, SimilarFilmsDTO>().ReverseMap();
        //.ForMember(dest => dest.ParentFilm, src => src.MapFrom(film => film.ParentFilm))
        //.ForMember(dest => dest.SimilarFilm, src => src.MapFrom(film => film.SimilarFilm));

        cfg.CreateMap<Film, previewFilmDTO>();

        cfg.CreateMap<SimilarFilms, previewFilmDTO>()
        .ForMember(dest => dest.Id, src => src.MapFrom(similarFilm => similarFilm.SimilarFilm.Id))
        .ForMember(dest => dest.Title, src => src.MapFrom(similarFilm => similarFilm.SimilarFilm.Title))
        .ForMember(dest => dest.FilmPoster, src => src.MapFrom(similarFilm => similarFilm.SimilarFilm.FilmPoster));

        cfg.CreateMap<Film, SingleFilmDTO>()
        .ForMember(dest => dest.Films, src => src.MapFrom(entity => entity.SimilarFilms));
        //.ForMember(dest => dest.Films, src => src.MapFrom(similar => similar.SimilarFilms.ToList()));
        //.ReverseMap(); Om man tar bort reverse-map så kan den inte användas åt andra håller bara?
    });
    var mapper = config.CreateMapper();
    builder.Services.AddSingleton(mapper);
}

