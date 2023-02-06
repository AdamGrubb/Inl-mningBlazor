using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorrorFlux.Common.DTOs
{
    public class SimilarFilmsDTO
    {
        public int ParentFilmId { get; set; }

        public int SimilarFilmId { get; set; }

        public  FilmDTO ParentFilm { get; set; }
        public  FilmDTO SimilarFilm { get; set; }
    }
}
