namespace HorrorFlux.Membership.Database.Entities;

internal class Film : IEntity
{
    public int Id { get ; set ; }
    [MaxLength(50)]
    public string Title { get; set; }
    [MaxLength(200)]
    public string Description { get; set; }
    [MaxLength(1024)]
    public string FilmUrl { get; set; }
    [MaxLength(1024)]
    public string FilmPoster { get; set; }
    public DateTime Release { get; set; }
    public int DirectorId { get; set; }
}
