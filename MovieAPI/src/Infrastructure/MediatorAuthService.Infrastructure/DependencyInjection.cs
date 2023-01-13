using MovieAPI.Infrastructure.Data.Context;
using MovieAPI.Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MovieAPI.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Default"), mig => mig.MigrationsAssembly("MovieAPI.Api")));

        services.AddUnitOfWork<AppDbContext>();

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        return services;
    }
}