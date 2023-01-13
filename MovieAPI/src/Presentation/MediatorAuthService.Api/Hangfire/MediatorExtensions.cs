using Hangfire;
using MediatR;

namespace MovieAPI.Api.Jobs
{
    public static class MediatorExtensions
    {
        public static void Enqueue(this IMediator mediator)
        {
            RecurringJob.AddOrUpdate<MediatorHangfireBridge> ("Movie job1", x => x.GetMovies(), Cron.Daily(08, 0), TimeZoneInfo.Local);
        }
    }
}
