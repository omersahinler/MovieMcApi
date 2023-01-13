using MovieAPI.Application.Dtos.UserDtos;
using MovieAPI.Application.Wrappers;
using MediatR;

namespace MovieAPI.Application.Cqrs.Queries.UserQueries;

public class GetUserByIdQuery : IRequest<ApiResponse<UserDto>>
{
    public Guid Id { get; private set; }

    public GetUserByIdQuery(Guid id)
    {
        Id = id;
    }
}