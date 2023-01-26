namespace InterviewApp.Core.Pagination;

public abstract class PagedQuery<T> : IPagedQuery<Paged<T>>
{
    public int Page { get; init; }
    public int Results { get; init; }
}