namespace HorrorFlux.Common.DTOs;

public  class GenreDTO
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<previewFilmDTO> Films { get; set; }
}
public class AddGenreDTO
{
    public string Name { get; set; }
}
public class EditGenreDTO : AddGenreDTO
{
    public int Id { get; set; }
}
