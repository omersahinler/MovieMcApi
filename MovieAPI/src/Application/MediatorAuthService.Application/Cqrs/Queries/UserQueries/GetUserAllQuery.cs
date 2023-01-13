using MovieAPI.Application.Dtos.UserDtos;
using MovieAPI.Application.Wrappers;
using MovieAPI.Domain.Core.Pagination;
using MediatR;

namespace MovieAPI.Application.Cqrs.Queries.UserQueries;

public class GetUserAllQuery : PaginationParams, IRequest<ApiResponse<List<UserDto>>>
{
    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Email { get; set; }

    public bool? IsActive { get; set; }
}