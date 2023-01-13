using AutoMapper;
using FluentValidation;
using MovieAPI.Application.Cqrs.Queries.UserQueries;
using MovieAPI.Application.Dtos.UserDtos;
using MovieAPI.Application.Wrappers;
using MovieAPI.Domain.Entities;
using MovieAPI.Infrastructure.Data.Context;
using MovieAPI.Infrastructure.UnitOfWork;
using MediatR;
using System.Net;

namespace MovieAPI.Application.Cqrs.QueryHandlers.UserQueryHandlers;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ApiResponse<UserDto>>
{
    private readonly IUnitOfWork<AppDbContext> _unitOfWork;
    private readonly IMapper _mapper;

    public GetUserByIdQueryHandler(IUnitOfWork<AppDbContext> unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ApiResponse<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var existEntity = await _unitOfWork.GetRepository<User>().GetByIdAsync(request.Id);

        if (existEntity is null)
            throw new ValidationException("User is not found.");

        return new ApiResponse<UserDto>
        {
            Data = _mapper.Map<UserDto>(existEntity),
            StatusCode = (int)HttpStatusCode.OK,
            IsSuccessful = true,
        };
    }
}