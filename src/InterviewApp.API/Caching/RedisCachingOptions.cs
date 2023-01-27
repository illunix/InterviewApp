namespace InterviewApp.API.Caching;

public sealed class RedisCachingOptions
{
    public bool Enabled { get; init; }
    public string? Endpoint { get; init; }
}