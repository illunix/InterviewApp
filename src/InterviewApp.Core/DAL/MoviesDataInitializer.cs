using InterviewApp.Core.DAL.Abstractions;
using InterviewApp.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace InterviewApp.Core.DAL;

internal sealed class MoviesDataInitializer : IDataInitializer
{
    private readonly InterviewAppDbContext _ctx;
    private readonly ILogger<MoviesDataInitializer> _logger;

    public MoviesDataInitializer(
        InterviewAppDbContext ctx,
        ILogger<MoviesDataInitializer> logger
    )
    {
        _ctx = ctx;
        _logger = logger;
    }

    public async Task Init()
    {
        if (await _ctx.Movies.AnyAsync())
            return;

        await AddMovies().ConfigureAwait(false);
        await _ctx
            .SaveChangesAsync()
            .ConfigureAwait(false);
    }

    private async Task AddMovies()
    {
        await _ctx.Movies
            .AddAsync(new()
            {
                Name = "Eyes Wide Shut",
                Description = "A doctor becomes obsessed with having a sexual encounter after his wife admits to having sexual fantasies about a man she met and chastising him for dishonesty in not admitting to his own fantasies. This sets him off into unfulfilled encounters with a dead patient's daughter and a hooker.",
                Genre = MovieGenreEnum.Drama,
                ReleaseYear = 1999
            })
            .ConfigureAwait(false);

        await _ctx.Movies
            .AddAsync(new()
            {
                Name = "Star Wars: Episode IV - A New Hope",
                Description = "The fate of the galaxy is forever changed when Luke Skywalker discovers his powerful connection to a mysterious Force, and blasts into space to rescue Princess Leia. Mentored by a wise Jedi Master, and opposed by the menacing Darth Vader, Luke takes his first steps on a hero's journey.",
                Genre = MovieGenreEnum.ScienceFiction,
                ReleaseYear = 1977,
                HasOscar = true
            })
            .ConfigureAwait(false);

        await _ctx.Movies
            .AddAsync(new()
            {
                Name = "A Clockwork Orange",
                Description = "Set in a dismal dystopian England, it is the first-person account of a juvenile delinquent who undergoes state-sponsored psychological rehabilitation for his aberrant behaviour. The novel satirizes extreme political systems that are based on opposing models of the perfectibility or incorrigibility of humanity.",
                Genre = MovieGenreEnum.Drama,
                ReleaseYear = 1971
            })
            .ConfigureAwait(false);

        await _ctx.Movies
            .AddAsync(new()
            {
                Name = "The Conjuring",
                Description = "Paranormal investigators Ed and Lorraine Warren work to help a family terrorized by a dark presence in their farmhouse. In 1971, Carolyn and Roger Perron move their family into a dilapidated Rhode Island farm house and soon strange things start happening around it with escalating nightmarish terror.",
                Genre = MovieGenreEnum.Horror,
                ReleaseYear = 2013,
                HasOscar = true
            })
            .ConfigureAwait(false);

        await _ctx.Movies
            .AddAsync(new()
            {
                Name = "Sinister",
                Description = "Ethan Hawke is struggling true-crime writer whose discovery of videos depicting grisly murders in his new house puts his family in danger.",
                Genre = MovieGenreEnum.Horror,
                ReleaseYear = 2012
            })
            .ConfigureAwait(false);

        await _ctx.Movies
            .AddAsync(new()
            {
                Name = "The Wolf of Wall Street",
                Description = "Jordan Belfort (DiCaprio) is Long Island penny stockbroker who serves almost two years in prison for refusing to co-operate in a huge 1990s securities fraud case that involved widespread corruption on Wall Street and in the corporate banking world, including mob infiltration.",
                Genre = MovieGenreEnum.Comedy,
                ReleaseYear = 2013
            })
            .ConfigureAwait(false);

        await _ctx.Movies
            .AddAsync(new()
            {
                Name = "Dune",
                Description = "A dune is a mound of sand formed by the wind, usually along the beach or in a desert. Dunes form when wind blows sand into a sheltered area behind an obstacle. Dunes grow as grains of sand accumulate.",
                Genre = MovieGenreEnum.ScienceFiction,
                ReleaseYear = 2021,
                HasOscar = true
            })
            .ConfigureAwait(false);

        _logger.LogInformation("Initialized movies.");
    }
}