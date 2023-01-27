using InterviewApp.Core.Abstractions;

namespace InterviewApp.Core.Handlers;

internal interface IEventDispatcher
{
    Task Publish<TEvent>(
        TEvent @event,
        CancellationToken ct = default
    ) where TEvent :
        class,
        IEvent;
}