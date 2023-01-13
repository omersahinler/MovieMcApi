using FluentValidation;
using MovieAPI.Application.Cqrs.Commands.UserCommands;
using MovieAPI.Application.Dtos.ResponseDtos;
using MovieAPI.Application.Wrappers;
using MovieAPI.Domain.Entities;
using MediatR;
using System.Net;
using MovieAPI.Infrastructure.UnitOfWork;

namespace MovieAPI.Application.Cqrs.CommandHandlers.UserComandHandlers;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ApiResponse<NoDataDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse<NoDataDto>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var existUser = await _unitOfWork.GetRepository<User>().GetByIdAsync(request.Id);

        if (existUser is null)
            throw new ValidationException("User is not found.");

        _unitOfWork.GetRepository<User>().Remove(existUser);
        await _unitOfWork.SaveChangesAsync();

        return new ApiResponse<NoDataDto>
        {
            StatusCode = (int)HttpStatusCode.NoContent,
            IsSuccessful = true,
        };
    }
}