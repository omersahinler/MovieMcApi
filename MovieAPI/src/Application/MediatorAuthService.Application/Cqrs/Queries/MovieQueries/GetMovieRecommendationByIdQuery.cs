using MovieAPI.Application.Dtos.UserDtos;
using MovieAPI.Application.Wrappers;
using MediatR;
using MovieAPI.Application.Dtos.MovieDtos;

namespace MovieAPI.Application.Cqrs.Queries.MovieQueries;

public class GetMovieRecommendationByIdQuery : IRequest<ApiResponse<MovieDto>>
{
    public Guid Id { get; private set; }
    public string MailTo { get; set; }

    public GetMovieRecommendationByIdQuery(Guid id, string mailTo)
    {
        Id = id;
        MailTo = mailTo;
    }
}