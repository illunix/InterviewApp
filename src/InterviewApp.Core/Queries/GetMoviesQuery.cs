using InterviewApp.Core.Abstractions;
using InterviewApp.Core.DTOs;

namespace InterviewApp.Core.Queries;

public sealed record GetMoviesQuery(
    int? ReleaseYear,
    bool? HasOscar
) : IQuery<IEnumerable<MovieDTO>>;
