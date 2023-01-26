using InterviewApp.Core.Entities.Abstractions;

namespace InterviewApp.Core.Entities;

internal sealed class MovieEntity : EntityBase
{
    public string? Name { get; init; }
    public string? Description { get; init; }
    public int Genre { get; init; }
    public int ReleaseYear { get; init; }
    public bool HasOscar { get; init; }
}
