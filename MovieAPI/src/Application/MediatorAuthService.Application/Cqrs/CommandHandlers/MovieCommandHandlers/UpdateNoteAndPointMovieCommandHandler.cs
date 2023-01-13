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

public class UpdateNoteAndPointMovieCommandHandler : IRequestHandler<UpdateNoteAndPointMovieCommand, ApiResponse<MovieGetAllDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateNoteAndPointMovieCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ApiResponse<MovieGetAllDto>> Handle(UpdateNoteAndPointMovieCommand request, CancellationToken cancellationToken)
    {
        var movieBySourceId = await _unitOfWork.GetRepository<Movie>().GetByIdAsync(request.Id);
        
        Movie movie = new Movie();

        if (movieBySourceId != null)
        {
            var mappedUser = _mapper.Map(request, movieBySourceId);
            _unitOfWork.GetRepository<Movie>().Update(mappedUser);
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
            throw new BusinessException("There is a record of the id.");


        return new ApiResponse<MovieGetAllDto>
        {
            Data = _mapper.Map<MovieGetAllDto>(movie),
            IsSuccessful = true,
            StatusCode = (int)HttpStatusCode.Created,
            TotalItemCount = 1
        };
    }
}