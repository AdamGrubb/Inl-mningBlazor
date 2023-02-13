using HorrorFlux.Common.DTOs;
using HorrorFlux.Membership.Database.Entities;
using HorrorFlux.Membership.Database.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HorrorFlux.Membership.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly IDbService _db;

        public FilmsController(IDbService db)
        {
            _db = db;
        }
        // GET: api/<FilmController>
        [HttpGet]
        public async Task<IResult> Get()
        {
            try //Du får göra om den här try catchen.
            {
                _db.Include<Director>();
                _db.Include<SimilarFilms>();
                var films = await  _db.GetAsync<Film, FilmDTO>();
                bool freeOnly = true;

                List<FilmDTO> returnList = freeOnly ? films.Where(film => film.Free == true).ToList() : films;

                return Results.Ok(returnList);
            }
            catch 
            { 
            }
            return Results.NotFound();
        }

        // GET api/<FilmController>/5
        [HttpGet("{id}")]
        public async Task<IResult> Get(int id) //Här borde du kunna speca vad du är ute efter!
        {
            try //Du får göra om den här try catchen.
            {
                _db.Include<Director>();
                //_db.IncludeFilmGenre(id);
                _db.Include<FilmGenre>();
                _db.Include<SimilarFilms>();
                var film = await _db.SingleAsync<Film, SingleFilmDTO>(film => film.Id == id);
                //var film = await _db.GetSingleFilm(id);
                return Results.Ok(film);
            }
            catch
            {
            }
            return Results.NotFound();
        }

        // POST api/<FilmController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] addFilmDTO addFilm)
        {
           if (addFilm == null) return Results.BadRequest();
           var film = await _db.AddAsync<Film, addFilmDTO>(addFilm);
           var sucess = await _db.SaveChangesAsync();
           if (sucess==false) return Results.BadRequest();
           return Results.Created(_db.GetURI(film), film);
        }

        // PUT api/<FilmController>/5
        [HttpPut("{id}")]
        public async Task<IResult> Put(int id, [FromBody] editFilmDTO editFilm)
        {
            if (id != editFilm.Id || editFilm==null) return Results.BadRequest();
            var exist = await _db.AnyAsync<Director>(d => d.Id == editFilm.DirectorId);
            if (exist ==false) return Results.NotFound();
            _db.Update<Film,editFilmDTO>(id, editFilm);
            var result = await _db.SaveChangesAsync();
            if (result) return Results.NoContent();
            else return Results.BadRequest();

        }

        // DELETE api/<FilmController>/5
        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id)
        {
            var success = await _db.DeleteAsync<Film>(id);
            if (success == false) return Results.NotFound();
            success = await _db.SaveChangesAsync();
            if (success == false) return Results.BadRequest();
            return Results.NoContent();
        }


    }
}
