using InterviewApp.Core.Abstractions;

namespace InterviewApp.Core.Handlers;

internal interface ICommandHandler<in TCommand> where TCommand :
    class,
    ICommand
{
    Task Handle(
        TCommand req,
        CancellationToken ct = default
    );
}
