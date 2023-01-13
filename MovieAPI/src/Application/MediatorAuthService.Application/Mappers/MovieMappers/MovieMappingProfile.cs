using AutoMapper;
using MovieAPI.Application.Cqrs.Commands.MovieCommands;
using MovieAPI.Application.Dtos.MovieDtos;
using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Mappers.MovieMappers;

public class MovieMappingProfile : Profile
{
    public MovieMappingProfile()
    {
        CreateMap<Movie, MovieDto>().ReverseMap();
        CreateMap<Movie, MovieGetAllDto>().ReverseMap();
        CreateMap<MovieGetAllDto, Movie>().ReverseMap();
        CreateMap<CreateMovieCommand, Movie>();
        CreateMap<UpdateNoteAndPointMovieCommand, Movie>();

        CreateMap<CreateMovieCommand, MovieDto>().ReverseMap();
        CreateMap<MovieDto, CreateMovieCommand>().ReverseMap();

    }
}