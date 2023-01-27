using InterviewApp.Core.Abstractions;

namespace InterviewApp.Core.Handlers;

internal interface ICommandDispatcher
{
    Task Send<TCommand>(
        TCommand req,
        CancellationToken ct = default
    ) where TCommand :
        class,
        ICommand;
}