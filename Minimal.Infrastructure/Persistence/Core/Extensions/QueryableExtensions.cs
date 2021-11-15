using Minimal.Domain.Core.Pagination;

namespace Minimal.Infrastructure.Persistence.Core.Extensions
{
    public static class QueryableExtensions
    {
        public static PaginatedList<T> Paginate<T>(this IQueryable<T> queryable, int page, int limit)
        {
            var itens = queryable.Skip(page * limit).Take(limit).ToList();
            var total = queryable.Count();

            return new PaginatedList<T>
            {
                Itens = itens,
                Total = total,
                Page = page,
                Limit = limit
            };
        }
    }
}
