

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HorrorFlux.Membership.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SimilarFilmsController : ControllerBase
{

    private readonly IDbService _db;
    public SimilarFilmsController(IDbService db)
    {
        _db = db;
    }
    [HttpGet]
    public async Task<IResult> Get()
    {
        try
        {
            _db.Include<SimilarFilms>();
            var filmGenres = await _db.GetRefAsync<SimilarFilms, SimilarFilmsDTO>();

            return Results.Ok(filmGenres);
        }
        catch (Exception ex)
        {
            return Results.BadRequest(ex);
        }

    }
    // POST api/<SimilarFilmsController>
    [HttpPost]
    public async Task<IResult> Post([FromBody] SimilarFilmsDTO similarFilmsDTO)
    {
        try
        {
            if (similarFilmsDTO == null) return Results.BadRequest();
            if (similarFilmsDTO.ParentFilmId == similarFilmsDTO.SimilarFilmId) return Results.BadRequest("You cannot set the Parentfilm id to the same film");
            var exist = await _db.AnyAsyncReferenceTable<SimilarFilms>(fg => fg.ParentFilmId == similarFilmsDTO.ParentFilmId && fg.SimilarFilmId == similarFilmsDTO.SimilarFilmId);
            if (exist) return Results.BadRequest("Connection already exists");
            var similarFilms = await _db.AddRefAsync<SimilarFilms, SimilarFilmsDTO>(similarFilmsDTO);
            var sucess = await _db.SaveChangesAsync();
            if (sucess == false) return Results.BadRequest();
            return Results.Created($"/SimilarFilms/{similarFilms.ParentFilmId}{similarFilms.SimilarFilmId}", similarFilms);
        }
        catch (Exception ex)
        {
            return Results.BadRequest(ex);
        }
    }

    // DELETE api/<SimilarFilmsController>/5
    [HttpDelete]
    public async Task<IResult> Delete([FromQuery] int[] id)
    {
        try
        {
            var success = _db.DeleteRef<SimilarFilms, SimilarFilmsDTO>(new SimilarFilmsDTO(){ ParentFilmId = id[0], SimilarFilmId = id[1] });
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
