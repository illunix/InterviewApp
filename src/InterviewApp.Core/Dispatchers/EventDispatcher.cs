using InterviewApp.Core.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace InterviewApp.Core.Dispatchers;

internal sealed class EventDispatcher : IEventDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public EventDispatcher(IServiceProvider serviceProvider)
        => _serviceProvider = serviceProvider;

    public async Task Publish<TEvent>(
        TEvent @event,
        CancellationToken ct = default
    ) where TEvent : class, IEvent
    {
        if (@event is null)
            throw new InvalidOperationException("Event cannot be null.");

        await using var scope = _serviceProvider.CreateAsyncScope();
        var handlers = scope.ServiceProvider.GetServices<IEventHandler<TEvent>>();
        var tasks = handlers.Select(q => q.Handle(
            @event,
            ct
        ));
        await Task.WhenAll(tasks);
    }
}