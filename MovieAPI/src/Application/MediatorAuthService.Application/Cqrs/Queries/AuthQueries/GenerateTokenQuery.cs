using MovieAPI.Application.Dtos.AuthDtos;
using MovieAPI.Application.Dtos.UserDtos;
using MovieAPI.Application.Wrappers;
using MediatR;

namespace MovieAPI.Application.Cqrs.Queries.AuthQueries;

internal class GenerateTokenQuery : IRequest<ApiResponse<TokenDto>>
{
    public UserDto User { get; set; }

    public GenerateTokenQuery(UserDto user)
    {
        User = user;
    }
}