using InterviewApp.Core.Abstractions;

namespace InterviewApp.Core.Handlers;

public interface IDispatcher
{
    Task Send<T>(
        T req,
        CancellationToken ct = default
    ) where T :
        class,
        ICommand;
    Task<TResult> Send<TResult>(
        IQuery<TResult> req,
        CancellationToken ct = default
    );
    Task Publish<T>(
        T @event,
        CancellationToken ct = default
    ) where T :
        class,
        IEvent;
}