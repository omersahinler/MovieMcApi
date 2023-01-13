﻿using MovieAPI.Application.Dtos.ResponseDtos;
using MovieAPI.Application.Wrappers;
using MediatR;

namespace MovieAPI.Application.Cqrs.Commands.UserCommands;

public class DeleteUserCommand : IRequest<ApiResponse<NoDataDto>>
{
    public Guid Id { get; private set; }

    public DeleteUserCommand(Guid id)
    {
        Id = id;
    }
}