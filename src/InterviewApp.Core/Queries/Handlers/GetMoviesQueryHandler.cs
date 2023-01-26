using InterviewApp.Core.Dispatchers;
using InterviewApp.Core.DTOs;
using InterviewApp.Core.Pagination;
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
        => _repo.GetAll();
}