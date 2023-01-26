using InterviewApp.Core.Entities;
using InterviewApp.Core.Pagination;
using InterviewApp.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InterviewApp.Core.DAL.Repositories;

internal sealed class MoviesRepository : IMoviesRepository
{
    private readonly InterviewAppDbContext _ctx;
    private readonly DbSet<MovieEntity> _movies;

    public MoviesRepository(InterviewAppDbContext ctx)
    {
        _ctx = ctx;
        _movies = _ctx.Movies;
    }

    public async Task<Paged<MovieEntity>> GetAll(
        int genre,
        int releaseYear,
        bool hasOscar
    )
    {
        var elo = (await _movies.Paginate(
            1,
            20
        )).Items.Where(q => q.Genre == genre);
    }

    public Task<MovieEntity?> Get(Guid id)
        => _movies.SingleOrDefaultAsync(q => q.Id == id);

    public async Task Add(MovieEntity movie)
    {
        _movies.Add(movie);
        await _ctx
            .SaveChangesAsync()
            .ConfigureAwait(false);
    }
}