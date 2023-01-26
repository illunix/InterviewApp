using InterviewApp.Core.DTOs;
using InterviewApp.Core.Pagination;

namespace InterviewApp.Core.Queries;

public sealed record GetMoviesQuery(
    int ReleaseYear,
    bool HasOscar
) : IPagedQuery<IEnumerable<MovieDTO>>
{
    public int Page { get; init; } 
    public int Results { get; init; }
}    