namespace InterviewApp.API.Swagger;

public sealed class SwaggerOptions
{
    public bool Enabled { get; init; }
    public string Title { get; init; } = string.Empty;
    public string Version { get; init; } = string.Empty;
    public string Route { get; init; } = string.Empty;
}
