using InterviewApp.Core.Entities;
using System.Linq.Expressions;

namespace InterviewApp.Core.Repositories;

internal interface IMoviesRepository
{
    Task<IEnumerable<MovieEntity>> GetAll(Expression<Func<MovieEntity, bool>> predicate);
    Task<MovieEntity?> Get(Guid id);
    Task Add(MovieEntity movie);
}
