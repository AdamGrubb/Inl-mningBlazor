using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorrorFlux.Common.DTOs
{
    public class FilmGenreDTO
    {
        public int FilmId { get; set; }

        public int GenreId { get; set; }

        public string? FilmName { get; set; }
        public string? GenreName { get; set; }
    }
    //public class FilmGenreNameDTO
    //{
    //    public int FilmId { get; set; }

    //    public int GenreId { get; set; }

    //    public string FilmName { get; set; }
    //    public string GenreName { get; set; }
    //}
}
