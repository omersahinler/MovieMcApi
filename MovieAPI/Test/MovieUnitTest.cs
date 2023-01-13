using MediatR;
using Moq;
using MovieAPI.Api.Controllers.V1;

namespace Test
{
    public class MovieUnitTest
    {
        [Fact]
        public void GetByMovieIdTest()
        {
            var service = new Mock<IMediator>();
            var controller = new MovieController(service.Object);
            var resault = controller.GetById(new Guid("3E7D4309-D250-4637-5117-08DAF269477E"));
            Assert.NotNull(resault);
        }
        
    }
}