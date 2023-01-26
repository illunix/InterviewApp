namespace InterviewApp.Core.Entities.Abstractions;

internal class EntityBase
{
    public Guid Id { get; } = Guid.NewGuid();
}