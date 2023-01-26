namespace InterviewApp.Core.DTOs;

public sealed record MovieDTO(
    string Name,
    string Description,
    int Genre,
    int ReleaseYear,
    bool HasOscar
);
