using AutoMapper;
using MovieAPI.Application.Cqrs.Commands.MovieCommands;
using MovieAPI.Application.Dtos.MovieDtos;
using MovieAPI.Application.Exceptions;
using MovieAPI.Application.Wrappers;
using MovieAPI.Domain.Entities;
using MovieAPI.Infrastructure.UnitOfWork;
using MediatR;
using System.Net;
using MovieAPI.Application.Dtos.MovieDtos;

namespace MovieAPI.Application.Cqrs.CommandHandlers.MovieComandHandlers;

public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, ApiResponse<MovieDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateMovieCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ApiResponse<MovieDto>> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
    {
        var movieBySourceId = await _unitOfWork.GetRepository<Movie>().SingleOrDefaultAsync(x => x.source_id.Equals(request.source_id));
        Movie movie = new Movie();
        if (movieBySourceId == null)
        {
            movie = _mapper.Map<Movie>(request);
            await _unitOfWork.GetRepository<Movie>().AddAsync(movie);
            try
            {
                await _unitOfWork.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        else
            movie = movieBySourceId;

        return new ApiResponse<MovieDto>
        {
            Data = _mapper.Map<MovieDto>(movie),
            IsSuccessful = true,
            StatusCode = (int)HttpStatusCode.Created,
            TotalItemCount = 1
        };
    }
}