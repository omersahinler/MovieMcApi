using AutoMapper;
using AutoMapper.QueryableExtensions;
using MovieAPI.Application.Dtos.UserDtos;
using MovieAPI.Application.Wrappers;
using MovieAPI.Domain.Core.Pagination;
using MovieAPI.Domain.Entities;
using MovieAPI.Infrastructure.Data.Context;
using MovieAPI.Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;
using MovieAPI.Application.Cqrs.Queries.MovieQueries;
using MovieAPI.Application.Dtos.MovieDtos;

namespace MovieAPI.Application.Cqrs.QueryHandlers.MovieQueryHandlers;

public class GetMovieAllQueryHandler : IRequestHandler<GetMovieAllQuery, ApiResponse<List<MovieGetAllDto>>>
{
    private readonly IUnitOfWork<AppDbContext> _unitOfWork;
    private readonly IMapper _mapper;

    public GetMovieAllQueryHandler(IUnitOfWork<AppDbContext> unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ApiResponse<List<MovieGetAllDto>>> Handle(GetMovieAllQuery request, CancellationToken cancellationToken)
    {
        var resRepo = _unitOfWork.GetRepository<Movie>()
            .GetAll(new PaginationParams
            {
                PageId = request.PageId,
                PageSize = request.PageSize,
                OrderKey = request.OrderKey,
                OrderType = request.OrderType
            });

        IQueryable<Movie> filteredData = ApplyFilter(resRepo.Item1);

        var data = await filteredData
            .ProjectTo<MovieGetAllDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        

        return new ApiResponse<List<MovieGetAllDto>>
        {
            Data = _mapper.Map<List<MovieGetAllDto>>(data),
            StatusCode = (int)HttpStatusCode.OK,
            IsSuccessful = true,
            TotalItemCount = resRepo.Item2
        };
    }

    private IQueryable<Movie> ApplyFilter(IQueryable<Movie> source)
    {
        return source;
    }
}