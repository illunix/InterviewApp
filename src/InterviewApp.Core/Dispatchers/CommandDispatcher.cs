using InterviewApp.Core.Abstractions;
using InterviewApp.Core.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace InterviewApp.Core.Dispatchers;

internal sealed class CommandDispatcher : ICommandDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public CommandDispatcher(IServiceProvider serviceProvider)
        => _serviceProvider = serviceProvider;

    public async Task Send<TCommand>(
        TCommand req,
        CancellationToken ct = default
   ) where TCommand : class, ICommand
    {
        if (req is null)
            throw new InvalidOperationException("Command cannot be null.");

        await using var scope = _serviceProvider.CreateAsyncScope();
        var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();
        await handler.Handle(
            req,
            ct
        );
    }
}