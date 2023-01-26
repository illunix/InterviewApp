using InterviewApp.Core.Abstractions;
using InterviewApp.Core.Handlers;

namespace InterviewApp.Core.Dispatchers;

internal sealed class Dispatcher : IDispatcher
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;
    private readonly IEventDispatcher _eventDispatcher;

    public Dispatcher(
        ICommandDispatcher commandDispatcher, 
        IQueryDispatcher queryDispatcher,
        IEventDispatcher eventDispatcher
    )
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
        _eventDispatcher = eventDispatcher;
    }

    public Task Send<T>(
        T req,
        CancellationToken ct = default
    ) where T :
        class,
        ICommand
        => _commandDispatcher.Send(
            req,
            ct
        );

    public Task<TResult> Send<TResult>(
        IQuery<TResult> req,
        CancellationToken ct = default
    )
        => _queryDispatcher.Send(
            req,
            ct
        );

    public Task Publish<T>(
       T @event,
       CancellationToken ct = default
    ) where T : class, IEvent
        => _eventDispatcher.Publish(
            @event,
            ct
        );
}