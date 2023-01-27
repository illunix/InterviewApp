using InterviewApp.Core.Abstractions;

namespace InterviewApp.Core.Handlers;

internal interface IEventHandler<in TEvent> where TEvent :
    class,
    IEvent
{
    Task Handle(
        TEvent @event,
        CancellationToken ct = default
    );
}