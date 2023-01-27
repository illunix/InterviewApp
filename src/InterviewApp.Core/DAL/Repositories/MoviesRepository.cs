using InterviewApp.Core.Entities;
using InterviewApp.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

    public async Task<IEnumerable<MovieEntity>> GetAll(Expression<Func<MovieEntity, bool>> predicate)
        => await _ctx.Movies
            .Where(predicate)
            .ToListAsync()
            .ConfigureAwait(false);

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