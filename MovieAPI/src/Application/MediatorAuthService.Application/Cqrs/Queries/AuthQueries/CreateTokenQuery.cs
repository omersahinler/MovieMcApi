using MovieAPI.Application.Dtos.AuthDtos;
using MovieAPI.Application.Wrappers;
using MediatR;

namespace MovieAPI.Application.Cqrs.Queries.AuthQueries;

public class CreateTokenQuery : IRequest<ApiResponse<TokenDto>>
{
	public string Email { get; set; }

	public string Password { get; set; }
}