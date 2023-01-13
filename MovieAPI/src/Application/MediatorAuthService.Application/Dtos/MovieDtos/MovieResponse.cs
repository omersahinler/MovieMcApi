using Newtonsoft.Json;

namespace MovieAPI.Application.Dtos.MovieDtos;
public class MovieDto
{
    public bool adult { get; set; }
    public string? backdrop_path { get; set; }
    public List<int> genre_ids { get; set; }
    [JsonProperty(PropertyName = "id")]
    public int source_id { get; set; }
    public string original_language { get; set; }
    public string original_title { get; set; }
    public string overview { get; set; }
    public double popularity { get; set; }
    public string? poster_path { get; set; }
    public string? release_date { get; set; }
    public string? title { get; set; }
    public bool video { get; set; }
    public double vote_average { get; set; }
    public int vote_count { get; set; }
}

public class MovieResponse
{
    public int page { get; set; }
    public List<MovieDto> results { get; set; }
    public int total_pages { get; set; }
    public int total_results { get; set; }
}