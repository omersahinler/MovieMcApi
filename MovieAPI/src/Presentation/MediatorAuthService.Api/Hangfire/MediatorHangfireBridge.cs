using MediatR;
using MovieAPI.Application.Cqrs.Queries.MovieQueries;

namespace MovieAPI.Api.Jobs
{
    public class MediatorHangfireBridge 
    {
        public IConfiguration Configuration { get; }
        private readonly IMediator _mediator;


        public MediatorHangfireBridge(IConfiguration configuration, IMediator mediator)
        {
            Configuration = configuration;
            _mediator = mediator;
        }
        public async Task GetMovies()
        {
            
           await _mediator.Send(new GetMoviesApiAll());               
        }

    }
}
