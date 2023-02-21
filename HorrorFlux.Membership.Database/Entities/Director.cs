namespace HorrorFlux.Membership.Database.Entities;

public class Director : IEntity
{
    public int Id { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
    public ICollection<Film> Films { get; set; }
}
