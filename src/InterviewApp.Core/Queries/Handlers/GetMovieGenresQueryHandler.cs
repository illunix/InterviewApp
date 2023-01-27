using InterviewApp.Core.Enums;
using InterviewApp.Core.Handlers;

namespace InterviewApp.Core.Queries.Handlers;

internal sealed class GetMovieGenresQueryHandler : IQueryHandler<GetMovieGenresQuery, IEnumerable<MovieGenreEnum>>
{
    public async Task<IEnumerable<MovieGenreEnum>> Handle(
        GetMovieGenresQuery req,
        CancellationToken ct
    )
        => await Task.FromResult(MovieGenreEnum.List);
}

