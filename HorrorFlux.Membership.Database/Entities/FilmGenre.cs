using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorrorFlux.Membership.Database.Entities
{
    public class FilmGenre
    {
        public int FilmId { get; set; }
        public int GenreId { get; set; }

        public Film Film { get; set; }
        public Genre Genre { get; set; }
    }
}
