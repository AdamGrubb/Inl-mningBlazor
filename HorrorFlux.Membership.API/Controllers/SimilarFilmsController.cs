﻿using HorrorFlux.Common.DTOs;
using HorrorFlux.Membership.Database.Entities;
using HorrorFlux.Membership.Database.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HorrorFlux.Membership.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimilarFilmsController : ControllerBase
    {

        private readonly IDbService _db;
        public SimilarFilmsController(IDbService db)
        {
            _db = db;
        }
        // POST api/<SimilarFilmsController>
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

        // DELETE api/<SimilarFilmsController>/5
        [HttpDelete] //("{id}") Samma sak här, varför ska man ha kvar ID? Möjligen sätta tillbaka den när du ska göra en GetURI till Post
        public async Task<IResult> Delete(FilmGenreDTO filmGenreDTO)
        {
            try
            {
                var success = _db.DeleteRef<FilmGenre, FilmGenreDTO>(filmGenreDTO);
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
