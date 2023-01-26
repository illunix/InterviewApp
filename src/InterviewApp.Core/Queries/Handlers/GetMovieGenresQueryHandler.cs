using InterviewApp.Core.Dispatchers;
using InterviewApp.Core.Enums;

namespace InterviewApp.Core.Queries.Handlers;

internal sealed class GetMovieGenresQueryHandler : IQueryHandler<GetMovieGenresQuery, IEnumerable<MovieGenreEnum>>
{
    public async Task<IEnumerable<MovieGenreEnum>> Handle(
        GetMovieGenresQuery req,
        CancellationToken ct
    )
        => await Task.FromResult(MovieGenreEnum.List);
}

