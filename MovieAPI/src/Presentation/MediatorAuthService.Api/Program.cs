using MovieAPI.Api.Extensions;
using MovieAPI.Application;
using MovieAPI.Application.Middlewares;
using MovieAPI.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Hangfire;
using MovieAPI.Api.Jobs;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddEnvironmentVariables()
    .Build();
builder.Services.AddHangfire(x =>
{
    x.UseSqlServerStorage(@"Data Source=.\sqlexpress;Initial Catalog=MovieAPI;Integrated Security=True;Pooling=False");
    x.UseMediatR();
});
builder.Services.AddHangfireServer();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGenCustomize();

builder.Services.AddApplication(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddApiVersion();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

var app = builder.Build();

app.ApplyMigration();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//RecurringJob.AddOrUpdate<MovieServiceJob>("Movie job1", x => x.GetMovies(), Cron.Daily(08, 0), TimeZoneInfo.Local);

app.UseMiddleware<ExceptionHandlerMiddleware>();


app.UseHangfireDashboard();
app.MapHangfireDashboard();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
//BackgroundJob.Enqueue<IMediator>(mediator => mediator.Send(new GetMoviesApiAll()));


