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
        //public previewFilmDTO ParentFilm { get; set; }

        public previewFilmDTO SimilarFilm { get; set; }

    }
}
