using MovieAPI.Application.Wrappers;
using MediatR;
using MovieAPI.Application.Dtos.MovieDtos;

namespace MovieAPI.Application.Cqrs.Commands.MovieCommands;

public class UpdateNoteAndPointMovieCommand : IRequest<ApiResponse<MovieGetAllDto>>
{
    public Guid Id { get; set; }
    public bool adult { get; set; }
    public string? backdrop_path { get; set; }
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
    public string? note { get; set; }
    public int? point { get; set; }
}