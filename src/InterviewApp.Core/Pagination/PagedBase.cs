namespace InterviewApp.Core.Pagination;

internal abstract class PagedBase
{
    public int CurrentPage { get; init; }
    public int ResultsPerPage { get; init; }
    public int TotalPages { get; init; }
    public long TotalResults { get; init; }

    protected PagedBase() { }

    protected PagedBase(
        int currentPage,
        int resultsPerPage,
        int totalPages,
        long totalResults
    )
    {
        CurrentPage = currentPage;
        ResultsPerPage = resultsPerPage;
        TotalPages = totalPages;
        TotalResults = totalResults;
    }
}