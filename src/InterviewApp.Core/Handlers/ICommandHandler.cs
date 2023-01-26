using InterviewApp.Core.Abstractions;

namespace InterviewApp.Core.Dispatchers;

internal interface ICommandHandler<in TCommand> where TCommand :
    class,
    ICommand
{
    Task Handle(
        TCommand req,
        CancellationToken ct = default
    );
}
