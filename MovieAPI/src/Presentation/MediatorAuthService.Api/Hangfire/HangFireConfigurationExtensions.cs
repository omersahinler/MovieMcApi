using Hangfire;
using Newtonsoft.Json;

namespace MovieAPI.Api.Jobs
{
    public static class HangFireConfigurationExtensions
    {
        public static void UseMediatR(this IGlobalConfiguration configuration)
        {
            var jsonSettings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
            };
            configuration.UseSerializerSettings(jsonSettings);
        }
    }
}
