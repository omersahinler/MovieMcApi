using MovieAPI.Api.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using MovieAPI.Application.Cqrs.Queries.MovieQueries;
using MovieAPI.Application.Cqrs.Commands.MovieCommands;
using MovieAPI.Api.Jobs;

namespace MovieAPI.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class MovieController : MediatorBaseController
    {
        private readonly IMediator _mediator;

        public MovieController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getMoviesApiAll")]

        public IActionResult GetMoviesApiAll()
        {
            _mediator.Enqueue();

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMovie([FromQuery] GetMovieAllQuery request)
        {
            var response = await _mediator.Send(request);

            return ActionResultInstance(response);
        }
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _mediator.Send(new GetMovieByIdQuery(id));

            return ActionResultInstance(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMovie(UpdateNoteAndPointMovieCommand command)
        {
            var response = await _mediator.Send(command);

            return ActionResultInstance(response);
        }
        [HttpGet]
        [Route("MovieRecommendationById")]
        public async Task<IActionResult> GetMovieRecommendationByIdQuery(Guid id, string mailTo)
        {
            var response = await _mediator.Send(new GetMovieRecommendationByIdQuery(id,mailTo));

            return ActionResultInstance(response);
        }
    }
}