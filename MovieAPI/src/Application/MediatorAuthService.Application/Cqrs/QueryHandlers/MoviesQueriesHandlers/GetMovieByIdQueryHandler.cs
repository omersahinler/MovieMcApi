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
using MovieAPI.Application.Cqrs.Queries.MovieQueries;
using MovieAPI.Application.Dtos.MovieDtos;

namespace MovieAPI.Application.Cqrs.QueryHandlers.MovieQueryHandlers;

public class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, ApiResponse<MovieDto>>
{
    private readonly IUnitOfWork<AppDbContext> _unitOfWork;
    private readonly IMapper _mapper;

    public GetMovieByIdQueryHandler(IUnitOfWork<AppDbContext> unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ApiResponse<MovieDto>> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
    {
        var existEntity = await _unitOfWork.GetRepository<Movie>().GetByIdAsync(request.Id);

        if (existEntity is null)
            throw new ValidationException("Movie is not found.");

        return new ApiResponse<MovieDto>
        {
            Data = _mapper.Map<MovieDto>(existEntity),
            StatusCode = (int)HttpStatusCode.OK,
            IsSuccessful = true,
        };
    }
}