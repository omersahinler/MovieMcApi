using MovieAPI.Application.Dtos.UserDtos;
using MovieAPI.Application.Wrappers;
using MovieAPI.Domain.Core.Pagination;
using MediatR;
using MovieAPI.Application.Dtos.MovieDtos;

namespace MovieAPI.Application.Cqrs.Queries.MovieQueries;

public class GetMovieAllQuery : PaginationParams, IRequest<ApiResponse<List<MovieGetAllDto>>>
{
    
}