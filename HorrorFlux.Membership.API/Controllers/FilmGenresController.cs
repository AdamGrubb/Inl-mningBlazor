using HorrorFlux.Common.DTOs;
using HorrorFlux.Membership.Database.Entities;
using HorrorFlux.Membership.Database.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HorrorFlux.Membership.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmGenresController : ControllerBase
    {
        private readonly IDbService _db;
        public FilmGenresController(IDbService db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IResult> Get()
        {
            try //Du får göra om den här try catchen.
            {
                _db.Include<FilmGenre>();
                var filmGenres = await _db.GetRefAsync<FilmGenre, FilmGenreNameDTO>();

                return Results.Ok(filmGenres);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex);
            }

        }
        // POST api/<FilmGenresController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] FilmGenreDTO filmGenreDTO)
        {
            try
            {
                if (filmGenreDTO == null) return Results.BadRequest();
                var exist = await _db.AnyAsyncReferenceTable<FilmGenre>(fg => fg.FilmId == filmGenreDTO.FilmId && fg.GenreId == filmGenreDTO.GenreId);
                if (exist) return Results.BadRequest("Connection already exists");
                var filmGenre = await _db.AddRefAsync<FilmGenre, FilmGenreDTO>(filmGenreDTO); //Ändra och eventuellt lägga till en till Interface för referenstabeller=
                var sucess = await _db.SaveChangesAsync();
                if (sucess == false) return Results.BadRequest();
                return Results.Created($"/FilmGenres/{filmGenre.FilmId}{filmGenre.GenreId}", filmGenre);
            }
            catch (Exception ex) //Här borde du göra en catch för ifall den kombinationen redan finns. Eller en if-sats
            {
                return Results.BadRequest(ex);
            }
        }
        // DELETE api/<FilmGenresController>/5 //("{id}") Vet inte helt säkert varför man ska ha kvar id här?
        [HttpDelete]
        public async Task<IResult> Delete([FromQuery] int [] id) //Testa göra en kontroller där man stoppar in 
        {
            try
            {
                
                var success =  _db.DeleteRef<FilmGenre, FilmGenreDTO>(new () { FilmId = id[0], GenreId = id[1] });
                if (success == false) return Results.NotFound();
                success = await _db.SaveChangesAsync();
                if (success == false) return Results.BadRequest();
                return Results.NoContent();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex);
            }
        }
    }
}
