using HorrorFlux.Common.DTOs;

namespace HorrorFlux.Common.Services
{
    public interface IMembershipService
    {
        Task<DirectorDTO> GetDirectorAsync(int? id);
        Task<List<DirectorDTO>> GetDirectorsAsync();
        Task<FilmDTO> GetFilmAsync(int? id);
        Task<List<FilmDTO>> GetFilmsAsync();
        Task<GenreDTO> GetGenreAsync(int? id);
        Task<List<GenreDTO>> GetGenresAsync();
    }
}