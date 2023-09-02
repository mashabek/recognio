using ApplicationCore.Common.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Common.Extensions;

public static class MappingExtensions
{
    public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(
        this IQueryable<TDestination> source, int page, int pageSize)
        where TDestination : class => PaginatedList<TDestination>.CreatePaginatedList(source.AsNoTracking(), page, pageSize);
}