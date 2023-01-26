using InterviewApp.Core.Pagination;
using Microsoft.EntityFrameworkCore;

namespace InterviewApp.Core.DAL;

internal static class Pagination
{
    public static Task<Paged<T>> Paginate<T>(
        this IQueryable<T> data,
        IPagedQuery<T> req,
        CancellationToken ct = default
    )
        => data.Paginate(
            req.Page,
            req.Results,
            ct
        );

    public static async Task<Paged<T>> Paginate<T>(
        this IQueryable<T> data,
        int page,
        int results,
        CancellationToken ct = default
    )
    {
        if (page <= 0)
            page = 1;

        results = results switch
        {
            <= 0 => 10,
            > 100 => 100,
            _ => results
        };

        var totalResults = await data.CountAsync(ct);
        var totalPages = totalResults <= results ? 1 : (int)Math.Floor((double)totalResults / results);
        var result = await data.
            Skip((page - 1) * results)
            .Take(results)
            .ToListAsync(ct);

        return Paged<T>.Create(
            result,
            page,
            results,
            totalPages,
            totalResults
        );
    }

    public static Task<List<T>> SkipAndTake<T>(
        this IQueryable<T> data,
        IPagedQuery<T> query,
        CancellationToken cancellationToken = default
    )
        => data.SkipAndTake(
            query.Page,
            query.Results,
            cancellationToken
        );

    public static async Task<List<T>> SkipAndTake<T>(
        this IQueryable<T> data,
        int page,
        int results,
        CancellationToken ct = default
    )
    {
        if (page <= 0)
            page = 1;

        results = results switch
        {
            <= 0 => 10,
            > 100 => 100,
            _ => results
        };

        return await data
            .Skip((page - 1) * results)
            .Take(results)
            .ToListAsync(ct);
    }
}