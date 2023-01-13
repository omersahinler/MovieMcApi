using MovieAPI.Application.Dtos.AuthDtos;
using MovieAPI.Application.Wrappers;
using MediatR;

namespace MovieAPI.Application.Cqrs.Commands.AuthCommands;

public class CreateTokenByRefreshTokenCommand : IRequest<ApiResponse<TokenDto>>
{
    public string RefreshToken { get; set; }

    public CreateTokenByRefreshTokenCommand(string refreshToken)
    {
        RefreshToken = refreshToken;
    }
}