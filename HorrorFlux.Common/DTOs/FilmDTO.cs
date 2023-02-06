using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorrorFlux.Common.DTOs
{
    public class FilmDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string FilmUrl { get; set; }
        public string FilmPoster { get; set; }
        public DateTime Release { get; set; }
        public int DirectorId { get; set; }
        public  DirectorDTO Director { get; set; }
        public  List<SimilarFilmsDTO> SimilarFilms { get; set; }
        public  List<FilmGenreDTO> FilmGenres { get; set; }
    }
}
