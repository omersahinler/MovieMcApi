﻿using FluentValidation;
using MovieAPI.Application.Cqrs.Commands.UserCommands;
using MovieAPI.Application.Dtos.ResponseDtos;
using MovieAPI.Application.Wrappers;
using MovieAPI.Domain.Core.Extensions;
using MovieAPI.Domain.Entities;
using MovieAPI.Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Security.Claims;

namespace MovieAPI.Application.Cqrs.CommandHandlers.UserComandHandlers;

public class ChangePasswordUserCommandHandler : IRequestHandler<ChangePasswordUserCommand, ApiResponse<NoDataDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ChangePasswordUserCommandHandler(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
    {
        _unitOfWork = unitOfWork;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<ApiResponse<NoDataDto>> Handle(ChangePasswordUserCommand request, CancellationToken cancellationToken)
    {
        Guid userId = Guid.Parse(_httpContextAccessor.HttpContext.User.Claims.First(x => x.Type.Equals(ClaimTypes.NameIdentifier)).Value);

        var existUser = await _unitOfWork.GetRepository<User>()
            .Where(user => user.Id.Equals(userId) && user.IsActive)
            .SingleOrDefaultAsync(cancellationToken);

        if (existUser is null)
            throw new ValidationException("User email or password wrong.");

        if (!HashingManager.VerifyHashedValue(existUser.Password, request.OldPassword))
            throw new ValidationException("User email or password wrong.");

        var hashedNewPassword = HashingManager.HashValue(request.NewPassword);

        existUser.Password = hashedNewPassword;
        await _unitOfWork.SaveChangesAsync();

        return new ApiResponse<NoDataDto>
        {
            StatusCode = (int)HttpStatusCode.NoContent
        };
    }
}