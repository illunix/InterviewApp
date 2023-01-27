using InterviewApp.Core.Builders;
using InterviewApp.Core.DTOs;
using InterviewApp.Core.Entities;
using InterviewApp.Core.Handlers;
using InterviewApp.Core.Repositories;

namespace InterviewApp.Core.Queries.Handlers;

internal sealed class GetMoviesQueryHandler : IQueryHandler<GetMoviesQuery, IEnumerable<MovieDTO>>
{
    private readonly IMoviesRepository _repo;

    public GetMoviesQueryHandler(IMoviesRepository repo)
        => _repo = repo;

    public async Task<IEnumerable<MovieDTO>> Handle(
        GetMoviesQuery req,
        CancellationToken ct
    )
    {
        if (
            req.ReleaseYear is not null &&
            req.ReleaseYear?.ToString().Length != 4
        )
            throw new ArgumentException(
                "Invalid year.",
                nameof(req.ReleaseYear)
            );

        var predicate = PredicateBuilder.True<MovieEntity>();

        if (req.Genre is not null)
            predicate = predicate.And(q => q.Genre == req.Genre);

        if (req.ReleaseYear is not null)
            predicate = predicate.And(q => q.ReleaseYear == req.ReleaseYear);

        if (
            req.HasOscar == true &&
            req.HasOscar is not null
        )
            predicate = predicate.And(q => q.HasOscar == true);

        return (await _repo.GetAll(predicate)).Select(q => new MovieDTO(
            q.Name!,
            q.Description!,
            q.Genre,
            q.ReleaseYear,
            q.HasOscar
        )).ToList();
    }
}