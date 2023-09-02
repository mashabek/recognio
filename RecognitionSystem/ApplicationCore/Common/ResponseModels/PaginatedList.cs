using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Common.ResponseModels;

public class PaginatedList<T>
{
    public IReadOnlyList<T> Items { get; }
    public int Page { get; }
    public int TotalPages { get; }
    public int TotalCount { get; set; }

    private PaginatedList(IReadOnlyList<T> items, int count, int page, int pageSize)
    {
        this.Items = items;
        this.Page = page;
        this.TotalPages = (int)Math.Ceiling((double)count / pageSize);
        this.TotalCount = count;
    }

    public static async Task<PaginatedList<T>> CreatePaginatedList(IQueryable<T> source, int page, int pageSize)
    {
        var totalCount = await source.CountAsync();
        var items  = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        return new PaginatedList<T>(items.AsReadOnly(), totalCount, page, pageSize);
    }
}