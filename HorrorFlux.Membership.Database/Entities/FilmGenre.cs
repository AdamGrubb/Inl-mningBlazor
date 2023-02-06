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
        //[Key]
        //[Column(Order = 1)]
        public int FilmId { get; set; }
        //[Key]
        //[Column(Order = 2)]
        public int GenreId { get; set; }

        public virtual Film Film { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
