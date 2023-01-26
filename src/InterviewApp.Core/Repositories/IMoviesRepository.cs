using InterviewApp.Core.Entities;

namespace InterviewApp.Core.Repositories;

internal interface IMoviesRepository
{
    Task<MovieEntity?> Get(Guid id);
    Task Add(MovieEntity movie);
}
