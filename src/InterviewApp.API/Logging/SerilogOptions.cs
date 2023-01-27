namespace InterviewApp.API.Logging;

internal sealed class SerilogOptions
{
    public string Level { get; init; } = string.Empty;
    public ConsoleOptions Console { get; init; } = new();
    public FileOptions File { get; init; } = new();
    public SeqOptions Seq { get; init; } = new();
    public IEnumerable<string>? ExcludePaths { get; init; }
    public IEnumerable<string>? ExcludeProperties { get; init; }
    public Dictionary<string, string> Overrides { get; init; } = new();
    public Dictionary<string, object> Tags { get; init; } = new();

    public sealed class ConsoleOptions
    {
        public bool Enabled { get; init; }
    }

    public sealed class FileOptions
    {
        public bool Enabled { get; init; }
        public string Path { get; init; } = string.Empty;
        public string Interval { get; init; } = string.Empty;
    }

    public sealed class SeqOptions
    {
        public bool Enabled { get; init; }
        public string Url { get; init; } = string.Empty;
        public string ApiKey { get; init; } = string.Empty;
    }
}