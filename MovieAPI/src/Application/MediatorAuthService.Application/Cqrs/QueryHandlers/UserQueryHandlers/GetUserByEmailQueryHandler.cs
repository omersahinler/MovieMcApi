using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MovieAPI.Application.Cqrs.Queries.UserQueries;
using MovieAPI.Application.Dtos.UserDtos;
using MovieAPI.Application.Wrappers;
using MovieAPI.Domain.Entities;
using MovieAPI.Infrastructure.Data.Context;
using MovieAPI.Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace MovieAPI.Application.Cqrs.QueryHandlers.UserQueryHandlers;

public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, ApiResponse<UserDto>>
{
    private readonly IUnitOfWork<AppDbContext> _unitOfWork;
    private readonly IMapper _mapper;

    public GetUserByEmailQueryHandler(IUnitOfWork<AppDbContext> unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ApiResponse<UserDto>> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        var data = await _unitOfWork.GetRepository<User>()
            .Where(x => x.Email.Equals(request.Email))
            .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(cancellationToken);

        if (data is null)
            throw new ValidationException("User is not found.");

        return new ApiResponse<UserDto>
        {
            Data = _mapper.Map<UserDto>(data),
            IsSuccessful = true,
            StatusCode = (int)HttpStatusCode.OK,
            TotalItemCount = 1
        };
    }
}