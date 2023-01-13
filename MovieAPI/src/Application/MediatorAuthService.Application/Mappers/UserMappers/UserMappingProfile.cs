using AutoMapper;
using MovieAPI.Application.Cqrs.Commands.UserCommands;
using MovieAPI.Application.Cqrs.Queries.UserQueries;
using MovieAPI.Application.Dtos.UserDtos;
using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Mappers.UserMappers;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<CreateUserCommand, User>();
        CreateMap<UpdateUserCommand, User>();
        CreateMap<GetUserByIdQuery, User>();
    }
}