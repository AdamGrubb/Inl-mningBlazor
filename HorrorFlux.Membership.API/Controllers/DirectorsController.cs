// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HorrorFlux.Membership.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DirectorsController : ControllerBase
{

    private readonly IDbService _db;

    public DirectorsController(IDbService db)
    {
        _db = db;
    }
    // GET: api/<DirectorsController>
    [HttpGet]
    public async Task<IResult> Get()
    {
        try
        {
            _db.Include<Film>();
            var directors = await _db.GetAsync<Director, DirectorDTO>();
            return Results.Ok(directors);
        }
        catch (Exception ex)
        {
            return Results.BadRequest(ex);
        }

    }

    // GET api/<DirectorsController>/5
    [HttpGet("{id}")]
    public async Task<IResult> Get(int id)
    {
        try
        {
            _db.Include<Film>();
            var film = await _db.SingleAsync<Director, DirectorDTO>(director => director.Id == id);
            if (film == null) return Results.NotFound();
            return Results.Ok(film);
        }
        catch (Exception ex)
        {
            return Results.BadRequest(ex);
        }
    }

    // POST api/<DirectorsController>
    [HttpPost]
    public async Task<IResult> Post([FromBody] AddDirector addDirector)
    {
        try
        {
            if (addDirector == null) return Results.BadRequest();
            var director = await _db.AddAsync<Director, AddDirector>(addDirector);
            var sucess = await _db.SaveChangesAsync();
            if (sucess == false) return Results.BadRequest();
            return Results.Created(_db.GetURI(director), director);
        }
        catch (Exception ex)
        {
            return Results.BadRequest(ex);
        }
    }

    // PUT api/<DirectorsController>/5
    [HttpPut("{id}")]
    public async Task<IResult> Put(int id, [FromBody] EditDirector editDirector)
    {
        try
        {
            if (id != editDirector.Id || editDirector == null) return Results.BadRequest();
            _db.Update<Director, EditDirector>(id, editDirector);
            var result = await _db.SaveChangesAsync();
            if (result) return Results.NoContent();
            else return Results.BadRequest();
        }
        catch (Exception ex)
        {
            return Results.BadRequest(ex);
        }

    }

    // DELETE api/<DirectorsController>/5
    [HttpDelete("{id}")]
    public async Task<IResult> Delete(int id)
    {
        try
        {
            var success = await _db.DeleteAsync<Director>(id);
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
