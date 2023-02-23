namespace HorrorFlux.Common.DTOs;

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
    public List<string> Genre { get; set; } = new();
    public List<previewFilmDTO> SimilarFilms { get; set; } = new();
}
public class previewFilmDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string FilmPoster { get; set; }
}
public class addFilmDTO
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string FilmUrl { get; set; }
    public string FilmPoster { get; set; }
    public DateTime Release { get; set; }
    public bool Free { get; set; }
    public int DirectorId { get; set; }
}
public class editFilmDTO : addFilmDTO
{
    public int Id { get; set; }
}
