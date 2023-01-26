using InterviewApp.Core.Abstractions;

namespace InterviewApp.Core.Dispatchers;

internal interface IQueryHandler<in TQuery, TResult> where TQuery :
    class,
    IQuery<TResult>
{
    Task<TResult> Handle(
        TQuery req,
        CancellationToken ct = default
    );
}