using MediatR;
using System.Net;
using AutoMapper;
using MovieAPI.Application.Cqrs.Commands.MovieCommands;
using MovieAPI.Application.Cqrs.Queries.MovieQueries;
using MovieAPI.Application.Dtos.ResponseDtos;
using Refit;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;
using MovieAPI.Application.Dtos.MovieDtos;

namespace MovieAPI.Application.Cqrs.QueryHandlers.MoviesQueriesHandlers;

public class GetMoviesApiAllHandler : IRequestHandler<GetMoviesApiAll, Wrappers.ApiResponse<NoDataDto>>
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    public GetMoviesApiAllHandler(IMediator mediator,IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<Wrappers.ApiResponse<NoDataDto>> Handle(GetMoviesApiAll request, CancellationToken cancellationToken)
    {
        try
        {
            MovieResponse movieResponse = new MovieResponse();


            string merlinApiUrl = "https://api.themoviedb.org/3/search/movie?api_key=e57cace9b13afb3800f0cfa7d73b7e54&query=Jack+Reacher";

            HttpContent contentPost = null;

            string jsonString = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            contentPost = content;
            var client = new HttpClient();

            var responseStream = await client.GetAsync($"{merlinApiUrl}");
            string responseBody = await responseStream.Content.ReadAsStringAsync();
            movieResponse = JsonConvert.DeserializeObject<MovieResponse>(responseBody);

            foreach (var responseResult in movieResponse.results)
            {
                CreateMovieCommand createMovieCommand = new CreateMovieCommand();
                var movieEntity = _mapper.Map<CreateMovieCommand>(responseResult);
                await _mediator.Send(movieEntity);

            }

            return new Wrappers.ApiResponse<NoDataDto>
            {
                Data = new NoDataDto(),
                StatusCode = (int)HttpStatusCode.OK,
                IsSuccessful = true,
            };
        }
        catch (ApiException ex)
        {
            throw ex;
        }
    }
}