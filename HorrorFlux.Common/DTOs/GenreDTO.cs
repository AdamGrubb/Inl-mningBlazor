using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorrorFlux.Common.DTOs
{
    public  class GenreDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<FilmDTO> Films { get; set; }
    }
    public class AddGenreDTO
    {
        public string Name { get; set; }
    }
    public class EditGenreDTO : AddGenreDTO
    {
        public int Id { get; set; }
    }
}
