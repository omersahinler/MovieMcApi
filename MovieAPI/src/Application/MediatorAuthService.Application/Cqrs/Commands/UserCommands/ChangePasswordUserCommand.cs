using MovieAPI.Application.Dtos.ResponseDtos;
using MovieAPI.Application.Wrappers;
using MediatR;

namespace MovieAPI.Application.Cqrs.Commands.UserCommands;

public class ChangePasswordUserCommand : IRequest<ApiResponse<NoDataDto>>
{
    public string OldPassword { get; set; }

    public string NewPassword { get; set; }

    public ChangePasswordUserCommand(string oldPassword, string newPassword)
    {
        OldPassword = oldPassword;
        NewPassword = newPassword;
    }
}