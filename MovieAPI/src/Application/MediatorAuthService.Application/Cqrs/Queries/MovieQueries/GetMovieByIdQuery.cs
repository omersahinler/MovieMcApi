using MovieAPI.Application.Dtos.UserDtos;
using MovieAPI.Application.Wrappers;
using MediatR;
using MovieAPI.Application.Dtos.MovieDtos;

namespace MovieAPI.Application.Cqrs.Queries.MovieQueries;

public class GetMovieByIdQuery : IRequest<ApiResponse<MovieDto>>
{
    public Guid Id { get; private set; }

    public GetMovieByIdQuery(Guid id)
    {
        Id = id;
    }
}