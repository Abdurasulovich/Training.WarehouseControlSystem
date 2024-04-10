using Microsoft.EntityFrameworkCore.Infrastructure;
using Training.WarehouseControlSystem.Domain.Common.Query;

namespace Training.WarehouseControlSystem.Persistence.Extensions;

public static class LinqExtensions
{
    public static IQueryable<TSource> ApplyPagination<TSource>(this IQueryable<TSource> sources,
        FilterPagination paginationOptions)
    =>sources.Skip((int)((paginationOptions.PageToken - 1) * paginationOptions.PageSize))
        .Take((int)paginationOptions.PageSize);

    public static async Task<T?> FirstOrDefaultAsync<T>(
        this IEnumerable<T> source,
        Func<T, Task<bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(predicate);

        if (cancellationToken.IsCancellationRequested) return default;

        foreach (var item in source)
            if(await predicate(item))
                return item;

        return default;
    }
}
