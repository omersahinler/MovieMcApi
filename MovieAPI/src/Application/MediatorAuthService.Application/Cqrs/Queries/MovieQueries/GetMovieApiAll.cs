using MediatR;
using MovieAPI.Application.Dtos.ResponseDtos;
using MovieAPI.Application.Wrappers;

namespace MovieAPI.Application.Cqrs.Queries.MovieQueries;

public class GetMoviesApiAll : IRequest<ApiResponse<NoDataDto>>
{
    
}