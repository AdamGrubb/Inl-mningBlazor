﻿using HorrorFlux.Common.DTOs;
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
            try
            {
                _db.Include<Director>();
                var films = await  _db.GetAsync<Film, FilmDTO>();
                bool freeOnly = true;

                List<FilmDTO> returnList = freeOnly ? films.Where(film => film.Free == true).ToList() : films;

                return Results.Ok(films);
            }
            catch 
            { 
            }
            return Results.NotFound();
        }

        // GET api/<FilmController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FilmController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FilmController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FilmController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}