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
        public bool Free { get; set; }
        public int DirectorId { get; set; }
        public  string DirectorName { get; set; }
        public  List<SimilarFilmsDTO> SimilarFilms { get; set; } //Ta bort denna? Eller ha nån annan laddningstyp?
        //public  List<GenreDTO> Genres { get; set; } //Ta bort denna? Snarare en string-lista på vilken Genre den har?
    }
    public class SingeFilmDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string FilmUrl { get; set; }
        public string FilmPoster { get; set; }
        public DateTime Release { get; set; }
        public bool Free { get; set; }
        public int DirectorId { get; set; }
        public DirectorDTO Director { get; set; }
        public IEnumerable<GenreDTO> Genres { get; set; } //Ta bort denna? Eller ha nån annan laddningstyp?
        public IEnumerable<SimilarFilmsDTO> Films { get; set; } //Ta bort denna? Snarare en string-lista på vilken Genre den har?
    }
    public class previewFilmDTO
    {
        public string Title { get; set; }
        public string FilmPoster { get; set; }
    }

    //public int Id { get; set; }
    //[MaxLength(50)]
    //public string Title { get; set; }
    //[MaxLength(200)]
    //public string Description { get; set; }
    //[MaxLength(1024)]
    //public string FilmUrl { get; set; }

    //public bool Free { get; set; }
    //[MaxLength(1024)]
    //public string FilmPoster { get; set; }
    //public DateTime Release { get; set; }
    //public int DirectorId { get; set; }
    //public Director Director { get; set; }
    //public ICollection<SimilarFilms> SimilarFilms { get; set; }
    //public ICollection<Genre> Genres { get; set; }
}
