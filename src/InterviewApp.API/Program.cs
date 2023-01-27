using InterviewApp.API.Caching;
using InterviewApp.API.Exceptions;
using InterviewApp.API.Logging;
using InterviewApp.API.Swagger;
using InterviewApp.Core;
using InterviewApp.Core.Handlers;
using InterviewApp.Core.Queries;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder
    .AddLogging()
    .Services
    .AddErrorHandling()
    .AddSwaggerDocs(config)
    .AddCore(config)
    .AddRedisOutputCache(config);

var app = builder.Build();

app.MapGet(
    "/api/movies",
    async (
        [AsParameters] GetMoviesQuery req,
        IDispatcher dispatcher
    ) => Results.Ok(await dispatcher.Send(req))
)
    .CacheOutput(q => q.Tag("movies"))
    .WithTags("Movies")
    .WithName("Get Movies")
    .Produces(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status400BadRequest);

app.MapGet(
    "/api/movies/genres",
    async (
        IDispatcher dispatcher
    ) => Results.Ok(await dispatcher.Send(new GetMovieGenresQuery()))
)
    .CacheOutput(q => q.Tag("moviesGenres"))
    .WithTags("Movies")
    .WithName("Get Movies Genres")
    .Produces(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status400BadRequest);

app.UseOutputCache();
app.UseSwaggerDocs();
app.UseHttpsRedirection();
app.Run();
