using InterviewApp.Core.Abstractions;
using InterviewApp.Core.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace InterviewApp.Core.Dispatchers;

internal sealed class QueryDispatcher : IQueryDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public QueryDispatcher(IServiceProvider serviceProvider)
        => _serviceProvider = serviceProvider;

    public async Task<TResult> Send<TResult>(
        IQuery<TResult> req,
        CancellationToken cancellationToken = default
    )
    {
        if (req is null)
            throw new InvalidOperationException("Query cannot be null.");

        await using var scope = _serviceProvider.CreateAsyncScope();
        var handlerType = typeof(IQueryHandler<,>).MakeGenericType(
            req.GetType(),
            typeof(TResult)
        );
        var handler = scope.ServiceProvider.GetRequiredService(handlerType);
        var method = handlerType.GetMethod(nameof(IQueryHandler<IQuery<TResult>, TResult>.Handle));
        if (method is null)
            throw new InvalidOperationException($"Query handler for '{typeof(TResult).Name}' is invalid.");

#pragma warning disable CS8602
#pragma warning disable CS8600
        return await (Task<TResult>)method.Invoke(
            handler,
            new object[]
            {
                req,
                cancellationToken
            }
        );
#pragma warning restore CS8600
#pragma warning restore CS8602
    }
}