using System.ComponentModel.DataAnnotations.Schema;

namespace HorrorFlux.Membership.Database.Entities;

public class SimilarFilms
{
    [Key]
    [Column(Order = 1)]
    public int ParentFilmId { get; set; }
    [Key]
    [Column(Order = 2)]
    public int SimilarFilmId { get; set; }

    public virtual Film ParentFilm { get; set; }
    public virtual Film SimilarFilm { get; set; }
}
