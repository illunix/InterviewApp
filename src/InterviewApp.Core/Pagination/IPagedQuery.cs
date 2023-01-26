using InterviewApp.Core.Abstractions;

namespace InterviewApp.Core.Pagination;

internal interface IPagedQuery<T> : IQuery<T>
{
    int Page { get; init; }
    int Results { get; init; }
}
