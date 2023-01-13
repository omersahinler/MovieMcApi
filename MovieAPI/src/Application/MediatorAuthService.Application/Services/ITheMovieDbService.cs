
using Refit;
using MovieAPI.Application.Dtos.MovieDtos;


namespace MovieAPI.Application.Services;
public interface ITheMovieDbService 
{
    [Get("https://api.themoviedb.org/3/search/movie?api_key=e57cace9b13afb3800f0cfa7d73b7e54&query=Jack+Reacher")]
    [Headers("Content-Type: application/json")]
    Task<MovieResponse> getMoviesAsync();
}