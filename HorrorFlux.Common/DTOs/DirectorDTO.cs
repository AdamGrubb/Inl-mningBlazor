namespace HorrorFlux.Common.DTOs;

public class DirectorDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public  List<FilmDTO> Films { get; set; }
}
 public class AddDirector
{
    public string Name { get; set; }
}
public class EditDirector : AddDirector
{
    public int Id { get; set; }
}
