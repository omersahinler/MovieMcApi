﻿using AutoMapper;
using MovieAPI.Application.Cqrs.Commands.UserCommands;
using MovieAPI.Application.Dtos.UserDtos;
using MovieAPI.Application.Exceptions;
using MovieAPI.Application.Wrappers;
using MovieAPI.Domain.Core.Extensions;
using MovieAPI.Domain.Entities;
using MovieAPI.Infrastructure.UnitOfWork;
using MediatR;
using System.Net;

namespace MovieAPI.Application.Cqrs.CommandHandlers.UserComandHandlers;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ApiResponse<UserDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ApiResponse<UserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        bool isExistUserByEmail = await _unitOfWork.GetRepository<User>().AnyAsync(x => x.Email.Equals(request.Email));

        if (isExistUserByEmail)
            throw new BusinessException("There is a record of the e-mail address.");

        request.Password = HashingManager.HashValue(request.Password);

        var userEntity = _mapper.Map<User>(request);

        userEntity.RefreshToken = HashingManager.HashValue(Guid.NewGuid().ToString());

        await _unitOfWork.GetRepository<User>().AddAsync(userEntity);
        await _unitOfWork.SaveChangesAsync();

        return new ApiResponse<UserDto>
        {
            Data = _mapper.Map<UserDto>(userEntity),
            IsSuccessful = true,
            StatusCode = (int)HttpStatusCode.Created,
            TotalItemCount = 1
        };
    }
}