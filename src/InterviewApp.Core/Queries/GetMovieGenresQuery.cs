using InterviewApp.Core.Abstractions;
using InterviewApp.Core.Enums;

namespace InterviewApp.Core.Queries;

public sealed record GetMovieGenresQuery : IQuery<IEnumerable<MovieGenreEnum>>;