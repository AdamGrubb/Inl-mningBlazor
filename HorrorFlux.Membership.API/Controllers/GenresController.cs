// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HorrorFlux.Membership.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GenresController : ControllerBase
{
    private readonly IDbService _db;

    public GenresController(IDbService db)
    {
        _db = db;
    }
    // GET: api/<GenresController>
    [HttpGet]
    public async Task<IResult> Get()
    {
        try
        {
            _db.Include<FilmGenre>();
            var genres = await _db.GetAsync<Genre, GenreDTO>();
            return Results.Ok(genres);
        }
        catch (Exception ex)
        {
            return Results.BadRequest(ex);
        }

    }

    // GET api/<GenresController>/5
    [HttpGet("{id}")]
    public async Task<IResult> Get(int id)
    {
        try
        {
            _db.Include<FilmGenre>();
            var film = await _db.SingleAsync<Genre, GenreDTO>(genre => genre.Id == id);
            if (film == null) return Results.NotFound();
            return Results.Ok(film);
        }
        catch (Exception ex)
        {
            return Results.BadRequest(ex);
        }
    }

    // POST api/<GenresController>
    [HttpPost]
    public async Task<IResult> Post([FromBody] AddGenreDTO addGenreDTO)
    {
        try
        {
            if (addGenreDTO == null) return Results.BadRequest();
            var genre = await _db.AddAsync<Genre, AddGenreDTO>(addGenreDTO);
            var sucess = await _db.SaveChangesAsync();
            if (sucess == false) return Results.BadRequest();
            return Results.Created(_db.GetURI(genre), genre);
        }
        catch (Exception ex)
        {
            return Results.BadRequest(ex);
        }
    }

    // PUT api/<GenresController>/5
    [HttpPut("{id}")]
    public async Task<IResult> Put(int id, [FromBody] EditGenreDTO editGenre)
    {
        try
        {
            if (id != editGenre.Id || editGenre == null) return Results.BadRequest();
            _db.Update<Genre, EditGenreDTO>(id, editGenre);
            var result = await _db.SaveChangesAsync();
            if (result) return Results.NoContent();
            else return Results.BadRequest();
        }
        catch (Exception ex)
        {
            return Results.BadRequest(ex);
        }

    }

    // DELETE api/<GenresController>/5
    [HttpDelete("{id}")]
    public async Task<IResult> Delete(int id)
    {
        try
        {
            var success = await _db.DeleteAsync<Genre>(id);
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
