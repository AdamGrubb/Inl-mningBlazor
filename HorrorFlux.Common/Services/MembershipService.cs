namespace HorrorFlux.Common.Services;

public class MembershipService : IMembershipService
{
    private readonly MembershipHttpClient _http;

    public MembershipService(MembershipHttpClient http)
    {
        _http = http;

    }

    public async Task<List<FilmDTO>> GetFilmsAsync()
    {
        try
        {
            bool freeOnly = false;
            HttpResponseMessage respons = await _http.Client.GetAsync($"Films?freeOnly={freeOnly}");
            respons.EnsureSuccessStatusCode();
            var result = JsonSerializer.Deserialize<List<FilmDTO>>(await respons.Content.ReadAsStreamAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return result ?? new List<FilmDTO>();

        }
        catch (Exception)
        {

            return new List<FilmDTO>();
        }
    }
    public async Task<FilmDTO> GetFilmAsync(int? id)
    {
        try
        {
            if (id == null) return new FilmDTO();
            HttpResponseMessage respons = await _http.Client.GetAsync($"Films/{id}");
            respons.EnsureSuccessStatusCode();
            var result = JsonSerializer.Deserialize<FilmDTO>(await respons.Content.ReadAsStreamAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return result ?? new FilmDTO();

        }
        catch (Exception)
        {

            return new FilmDTO();
        }
    }
    public async Task<List<GenreDTO>> GetGenresAsync()
    {
        try
        {
            HttpResponseMessage respons = await _http.Client.GetAsync("Genres");
            respons.EnsureSuccessStatusCode();
            var result = JsonSerializer.Deserialize<List<GenreDTO>>(await respons.Content.ReadAsStreamAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return result ?? new List<GenreDTO>();

        }
        catch (Exception)
        {

            return new List<GenreDTO>();
        }
    }
    public async Task<GenreDTO> GetGenreAsync(int? id)
    {
        try
        {
            if (id == null) return new GenreDTO();
            HttpResponseMessage respons = await _http.Client.GetAsync($"Genres/{id}");
            respons.EnsureSuccessStatusCode();
            var result = JsonSerializer.Deserialize<GenreDTO>(await respons.Content.ReadAsStreamAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return result ?? new GenreDTO();

        }
        catch (Exception)
        {

            return new GenreDTO();
        }
    }
    public async Task<List<DirectorDTO>> GetDirectorsAsync()
    {
        try
        {
            HttpResponseMessage respons = await _http.Client.GetAsync($"Directors");
            respons.EnsureSuccessStatusCode();
            var result = JsonSerializer.Deserialize<List<DirectorDTO>>(await respons.Content.ReadAsStreamAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return result ?? new List<DirectorDTO>();

        }
        catch (Exception)
        {

            return new List<DirectorDTO>();
        }
    }
    public async Task<DirectorDTO> GetDirectorAsync(int? id)
    {
        try
        {
            if (id == null) return new DirectorDTO();
            HttpResponseMessage respons = await _http.Client.GetAsync($"Directors/{id}");
            respons.EnsureSuccessStatusCode();
            var result = JsonSerializer.Deserialize<DirectorDTO>(await respons.Content.ReadAsStreamAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return result ?? new DirectorDTO();

        }
        catch (Exception)
        {

            return new DirectorDTO();
        }
    }
}
