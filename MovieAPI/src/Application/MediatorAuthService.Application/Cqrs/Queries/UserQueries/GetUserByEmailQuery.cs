using MovieAPI.Application.Dtos.UserDtos;
using MovieAPI.Application.Wrappers;
using MediatR;

namespace MovieAPI.Application.Cqrs.Queries.UserQueries;

public class GetUserByEmailQuery : IRequest<ApiResponse<UserDto>>
{
    public string Email { get; private set; }

    public GetUserByEmailQuery(string email)
    {
        Email = email;
    }
}