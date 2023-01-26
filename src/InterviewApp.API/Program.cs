using InterviewApp.API.Extensions;
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
    .AddCore(config);

var app = builder.Build();

app.MapGet(
    "/api/movies/genres",
    async (
        GetMoviesQuery req,
        IDispatcher dispatcher
    ) => Results.Ok(await dispatcher.Send(req))
)
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
    .WithTags("Movies")
    .WithName("Get Movies Genres")
    .Produces(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status400BadRequest);

app.UseSwaggerDocs();
app.UseHttpsRedirection();
app.Run();
