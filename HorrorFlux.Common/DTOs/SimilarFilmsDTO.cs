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
    }
    public class ListSimilarFilmsDTO
    {

        public previewFilmDTO SimilarFilm { get; set; }
    }

    public class SimilarFilmsNameDTO
    {
   public int ParentFilmId { get; set; }
   public int SimilarFilmId { get; set; }

        public string ParentFilmTitle { get; set; }
        public string SimilarFilmTitle { get; set; }
    }

}
