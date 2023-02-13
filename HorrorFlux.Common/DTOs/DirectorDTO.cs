using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorrorFlux.Common.DTOs
{
    public class DirectorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public  List<FilmDTO> Films { get; set; }
    }
    public class DirectorNameDTO //Den här får du använda sen när du ska ha även navigationspropertys för den Typ hämta alla directors filmer.
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public  List<FilmDTO> Films { get; set; }
    }
}
