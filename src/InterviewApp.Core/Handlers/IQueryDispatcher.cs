using InterviewApp.Core.Abstractions;

namespace InterviewApp.Core.Handlers;

internal interface IQueryDispatcher
{
    Task<TResult> Send<TResult>(
        IQuery<TResult> req,
        CancellationToken ct = default
    );
}